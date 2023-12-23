using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SpotMusic.Repository.Mapping.Notificacao
{
    public class NotificacaoMapping : IEntityTypeConfiguration<SpotMusic.Domain.Notificacao.Aggregates.Notificacao>
    {
        public void Configure(EntityTypeBuilder<SpotMusic.Domain.Notificacao.Aggregates.Notificacao> builder)
        {
            builder.ToTable(nameof(SpotMusic.Domain.Notificacao.Aggregates.Notificacao));

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Mensagem).IsRequired().HasMaxLength(250);
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.TipoNotificacao).IsRequired();

            builder.HasOne(x => x.Destinatario).WithMany(x => x.Notificacoes).IsRequired().OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Remetente).WithMany().IsRequired(false);
        }
    }
}
