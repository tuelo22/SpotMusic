using System.ComponentModel.DataAnnotations;

namespace SpotMusic.Api.Controllers.Request
{
    public class LoginRequeste
    {
        [Required(ErrorMessage ="É obrigatório infromar o email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É obrigatório infromar a senha.")]
        public string Senha { get; set; }
    }
}
