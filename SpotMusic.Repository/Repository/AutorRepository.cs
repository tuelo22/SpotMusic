using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Repository.Repository
{
    public class AutorRepository : RepositoryBase<Autor>
    {
        public AutorRepository(SpotMusicContext context) : base(context) { }
    }
}
