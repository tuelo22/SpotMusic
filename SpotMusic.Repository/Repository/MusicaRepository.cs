using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Repository.Repository
{
    public class MusicaRepository : RepositoryBase<Musica>
    {
        public MusicaRepository(SpotMusicContext context) : base(context) { }
    }
}
