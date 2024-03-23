using AutoMapper;
using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Repository.Repository;

namespace SpotMusic.Application.Streaming
{
    public class AlbumService
    {
        private AutorRepository AutorRepository;
        private EstiloMusicalRepository EstiloMusicalRepository;
        private AlbumRepository AlbumRepository;
        private IMapper mapper;

        public AlbumService(AutorRepository autorRepository, IMapper mapper, EstiloMusicalRepository estiloMusicalRepository, AlbumRepository albumRepository)
        {
            this.AutorRepository = autorRepository;
            this.mapper = mapper;
            this.EstiloMusicalRepository = estiloMusicalRepository;
            this.AlbumRepository = albumRepository;
        }

        public AlbumDto Criar(AlbumDto dto)
        {
            var autorprincipal = AutorRepository.GetById(dto.IdAutorPrincipal);
            
            if (autorprincipal == null)
                throw new Exception($"Autor principal inexiste.");

            List<Musica> musicas = [];

            dto.Musicas.ForEach(x =>
            {
                var estilo = EstiloMusicalRepository.GetById(x.IdEstiloMusical);

                if (estilo == null)
                    throw new Exception($"Estilo musical não cadastrado. {x.IdEstiloMusical}");

                List<Autor> autores = [];

                x.Autores.ForEach(t =>
                {
                    if (!t.Id.Equals(autorprincipal.Id))
                    {
                        var autor = AutorRepository.GetById(t.Id);

                        if (autor == null)
                            throw new Exception($"Autor {t.Nome} inexiste.");

                        autores.Add(autor);
                    }
                    else
                    {
                        autores.Add(autorprincipal);
                    }                    
                });

                Musica musica = Musica.Criar(x.Nome, x.Duracao, x.Letra, estilo, autores);

                musicas.Add(musica);
            });

            Album album = Album.Criar(dto.Nome, musicas, autorprincipal, dto.Capa);

            AlbumRepository.Save(album);

            return this.mapper.Map<AlbumDto>(album);
        }

        public AlbumDto Obter(Guid IdAutor, Guid IdAlbum)
        {
            var autor = this.AutorRepository.GetById(IdAutor);

            if (autor == null)
                throw new Exception("Autor inexistente.");

            var album = AlbumRepository.Find(x => x.AutorPrincipal.Id == IdAutor && x.Id == IdAutor);

            return this.mapper.Map<AlbumDto>(album);
        }
    }
}
