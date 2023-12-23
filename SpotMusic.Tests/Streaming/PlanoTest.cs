using SpotMusic.Domain.Core.ValueObject;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Streaming.ValueObject;

namespace SpotMusic.Tests.Streaming
{
    public class PlanoTest
    {
        [Fact]
        public void DeveCriarPlanoComSucesso()
        {
            var vigencia = Periodo.Criar(DateTime.Now, DateTime.Now.AddDays(30));
            var nome = "Plano";
            Monetario valor = 100;
            var descricao = "Descricao";

            var plano = Plano.Criar(nome, descricao, valor, vigencia);

            Assert.Equal(vigencia, plano.Vigencia);
            Assert.Equal(nome, plano.Nome);
            Assert.Equal(valor, plano.Valor);
            Assert.Equal(descricao, descricao);
        }

        [Fact]
        public void NaoDeveCriarComNomeVazio()
        {
            var vigencia = Periodo.Criar(DateTime.Now, DateTime.Now.AddDays(30));
            var nome = "";
            decimal valor = 40;
            var descricao = "Descricao";

            //Act
            Assert.Throws<Exception>(() =>
            {
                var plano = Plano.Criar(nome, descricao, valor, vigencia);
            });
        }
    }
}
