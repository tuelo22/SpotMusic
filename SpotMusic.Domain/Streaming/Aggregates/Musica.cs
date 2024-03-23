using SpotMusic.Domain.Streaming.ValueObject;

namespace SpotMusic.Domain.Streaming.Aggregates
{
    public class Musica
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required Duracao Duracao { get; set; }
        public required String Letra { get; set; }
        public virtual EstiloMusical EstiloMusical { get; set; }
        public virtual IList<Autor> Autores { get; set; } = [];
        public virtual IList<Interprete> Interpretes { get; set; } = [];
        public virtual IList<Playlist> Playlists { get; set; } = [];

        public void AdicionarAutor(Autor autor) => this.Autores.Add(autor);

        public void AdicionarInterprete(Interprete interprete) => this.Interpretes.Add(interprete);

        public static Musica Criar(String nome, Duracao duracao,
            String letra, EstiloMusical estilo, List<Autor> autores)
        {
            if (String.IsNullOrEmpty(nome)) throw new Exception("E obrigatorio informar o nome da musica");
            if (autores == null || autores.Count == 0) throw new Exception("E obrigatorio informar ao menos um autor.");

            var musica = new Musica()
            {
                Nome = nome,
                Duracao = duracao,
                Letra = letra,
                EstiloMusical = estilo,
            };

            autores.ForEach(x => musica.AdicionarAutor(x));

            return musica;
        }
    }
}
