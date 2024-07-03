using System.ComponentModel.DataAnnotations;

namespace SpotMusic.Application.Streaming.Dto
{
    public class AutorDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo descrição é obrigatório.")]
        public String? Descricao { get; set; }

        [Required(ErrorMessage = "Campo url da imagem é obrigatório.")]
        public String? Backdrop { get; set; }
    }
}
