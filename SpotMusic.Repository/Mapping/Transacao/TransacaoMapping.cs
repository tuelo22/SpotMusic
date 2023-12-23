using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotMusic.Domain.Transacao.ValueObject;

namespace SpotMusic.Repository.Mapping.Transacao
{
    public class TransacaoMapping : IEntityTypeConfiguration<Domain.Transacao.Aggregates.Transacao>
    {
        public void Configure(EntityTypeBuilder<Domain.Transacao.Aggregates.Transacao> builder)
        {
            builder.ToTable(nameof(Domain.Transacao.Aggregates.Transacao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.Descricao).IsRequired().HasMaxLength(50);

            builder.OwnsOne(d => d.Merchant, c =>
            {
                c.Property(x => x.Nome).HasColumnName("MerchantNome").IsRequired();
            });

        }
    }
}
