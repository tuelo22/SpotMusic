using System.ComponentModel.DataAnnotations;

namespace SpotMusic.Admin.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Campo email é obrigatório.")]
        [EmailAddress]
        public String Email { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório.")]
        public String Senha { get; set; }
    }
}
