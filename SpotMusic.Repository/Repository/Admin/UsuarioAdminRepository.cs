using SpotMusic.Domain.Conta.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotMusic.Repository.Repository.Admin
{
    public class UsuarioAdminRepository : RepositoryBase<Usuario>
    {
        public UsuarioAdminRepository(SpotMusicContext context) : base(context) { }
    }
}
