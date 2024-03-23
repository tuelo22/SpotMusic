using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Application.Streaming.Profile
{
    internal class AlbumProfile : AutoMapper.Profile
    {
        public AlbumProfile()
        {
            CreateMap<Interprete, InterpreteDto>()
                .ReverseMap();

            CreateMap<Musica, MusicaDto>()
                .ForMember(d => d.IdEstiloMusical, x => x.MapFrom(x => x.EstiloMusical.Id))
                .ForMember(d => d.NomeEstiloMusical, x => x.MapFrom(x => x.EstiloMusical.Nome))
                .ForMember(d => d.Duracao, x => x.MapFrom(x => x.Duracao.Valor))
                .ReverseMap();

            CreateMap<AlbumDto, Album>()
                .ForMember(d => d.AutorPrincipal.Id, x => x.MapFrom(x => x.IdAutorPrincipal))
                .ReverseMap();
        }
    }
}
