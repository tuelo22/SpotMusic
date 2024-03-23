using SpotMusic.Domain.Conta.Aggregates;

namespace SpotMusic.Repository.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>
    {
        public UsuarioRepository(SpotMusicContext context) : base(context) { }
    }
}
