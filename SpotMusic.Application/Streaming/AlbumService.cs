using AutoMapper;
using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Repository.Repository;

namespace SpotMusic.Application.Streaming
{
    public class AlbumService
    {
        private AutorRepository AutorRepository;
        private AlbumRepository AlbumRepository;
        private IMapper mapper;

        public AlbumService(AutorRepository autorRepository, IMapper mapper, AlbumRepository albumRepository)
        {
            this.AutorRepository = autorRepository;
            this.mapper = mapper;
            this.AlbumRepository = albumRepository;
        }

        public AlbumDto? Obter(Guid IdAutor, Guid IdAlbum)
        {
            var autor = this.AutorRepository.GetById(IdAutor);

            if (autor == null)
                return null;

            var album = AlbumRepository.Find(x => x.AutorPrincipal.Id == IdAutor && x.Id == IdAutor).FirstOrDefault();

            return this.mapper.Map<AlbumDto>(album);
        }

        public List<AlbumDto> ObterPorAutor(Guid IdAutor, Guid IdUsuario)
        {
            var albuns = AlbumRepository.Find(x => x.AutorPrincipal.Id == IdAutor).ToList();

            var albunsDto = this.mapper.Map<List<AlbumDto>>(albuns);

            albunsDto?.ForEach(x => {
                foreach (var item in x.Musicas)
                {
                    item.favorito = albuns.Any(b => b.Musicas.Any(y => y.Playlists.Any(t => t.Autor.Id == IdUsuario && t.TipoPlayList == Domain.Streaming.Enum.TipoPlayList.Favorita) && y.Id == item.Id));
                }
            });

            return albunsDto ?? [];
        }
    }
}
