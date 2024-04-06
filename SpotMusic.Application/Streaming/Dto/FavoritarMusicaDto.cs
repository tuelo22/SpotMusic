using System.ComponentModel.DataAnnotations;

namespace SpotMusic.Application.Streaming.Dto
{
    public class FavoritarMusicaDto
    {
        [Required]
        public Guid MusicaId { get; set; }
        [Required]
        public Guid UsuarioId { get; set; }
    }
}
