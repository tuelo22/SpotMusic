using SpotMusic.Domain.Conta.Aggregates;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Streaming.ValueObject;

namespace SpotMusic.Tests.ContaTest
{
    public class AssinaturaTest
    {
        [Fact]
        public void DeveCriarAssinaturaComSucesso()
        {
            var plano = Plano.Criar("Infalivel", "Mas nem tanto", 40, Periodo.Criar(DateTime.Now, null));
            plano.Id = Guid.NewGuid();
            var dataInicio = Convert.ToDateTime("21/11/2023");

            var assinatura = Assinatura.Criar(plano, dataInicio);

            Assert.Equal(plano.Id, assinatura.Plano.Id);
            Assert.Equal(dataInicio, assinatura.Vigencia.Inicio);
            Assert.Equal(dataInicio.AddDays(30), assinatura.Vigencia.Fim);
        }

        [Fact]
        public void NaoDeveCriarAssinaturaComPlanoInativo()
        {
            var plano = Plano.Criar("Infalivel", "Mas nem tanto", 40, Periodo.Criar(DateTime.Now, null));
            plano.Status = Domain.Core.Enum.TipoStatus.Inativo;
            plano.Id = Guid.NewGuid();
            
            var dataInicio = Convert.ToDateTime("21/11/2023");

            Assert.Throws<Exception>(() =>
            {
                var assinatura = Assinatura.Criar(plano, dataInicio);
            });
        }
    }
}
