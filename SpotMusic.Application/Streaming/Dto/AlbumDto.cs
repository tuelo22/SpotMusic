using System.ComponentModel.DataAnnotations;

namespace SpotMusic.Application.Streaming.Dto
{
    public class AlbumDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo nome é obrigatório.")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo capa é obrigatório.")]
        public String Capa { get; set; }

        [Required(ErrorMessage = "Campo autor é obrigatório.")]
        public Guid IdAutorPrincipal { get; set; }
        public String? NomeAutorPrincipal { get; set; }

        [Required(ErrorMessage = "Campo musica principal é obrigatório.")]
        public Guid IdMusicaPrincipal { get; set; }

        public List<MusicaDto> Musicas { get; set; } = [];

        public String? MusicasTexto { get; set; }
    }
}