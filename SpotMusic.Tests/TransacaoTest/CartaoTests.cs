using SpotMusic.Domain.Core.Enum;
using SpotMusic.Domain.Transacao.Aggregates;
using SpotMusic.Domain.Transacao.ValueObject;

namespace SpotMusic.Tests.TransacaoTest
{
    public class CartaoTests
    {
        [Fact]
        public void DeveCriarTransacaoComSucesso()
        {
            Cartao cartao = new()
            {
                Id = Guid.NewGuid(),
                Status = TipoStatus.Ativo,
                Limite = 10000M,
                Numero = "54654654564654",
                EnderecoCobranca = Endereco.Criar("Rio de Janeiro", "Rio de Janeiro", "Rua dos bobos", "0", null)
            };

            var merchant = new Merchant("Oi oi oi");

            cartao.CriarTransacao(merchant, 500, "Teste");

            Assert.True(cartao.Transacoes.Count > 0);
        }
        [Fact]
        public void NaoDeveCriarTransacaoComCartaoInativo()
        {
            Cartao cartao = new Cartao()
            {
                Id = Guid.NewGuid(),
                Status = TipoStatus.Inativo,
                Limite = 10000M,
                Numero = "54654654564654",
                EnderecoCobranca = Endereco.Criar("Rio de Janeiro", "Rio de Janeiro", "Rua dos bobos", "0", null)
            };

            var merchant = new Merchant("Oi oi oi");

            Assert.Throws<Exception>(() => cartao.CriarTransacao(merchant, 500, "Teste"));
        }
    }
}