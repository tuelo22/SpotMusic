namespace SpotMusic.Domain.Streaming.Aggregates
{
    public class Autor
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public List<Musica> Musicas { get; set; } = new List<Musica>();

        public static Autor Criar(String Nome)
        {
            if (String.IsNullOrEmpty(Nome)) throw new Exception("E obrigatorio informar o nome.");

            return new Autor { Nome = Nome };
        }
    }
}
