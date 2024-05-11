using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SpotMusic.Domain.Admin.Aggregates;
using SpotMusic.Repository.Mapping.Admin;

namespace SpotMusic.Repository
{
    public class SpotMusicAdminContext : DbContext
    {
        public DbSet<UsuarioAdmin> UsuariosAdmin { get; set; }

        public SpotMusicAdminContext(DbContextOptions<SpotMusicAdminContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioAdminMapping());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(x => x.AddConsole()));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
