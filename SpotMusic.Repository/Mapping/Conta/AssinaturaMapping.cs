using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotMusic.Domain.Conta.Aggregates;
using SpotMusic.Domain.Streaming.ValueObject;

namespace SpotMusic.Repository.Mapping.Conta
{
    public class AssinaturaMapping : IEntityTypeConfiguration<Assinatura>
    {
        public void Configure(EntityTypeBuilder<Assinatura> builder)
        {
            builder.ToTable(nameof(Assinatura));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Status).IsRequired();
            builder.HasOne(x => x.Plano).WithMany();

            builder.OwnsOne<Periodo>(x => x.Vigencia, c =>
            {
                c.Property(x => x.Inicio).HasColumnName("PeriodoInicio").IsRequired();
                c.Property(x => x.Fim).HasColumnName("PeriodoFim").IsRequired();
            });
        }
    }
}
