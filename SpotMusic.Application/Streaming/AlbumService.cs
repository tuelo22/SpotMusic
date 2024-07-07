using AutoMapper;
using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Repository.Repository;

namespace SpotMusic.Application.Streaming
{
    public class AlbumService(
        AutorRepository autorRepository, 
        IMapper mapper, 
        AlbumRepository albumRepository,
        MusicaRepository musicaRepository
        )
    {
        public AlbumDto? Obter(Guid IdAutor, Guid IdAlbum)
        {
            var autor = autorRepository.GetById(IdAutor);

            if (autor == null)
                return null;

            var album = albumRepository.Find(x => x.AutorPrincipal.Id == IdAutor && x.Id == IdAutor).FirstOrDefault();

            return mapper.Map<AlbumDto>(album);
        }

        public AlbumDto Obter(Guid IdAlbum)
        {
            var album = albumRepository.GetById(IdAlbum);

            return mapper.Map<AlbumDto>(album);
        }

        public List<AlbumDto> ObterPorAutor(Guid IdAutor, Guid IdUsuario)
        {
            var albuns = albumRepository.Find(x => x.AutorPrincipal.Id == IdAutor).ToList();

            var albunsDto = mapper.Map<List<AlbumDto>>(albuns);

            albunsDto?.ForEach(x => {
                foreach (var item in x.Musicas)
                {
                    item.favorito = albuns.Any(b => b.Musicas.Any(y => y.Playlists.Any(t => t.Autor.Id == IdUsuario && t.TipoPlayList == Domain.Streaming.Enum.TipoPlayList.Favorita) && y.Id == item.Id));
                }
            });

            return albunsDto ?? [];
        }

        public List<AlbumDto> ObterPorAutor(Guid IdAutor)
        {
            var albuns = albumRepository.Find(x => x.AutorPrincipal.Id == IdAutor).ToList();

            var albunsDto = mapper.Map<List<AlbumDto>>(albuns);

            return albunsDto ?? [];
        }

        public List<AlbumDto> ObterTodos()
        {
            var albuns = albumRepository.GetAll();

            var albunsDto = mapper.Map<List<AlbumDto>>(albuns);

            return albunsDto ?? [];
        }

        public void Salvar(AlbumDto dto)
        {
            var musica = musicaRepository.GetById(dto.IdMusicaPrincipal) ?? throw new Exception("Não foi possivel localizar a musica principal.");

            var autor = autorRepository.GetById(dto.IdAutorPrincipal) ?? throw new Exception("Não foi possivel localizar o autor principal.");

            List<Musica> musicas = [];
            musicas.Add(musica);

            var album = Album.Criar(dto.Nome, musicas, autor, dto.Capa);

            albumRepository.Save(album);
        }

        public void AdicionarMusica(AdicionarMusicaDto dto)
        {
            var musica = musicaRepository.GetById(dto.IdMusica) ?? throw new Exception("Não foi possivel localizar a musica.");

            var album = albumRepository.GetById(dto.IdAlbum) ?? throw new Exception("Não foi possivel localizar o álbum.");

            album.Musicas.Add(musica);

            albumRepository.Update(album);
        }
    }
}
