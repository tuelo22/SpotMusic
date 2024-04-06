﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Repository.Mapping.Streaming
{
    public class PlaylistMapping : IEntityTypeConfiguration<Playlist>

    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
        {
            builder.ToTable(nameof(Playlist));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Publica).IsRequired();
            builder.Property(x => x.DataCriacao).IsRequired();
            builder.Property(x => x.TipoPlayList);

            //builder
            //    .HasMany(x => x.Musicas)
            //    .WithMany(y => y.Playlists)
            //    .UsingEntity(
            //        "PlaylistMusica",
            //        r => r.HasOne(typeof(Playlist)).WithMany().HasForeignKey("PlaylistId").HasPrincipalKey(nameof(Playlist.Id)),
            //        l => l.HasOne(typeof(Musica)).WithMany().HasForeignKey("MusicaId").HasPrincipalKey(nameof(Musica.Id)),

            //        j => j.HasKey("PlaylistId", "MusicaId"));
        }
    }
}
