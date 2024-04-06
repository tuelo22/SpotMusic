using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Application.Streaming.Profile
{
    public class PlayListProfile : AutoMapper.Profile
    {
        public PlayListProfile()
        {
            CreateMap<Playlist, PlayListDto>();
        }
    }
}
