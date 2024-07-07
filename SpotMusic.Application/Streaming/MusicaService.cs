using AutoMapper;
using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Repository.Repository;

namespace SpotMusic.Application.Streaming
{
    public class MusicaService(
        MusicaRepository musicaRepository, 
        UsuarioRepository usuarioRepository, 
        EstiloMusicalRepository estiloMusicalRepository,
        AutorRepository autorRepository,
        IMapper mapper)
    {
        public List<MusicaDto> BuscarMusica(Guid idUsuario, String texto)
        {
            var musicas = musicaRepository.Find(x => x.Nome.Contains(texto) || x.Letra.Contains(texto)).ToList();

            var musicasDto = mapper.Map<List<MusicaDto>>(musicas);

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

            return mapper.Map<MusicaDto>(musica);
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

            var musicas = mapper.Map<List<MusicaDto>>(playlist.Musicas);

            musicas.ForEach(x => x.favorito = true);

            return musicas;
        }

        public List<MusicaDto> ObterMusicas(Guid IdAutor)
        {
            var musicas = musicaRepository.Find(x => x.Autores.Any(x => x.Id == IdAutor)).ToList();

            var musicasDto = mapper.Map<List<MusicaDto>>(musicas);

            return musicasDto ?? [];
        }

        public void Salvar(MusicaDto dto)
        {
            var estilo = estiloMusicalRepository.GetById(dto.IdEstiloMusical) ?? throw new Exception("Não foi possivel localizar o estilo musical.");
            List<Autor> autores = [];

            var autor = autorRepository.GetById(dto.IdAutor) ?? throw new Exception("Não foi possivel localizar o autor.");
            autores.Add(autor);

            var musica = Musica.Criar(dto.Nome, dto.Letra, estilo, autores);

            musicaRepository.Save(musica);
        }

        public List<MusicaDto> ObterMusicasSemAlbum(Guid IdAutor)
        {
            var musicas = musicaRepository.Find(x => x.Autores.Any(x => x.Id == IdAutor) && x.Albuns.Count == 0).ToList();

            var musicasDto = mapper.Map<List<MusicaDto>>(musicas);

            return musicasDto ?? [];
        }
    }
}
