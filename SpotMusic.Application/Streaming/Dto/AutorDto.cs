using System.ComponentModel.DataAnnotations;

namespace SpotMusic.Application.Streaming.Dto
{
    public class AutorDto
    {
        public Guid Id { get; set; }

        [Required]
        public String Nome { get; set; }

        [Required]
        public String? Descricao { get; set; }
        public String? Backdrop { get; set; }
    }
}
