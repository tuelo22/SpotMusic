using System.ComponentModel.DataAnnotations;

namespace SpotMusic.Application.Streaming.Dto
{
    public class AdicionarMusicaDto
    {
        [Required(ErrorMessage = "Campo álbum é obrigatório.")]
        public Guid IdAutor { get; set; }

        [Required(ErrorMessage = "Campo álbum é obrigatório.")]
        public Guid IdAlbum { get; set; }

        [Required(ErrorMessage = "Campo música é obrigatório.")]
        public Guid IdMusica { get; set; }
    }
}
