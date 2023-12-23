using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Repository.Mapping.Streaming
{
    public class EstiloMusicalMapping : IEntityTypeConfiguration<EstiloMusical>
    {
        public void Configure(EntityTypeBuilder<EstiloMusical> builder)
        {
            builder.ToTable(nameof(EstiloMusical));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(100);
        }
    }
}
