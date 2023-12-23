namespace SpotMusic.Domain.Streaming.Aggregates
{
    public class EstiloMusical
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }

        public static EstiloMusical Criar(String Nome)
        {
            if (String.IsNullOrEmpty(Nome)) throw new Exception("E obrigatorio informar o nome.");

            return new EstiloMusical { Nome = Nome };
        }
    }
}

