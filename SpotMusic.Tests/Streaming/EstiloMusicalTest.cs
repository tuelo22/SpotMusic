using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Tests.Streaming
{
    public class EstiloMusicalTest
    {
        [Fact]
        public void DeveCriarComSucesso()
        {
            var nome = "Samba";

            var estilo = EstiloMusical.Criar(nome);

            Assert.Equal(estilo.Nome, nome);
        }
        [Fact]
        public void NaoDeveCriarSemNome()
        {
            Assert.Throws<Exception>(() =>
            {
                var estilo = EstiloMusical.Criar("");
            });
        }
    }
}
