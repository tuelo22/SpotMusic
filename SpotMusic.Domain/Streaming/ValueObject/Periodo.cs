namespace SpotMusic.Domain.Streaming.ValueObject
{
    public record class Periodo
    {
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }

        public Periodo()
        {

        }

        public static Periodo Criar(DateTime inicio, DateTime? fim)
        {
            if (inicio == null || inicio == DateTime.MinValue)
            {
                throw new Exception("É obrigatório informar a data inicio do periodo");
            }

            if(fim != null)
            {
                ValidaFimPeriodo(inicio, fim.Value);
            }

            return new Periodo()
            {
                Inicio = inicio,
                Fim = fim
            };
        }

        private static void ValidaFimPeriodo(DateTime inicio, DateTime fim)
        {
            if (fim == null || fim == DateTime.MinValue)
            {
                throw new Exception("É obrigatório informar a data fim do periodo");
            }

            if (inicio > fim)
            {
                throw new Exception("A data inicio não pode ser maior que a data fim.");
            }
        }

        public void FinalizaPeriodo(DateTime fim)
        {
            ValidaFimPeriodo(this.Inicio, fim);

            this.Fim = fim;
        }
    }
}
