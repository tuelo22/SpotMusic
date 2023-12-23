using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Tests.Streaming
{
    public class InterpreteTest
    {
        [Fact]
        public void DeveCriarComSucesso()
        {
            var nome = "Ricardo Nunes";

            var interprete = Interprete.Criar(nome);

            Assert.Equal(interprete.Nome, nome);
        }
        [Fact]
        public void NaoDeveCriarSemNome()
        {
            Assert.Throws<Exception>(() =>
            {
                var interprete = Interprete.Criar("");
            });
        }
    }
}
