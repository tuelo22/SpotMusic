using SpotMusic.Application.Conta.Request;
using SpotMusic.Domain.Transacao.Aggregates;
using SpotMusic.Domain.Transacao.ValueObject;

namespace SpotMusic.Application.Conta
{
    public class CartaoService
    {
        public Cartao ConsultarCartaoAtivo(CartaoDto cartaoDto)
        {
            Endereco enderecoCobranca = Endereco.Criar(cartaoDto.Estado, cartaoDto.Cidade, cartaoDto.Rua, 
                cartaoDto.NumeroEndereco,cartaoDto.CEP, cartaoDto.Complemento);

            return new()
            {
                EnderecoCobranca = enderecoCobranca,
                Limite = 500,
                Status = Domain.Core.Enum.TipoStatus.Ativo,
                Numero = cartaoDto.Numero,
                CVV = cartaoDto.CVV?? string.Empty
            };
        }
    }
}
