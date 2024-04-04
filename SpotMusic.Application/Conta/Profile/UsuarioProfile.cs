using SpotMusic.Application.Conta.Dto;
using SpotMusic.Application.Conta.Request;
using SpotMusic.Domain.Conta.Aggregates;
using SpotMusic.Domain.Core.Enum;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Transacao.Aggregates;

namespace SpotMusic.Application.Conta.Profile
{
    public class UsuarioProfile : AutoMapper.Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Plano, PlanoDto>().AfterMap((s, d) =>
            {
                d.Valor = s.Valor.Valor;
            });

            CreateMap<UsuarioDto, Usuario>();

            CreateMap<Usuario, UsuarioDto>()
                .AfterMap((s, d) =>
                {
                    var plano = s.Assinaturas.FirstOrDefault(x => x.Status == TipoStatus.Ativo)?.Plano;

                    if (plano != null)
                        d.PlanoId = plano.Id;

                    d.Senha = string.Empty;
                })
                .ReverseMap();

            CreateMap<CartaoDto, Cartao>()
                .AfterMap((s, d) =>
                {
                    s.CVV = null;
                    s.Estado = d.EnderecoCobranca.Estado;
                    s.Cidade = d.EnderecoCobranca.Cidade;
                    s.Rua = d.EnderecoCobranca.Rua;
                    s.NumeroEndereco = d.EnderecoCobranca.Numero;
                    s.CEP = d.EnderecoCobranca.CEP;
                    s.Complemento = d.EnderecoCobranca.Complemento;
                });
        }
    }
}
