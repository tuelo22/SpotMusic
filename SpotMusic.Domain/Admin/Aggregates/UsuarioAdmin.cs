using SpotMusic.Domain.Admin.Enum;

namespace SpotMusic.Domain.Admin.Aggregates
{
    public class UsuarioAdmin
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Email { get; set; }
        public String Senha { get; set; }
        public Perfil Perfil { get; set; }
    }
}
