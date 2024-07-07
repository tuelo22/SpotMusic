using System.ComponentModel.DataAnnotations;

namespace SpotMusic.Application.Streaming.Dto
{
    public class MusicaDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Campo duração é obrigatório.")]
        public int Duracao { get; set; }
        
        [Required(ErrorMessage = "Campo letra é obrigatório.")]
        public String Letra { get; set; }
        
        [Required(ErrorMessage = "Campo estilo musical é obrigatório.")]
        public Guid IdEstiloMusical { get; set; }

        public Boolean favorito { get; set; }

        public String? NomeEstiloMusical { get; set; }

        public String? Autores { get; set; }

        [Required(ErrorMessage = "Campo autor é obrigatório.")]
        public Guid IdAutor { get; set; }

        public String? Album { get; set; }
    }
}
