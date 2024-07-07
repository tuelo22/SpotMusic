using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Application.Streaming.Profile
{
    public class EstiloMusicalProfile : AutoMapper.Profile
    {
        public EstiloMusicalProfile()
        {
            CreateMap<EstiloMusical, EstiloMusicalDto>();
        }
    }
}
