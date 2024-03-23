using SpotMusic.Domain.Streaming.ValueObject;
using System.ComponentModel.DataAnnotations;

namespace SpotMusic.Application.Streaming.Dto
{
    public class AlbumDto
    {
        public Guid Id { get; set; }
        [Required]
        public String Nome { get; set; }
        public String Capa { get; set; }
        public Guid IdAutorPrincipal { get; set; }

        [Required]
        public List<MusicaDto> Musicas { get; set; }
    }

    public class MusicaDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public int Duracao { get; set; }
        [Required]
        public String Letra { get; set; }
        [Required]
        public Guid IdEstiloMusical { get; set; }
        public String NomeEstiloMusical { get; set; }
        [Required]
        public List<AutorDto> Autores { get; set; }
        [Required]
        public List<InterpreteDto> Interpretes { get; set; }
    }

    public class InterpreteDto
    {
        public Guid Id { get; set; }
        [Required]
        public String Nome { get; set; }
    }
}