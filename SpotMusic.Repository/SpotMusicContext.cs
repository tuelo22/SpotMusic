using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotMusic.Domain.Conta.Aggregates;
using SpotMusic.Domain.Notificacao.Aggregates;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Transacao.Aggregates;

namespace SpotMusic.Repository
{
    public class SpotMusicContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Assinatura> Assinaturas { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Notificacao> Notificacoes { get; set; }
        public DbSet<Cartao> Cartoes { get; set; }
        public DbSet<Transacao> Transacao { get; set; }
        public DbSet<Interprete> Interpretes { get; set; }
        public DbSet<EstiloMusical> EstilosMusicais { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Album> Albuns { get; set; }
        public DbSet<Musica> Musicas { get; set; }
        public DbSet<Plano> Planos { get; set; }

        public SpotMusicContext(DbContextOptions<SpotMusicContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpotMusicContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
