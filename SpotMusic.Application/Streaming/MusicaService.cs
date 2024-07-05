using AutoMapper;
using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Domain.Conta.Aggregates;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Repository.Repository;

namespace SpotMusic.Application.Streaming
{
    public class MusicaService
    {
        private readonly MusicaRepository musicaRepository;
        private readonly UsuarioRepository usuarioRepository;
        private readonly IMapper mapper;

        public MusicaService(MusicaRepository musicaRepository, UsuarioRepository usuarioRepository, IMapper mapper)
        {
            this.musicaRepository = musicaRepository;
            this.usuarioRepository = usuarioRepository;
            this.mapper = mapper;
        }

        public List<MusicaDto> BuscarMusica(Guid idUsuario, String texto)
        {
            var musicas = musicaRepository.Find(x => x.Nome.Contains(texto) || x.Letra.Contains(texto)).ToList();

            var musicasDto =this.mapper.Map<List<MusicaDto>>(musicas);

            musicasDto.ForEach(musica =>
            {
                musica.favorito = musicas.Any(y => y.Playlists.Any(t => t.Autor.Id == idUsuario) && y.Id == musica.Id);
            });

            return musicasDto ?? [];
        }

        public MusicaDto FavoritarMusica(Guid idUsuario, Guid IdMusica)
        {
            var musica = musicaRepository.GetById(IdMusica);

            if(musica == null)
            {
                throw new Exception("Musica inexistente.");
            }

            var usuario = usuarioRepository.GetById(idUsuario);

            if (usuario == null)
            {
                throw new Exception("Usuario inexistente.");
            }

            var playlist = usuario.Playlists.FirstOrDefault(x => x.TipoPlayList == Domain.Streaming.Enum.TipoPlayList.Favorita);

            if (playlist == null)
            {
                throw new Exception("Falha ao localizar os favoritos do usuário.");
            }

            if (musica.Playlists.Any(x => x.Id == playlist.Id))
            {
                musica.RemoverPlayList(playlist);
            }
            else
            {
                musica.AdicionarPlayList(playlist);
            }

            musicaRepository.Update(musica);

            return this.mapper.Map<MusicaDto>(musica);
        }

        public List<MusicaDto> favoritas(Guid idUsuario)
        {
            var usuario = usuarioRepository.GetById(idUsuario);

            if (usuario == null)
            {
                throw new Exception("Usuario inexistente.");
            }

            var playlist = usuario.Playlists.FirstOrDefault(x => x.TipoPlayList == Domain.Streaming.Enum.TipoPlayList.Favorita);

            if (playlist == null)
            {
                throw new Exception("Falha ao localizar os favoritos do usuário.");
            }

            var musicas = this.mapper.Map<List<MusicaDto>>(playlist.Musicas);

            musicas.ForEach(x => x.favorito = true);

            return musicas;
        }

        public List<MusicaDto> ObterMusicas(Guid IdAutor)
        {
            var musicas = musicaRepository.Find(x => x.Autores.Any(x => x.Id == IdAutor)).ToList();

            var musicasDto = this.mapper.Map<List<MusicaDto>>(musicas);

            return musicasDto ?? [];
        }
    }
}
