using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Application.Streaming.Profile
{
    public class AlbumProfile : AutoMapper.Profile
    {
        public AlbumProfile()
        {
            CreateMap<Musica, MusicaDto>()
                .AfterMap((s, d) =>
                {
                    d.IdEstiloMusical = s.EstiloMusical.Id;
                    d.NomeEstiloMusical = s.EstiloMusical.Nome;
                    d.Autores = String.Empty;

                    foreach (var item in s.Autores)
                    {
                        var simbolo = s.Autores.IndexOf(item) == 0 ? String.Empty : " / ";

                        d.Autores += simbolo + item.Nome.Trim(); 
                    }

                    d.IdAutor = s.Autores.FirstOrDefault()?.Id ?? Guid.Empty;

                    d.Album = s.Albuns.FirstOrDefault()?.Nome ?? String.Empty;                    
                });

            CreateMap<Album, AlbumDto>()
                .AfterMap((s, d) =>
                {
                    d.IdAutorPrincipal = s.AutorPrincipal.Id;
                    d.NomeAutorPrincipal = s.AutorPrincipal.Nome;
                    d.IdMusicaPrincipal = s.Musicas.FirstOrDefault()?.Id ?? Guid.Empty;

                    d.MusicasTexto = string.Empty;

                    foreach (var item in s.Musicas)
                    {
                        var simbolo = s.Musicas.IndexOf(item) == 0 ? String.Empty : " / ";

                        d.MusicasTexto += simbolo + item.Nome.Trim();
                    }
                });
        }
    }
}
