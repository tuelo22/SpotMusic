using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SpotMusic.Application.Conta.Request
{
    public struct UsuarioDto
    {
        public Guid Id { get; set; }
        [Required]
        public String Nome { get; set; }
        [Required]
        public String Senha { get; set; }
        [Required]
        [EmailAddress]
        public String Email { get; set; }
        [Required]
        public String Telefone { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        public Guid PlanoId { get; set; }
        [Required]
        public CartaoDto Cartao { get; set; }
    }
}
