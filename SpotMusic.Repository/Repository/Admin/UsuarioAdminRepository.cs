using SpotMusic.Domain.Admin.Aggregates;
using SpotMusic.Domain.Extensions;
using System.Security.AccessControl;

namespace SpotMusic.Repository.Repository.Admin
{
    public class UsuarioAdminRepository : RepositoryBase<UsuarioAdmin>
    {
        public UsuarioAdminRepository(SpotMusicAdminContext context) : base(context) { }

        public UsuarioAdmin? GetByEmailSenha(String Email, String Senha)
        {
            return this.Find(x => x.Email == Email && x.Senha == Senha).FirstOrDefault();
        }
    }

}
