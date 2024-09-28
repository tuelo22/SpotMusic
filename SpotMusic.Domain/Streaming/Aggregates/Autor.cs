using Newtonsoft.Json;

namespace SpotMusic.Domain.Streaming.Aggregates
{
    public class Autor
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("nome")]
        public String Nome { get; set; }

        [JsonProperty("descricao")]
        public String? Descricao { get; set; }

        [JsonProperty("backdrop")]
        public String? Backdrop { get; set; }

        [JsonProperty("autorKey")]
        public string AutorKey = "autor-partition";

        [JsonProperty("musicas")]
        public virtual IList<Musica> Musicas { get; set; } = [];

        public static Autor Criar(String Nome, String? Descricao = null, String? Backdrop = null)
        {
            if (String.IsNullOrEmpty(Nome)) throw new Exception("E obrigatorio informar o nome.");

            return new Autor { Id =  Guid.NewGuid(), Nome = Nome, Descricao = Descricao, Backdrop = Backdrop };
        }
    }
}
