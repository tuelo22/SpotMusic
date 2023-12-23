namespace SpotMusic.Domain.Streaming.Aggregates
{
    public class Interprete
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }

        public static Interprete Criar(String Nome)
        {
            if (String.IsNullOrEmpty(Nome)) throw new Exception("E obrigatorio informar o nome.");

            return new Interprete { Nome = Nome };
        }
    }
}
