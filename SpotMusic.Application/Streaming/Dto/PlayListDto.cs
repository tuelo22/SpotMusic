using SpotMusic.Application.Conta.Request;
using SpotMusic.Domain.Streaming.Enum;

namespace SpotMusic.Application.Streaming.Dto
{
    public class PlayListDto
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public TipoPlayList TipoPlayList { get; set; }
        public UsuarioDto Autor { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Publica { get; set; }
        public List<MusicaDto> Musicas { get; set; }
    }
}
