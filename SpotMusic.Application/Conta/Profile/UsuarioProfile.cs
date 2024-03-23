using SpotMusic.Application.Conta.Request;
using SpotMusic.Domain.Conta.Aggregates;
using SpotMusic.Domain.Core.Enum;
using SpotMusic.Domain.Transacao.Aggregates;

namespace SpotMusic.Application.Conta.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioDto, Usuario>();

            CreateMap<Usuario, UsuarioDto>()
                .AfterMap((s, d) =>
                {
                    var plano = s.Assinaturas.FirstOrDefault(x => x.Status == TipoStatus.Ativo)?.Plano;

                    if (plano != null)
                        d.PlanoId = plano.Id;
                })
                .ReverseMap();

            CreateMap<CartaoDto, Cartao>()
                .ForPath(x => x.Limite.Valor, m => m.MapFrom(f => f.Limite))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => Enum.Parse<TipoStatus>(s.Status)))
                .ReverseMap();
        }
    }
}
