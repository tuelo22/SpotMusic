using SpotMusic.Domain.Streaming.ValueObject;

namespace SpotMusic.Tests.Streaming
{
    public class PeriodoTest
    {
        [Fact]
        public void DeveCriarPeriodoComSucesso()
        {
            var Data = DateTime.Now;
            Periodo periodo = Periodo.Criar(Data, null);

            Assert.Equal(Data, periodo.Inicio);
            Assert.Null(periodo.Fim);
        }

        [Fact]
        public void DeveFinalizarPeriodoComSucesso()
        {
            var Inicio = DateTime.Now;
            var Fim = Inicio.AddDays(30);
            Periodo periodo = Periodo.Criar(Inicio, null);
            periodo.FinalizaPeriodo(Fim);

            Assert.Equal(Inicio, periodo.Inicio);
            Assert.Equal(Fim, periodo.Fim);
        }

        [Fact]
        public void NaoDeveCriarPeriodoComFimMenorQueInicio()
        {
            var Inicio = DateTime.Now;
            var Fim = DateTime.Now.AddDays(-30);

            Assert.Throws<Exception>(() =>
            {
                Periodo periodo = Periodo.Criar(Inicio, Fim);
            });
        }

        [Fact]
        public void NaoDeveCriarPeriodoComInicioVazio()
        {
            DateTime Inicio = DateTime.MinValue;
            var Fim = DateTime.Now.AddDays(30);

            Assert.Throws<Exception>(() =>
            {
                Periodo periodo = Periodo.Criar(Inicio, Fim);
            });
        }
    }
}
