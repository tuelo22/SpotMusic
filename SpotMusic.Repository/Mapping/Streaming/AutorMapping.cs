using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Repository.Mapping.Streaming
{
    public class AutorMapping : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable(nameof(Autor));
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Descricao).HasMaxLength(500);
            builder.Property(x => x.Backdrop).HasMaxLength(500);

            builder.Ignore(x => x.AutorKey);
        }
    }
}
