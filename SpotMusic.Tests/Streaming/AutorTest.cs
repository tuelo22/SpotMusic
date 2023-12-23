using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Tests.Streaming
{
    public class AutorTest
    {
        [Fact]
        public void DeveCriarComSucesso()
        {
            var nome = "Sofrimento";

            var autor = Autor.Criar(nome);

            Assert.Equal(autor.Nome, nome);
        }
        [Fact]
        public void NaoDeveCriarSemNome()
        {
            Assert.Throws<Exception>(() =>
            {
                var autor = Autor.Criar("");
            });
        }
    }
}
