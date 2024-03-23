using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Repository.Repository
{
    public class PlanoRepository : RepositoryBase<Plano>
    {
        public PlanoRepository(SpotMusicContext context) : base(context) { }
    }
}
