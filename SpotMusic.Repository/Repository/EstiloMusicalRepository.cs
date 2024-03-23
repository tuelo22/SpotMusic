using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Repository.Repository
{
    public class EstiloMusicalRepository : RepositoryBase<EstiloMusical>
    {
        public EstiloMusicalRepository(SpotMusicContext context) : base(context) { }
    }
}
