using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpotMusic.Domain.Core.ValueObject;
using SpotMusic.Domain.Transacao.Aggregates;
using SpotMusic.Domain.Transacao.ValueObject;

namespace SpotMusic.Repository.Mapping.Transacao
{
    public class CartaoMapping : IEntityTypeConfiguration<Cartao>
    {
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.ToTable(nameof(Cartao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Numero).IsRequired().HasMaxLength(100);

            builder.OwnsOne(d => d.Limite, c =>
            {
                c.Property(x => x.Valor).HasColumnName("Limite").IsRequired();
            });

            builder.OwnsOne(x => x.EnderecoCobranca, c =>
            {
                c.Property(x => x.Estado).HasColumnName("Estado").IsRequired().HasMaxLength(50);
                c.Property(x => x.Cidade).HasColumnName("Cidade").IsRequired().HasMaxLength(50);
                c.Property(x => x.Rua).HasColumnName("Rua").IsRequired().HasMaxLength(50);
                c.Property(x => x.Numero).HasColumnName("Numero").IsRequired().HasMaxLength(50);
                c.Property(x => x.Complemento).HasColumnName("Complemento").IsRequired().HasMaxLength(500);
            });

            builder.HasMany(x => x.Transacoes).WithOne();
        }
    }
}
