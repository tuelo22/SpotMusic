using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Repository.Repository
{
    public class AlbumRepository : RepositoryBase<Album>
    {
        public AlbumRepository(SpotMusicContext context) : base(context) { }
    }
}
