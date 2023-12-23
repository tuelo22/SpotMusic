using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Repository.Mapping.Streaming
{
    public class InterpreteMapping : IEntityTypeConfiguration<Interprete>
    {
        public void Configure(EntityTypeBuilder<Interprete> builder)
        {
            builder.ToTable(nameof(Interprete));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
        }
    }
}
