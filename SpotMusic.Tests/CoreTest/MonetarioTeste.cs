using SpotMusic.Domain.Core.ValueObject;

namespace SpotMusic.Tests.CoreTest
{
    public class MonetarioTeste
    {
        [Fact]
        public void NaoDeveCriarMonetarioComValorNegativo()
        {
            Assert.Throws<Exception>(() =>
            {
                Monetario monetario = new Monetario(-1);
            });            
        }
    }
}
