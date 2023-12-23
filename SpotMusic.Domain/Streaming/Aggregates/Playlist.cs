using SpotMusic.Domain.Conta.Aggregates;
using SpotMusic.Domain.Streaming.Enum;

namespace SpotMusic.Domain.Streaming.Aggregates
{
    public class Playlist
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public TipoPlayList TipoPlayList { get; set; }
        public Usuario Autor { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Publica { get; set; }
        public List<Musica> Musicas { get; set; } = new List<Musica>();

        public static Playlist Criar(String Nome, TipoPlayList tipo, Usuario autor, bool publica)
        {
            if (String.IsNullOrEmpty(Nome)) throw new Exception("E obrigatorio informar o nome.");

            return new Playlist 
            { 
                Nome = Nome,
                TipoPlayList = tipo,
                Autor = autor,
                Publica = publica,
                DataCriacao = DateTime.Now,
            };
        }
    }
}
