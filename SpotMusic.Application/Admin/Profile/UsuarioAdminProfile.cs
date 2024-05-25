using SpotMusic.Application.Admin.Dto;
using SpotMusic.Domain.Admin.Aggregates;
using SpotMusic.Domain.Admin.Enum;

namespace SpotMusic.Application.Admin.Profile
{
    public class UsuarioAdminProfile : AutoMapper.Profile
    {
        public UsuarioAdminProfile()
        {
            CreateMap<UsuarioAdminDto, UsuarioAdmin>()
                .ForMember(x => x.Perfil, m => m.MapFrom(f => (Perfil)f.Perfil))
                .ReverseMap();
        }
    }
}
