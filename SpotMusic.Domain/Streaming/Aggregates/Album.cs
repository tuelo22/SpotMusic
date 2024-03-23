namespace SpotMusic.Domain.Streaming.Aggregates
{
    public class Album
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public string? Capa { get; set; }
        public virtual Autor AutorPrincipal { get; set; }
        public virtual IList<Musica> Musicas { get; set; } = [];
       
        public static Album Criar(String nome, List<Musica> musicas, Autor autorPrincipal, String? capa = null)
        {
            if (String.IsNullOrEmpty(nome)) throw new Exception("E obrigatorio informar o nome do album.");

            if (musicas == null || musicas.Count == 0) throw new Exception("E obrigatorio informar ao menos uma musica ao album.");

            return new Album { Nome = nome, AutorPrincipal = autorPrincipal, Capa = capa };
        }
    }
}
