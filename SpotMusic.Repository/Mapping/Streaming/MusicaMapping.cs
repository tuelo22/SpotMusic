using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Streaming.ValueObject;

namespace SpotMusic.Repository.Mapping.Streaming
{
    public class MusicaMapping : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.ToTable(nameof(Musica));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Letra).HasMaxLength(1080);
            builder.OwnsOne<Duracao>(d => d.Duracao, c =>
            {
                c.Property(x => x.Valor).IsRequired().HasMaxLength(50);
            });
            builder.HasOne(x => x.EstiloMusical).WithMany();
            builder.HasMany(x => x.Interpretes).WithOne().OnDelete(DeleteBehavior.Cascade);
            builder
                .HasMany(x => x.Autores)
                .WithMany(y => y.Musicas)
                .UsingEntity(
                    "MusicaAutor",
                    l => l.HasOne(typeof(Autor)).WithMany().HasForeignKey("AutorId").HasPrincipalKey(nameof(Autor.Id)),
                    r => r.HasOne(typeof(Musica)).WithMany().HasForeignKey("MusicaId").HasPrincipalKey(nameof(Musica.Id)),
                    j => j.HasKey("MusicaId", "AutorId"));                   
        }
    }
}
