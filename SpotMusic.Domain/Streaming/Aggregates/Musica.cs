using SpotMusic.Domain.Streaming.ValueObject;

namespace SpotMusic.Domain.Streaming.Aggregates
{
    public class Musica
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Duracao Duracao { get; set; }
        public String Letra { get; set; }
        public EstiloMusical EstiloMusical { get; set; }
        public List<Autor> Autores { get; set; } = new List<Autor>();
        public List<Interprete> Interpretes { get; set; } = new List<Interprete>();
        public List<Playlist> Playlists { get; set; } = new List<Playlist>();

        public void AdicionarAutor(Autor autor) => this.Autores.Add(autor);
        public void AdicionarAutor(List<Autor> autores) => this.Autores.AddRange(autores);

        public void AdicionarInterprete(Interprete interprete) => this.Interpretes.Add(interprete);
        public void AdicionarInterprete(List<Interprete> interpretes) => this.Interpretes.AddRange(interpretes);

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

            musica.AdicionarAutor(autores);

            return musica;
        }
    }
}
