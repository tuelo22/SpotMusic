using SpotMusic.Domain.Admin.Aggregates;

namespace SpotMusic.Repository.Repository.Admin
{
    public class UsuarioAdminRepository : RepositoryBase<UsuarioAdmin>
    {
        public UsuarioAdminRepository(SpotMusicAdminContext context) : base(context) { }
    }
}
