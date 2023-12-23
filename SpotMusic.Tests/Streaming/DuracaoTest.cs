using SpotMusic.Domain.Streaming.ValueObject;

namespace SpotMusic.Tests.Streaming
{
    public class DuracaoTest
    {
        [Fact]
        public void NaoDeveCriarDuracaoComValorNegativo()
        {
            Assert.Throws<Exception>(() =>
            {
                var monetario = new Duracao(-1);
            });
        }
    }
}
