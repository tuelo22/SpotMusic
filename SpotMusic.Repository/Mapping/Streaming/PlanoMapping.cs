using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotMusic.Domain.Core.ValueObject;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Streaming.ValueObject;

namespace SpotMusic.Repository.Mapping.Streaming
{
    public class PlanoMapping : IEntityTypeConfiguration<Plano>
    {
        public void Configure(EntityTypeBuilder<Plano> builder)
        {
            builder.ToTable(nameof(Plano));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Nome).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(1024);

            builder.OwnsOne<Monetario>(x => x.Valor, c =>
            {
                c.Property(x => x.Valor).IsRequired();
            });

            builder.OwnsOne<Periodo>(x => x.Vigencia, c =>
            {
                c.Property(x => x.Inicio).HasColumnName("PeriodoInicio").IsRequired();
                c.Property(x => x.Fim).HasColumnName("PeriodoFim").IsRequired();
            });
        }
    }
}
