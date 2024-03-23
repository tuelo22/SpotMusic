using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Application.Streaming.Profile
{
    public class AutorProfile : AutoMapper.Profile
    {
        public AutorProfile()
        {
            CreateMap<AutorDto, Autor>().ReverseMap();
        }
    }
}
