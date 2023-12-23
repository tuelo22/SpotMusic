namespace SpotMusic.Domain.Streaming.Aggregates
{
    public class Album
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public List<Musica> Musicas { get; set; } = new List<Musica>();
       
        public void AdicionarMusica(Musica musica) => this.Musicas.Add(musica);
        public void AdicionarMusica(List<Musica> musicas) => this.Musicas.AddRange(musicas);

        public static Album Criar(String nome, List<Musica> musicas)
        {
            if (String.IsNullOrEmpty(nome)) throw new Exception("E obrigatorio informar o nome do album.");

            if (musicas == null || musicas.Count == 0) throw new Exception("E obrigatorio informar ao menos uma musica ao album.");

            return new Album { Nome = nome };
        }
    }
}
