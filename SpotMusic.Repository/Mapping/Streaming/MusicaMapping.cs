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
            builder.HasOne(x => x.EstiloMusical).WithMany();

            builder
                .HasMany(x => x.Autores)
                .WithMany(y => y.Musicas)
                .UsingEntity(
                    "MusicaAutor",
                    l => l.HasOne(typeof(Autor)).WithMany().HasForeignKey("AutorId").HasPrincipalKey(nameof(Autor.Id)),
                    r => r.HasOne(typeof(Musica)).WithMany().HasForeignKey("MusicaId").HasPrincipalKey(nameof(Musica.Id)),
                    j => j.HasKey("MusicaId", "AutorId"));

            builder
                .HasMany(x => x.Albuns)
                .WithMany(y => y.Musicas)
                .UsingEntity(
                    "MusicaAlbum",
                    l => l.HasOne(typeof(Album)).WithMany().HasForeignKey("AlbumId").HasPrincipalKey(nameof(Album.Id)),
                    r => r.HasOne(typeof(Musica)).WithMany().HasForeignKey("MusicaId").HasPrincipalKey(nameof(Musica.Id)),
                    j => j.HasKey("MusicaId", "AlbumId"));

            builder
                .HasMany(x => x.Interpretes)
                .WithMany(y => y.Musicas)
                .UsingEntity(
                    "MusicaInterprete",
                    l => l.HasOne(typeof(Interprete)).WithMany().HasForeignKey("InterpreteId").HasPrincipalKey(nameof(Interprete.Id)),
                    r => r.HasOne(typeof(Musica)).WithMany().HasForeignKey("MusicaId").HasPrincipalKey(nameof(Musica.Id)),
                    j => j.HasKey("MusicaId", "InterpreteId"));

            builder
            .HasMany(x => x.Playlists)
            .WithMany(y => y.Musicas)
            .UsingEntity(
                "MusicaPlaylist",
                l => l.HasOne(typeof(Playlist)).WithMany().HasForeignKey("PlaylistId").HasPrincipalKey(nameof(Playlist.Id)),
                r => r.HasOne(typeof(Musica)).WithMany().HasForeignKey("MusicaId").HasPrincipalKey(nameof(Musica.Id)),
                j => j.HasKey("MusicaId", "PlaylistId"));
        }
    }
}
