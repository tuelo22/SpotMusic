using SpotMusic.Domain.Conta.Aggregates;
using SpotMusic.Domain.Notificacao.Enum;

namespace SpotMusic.Domain.Notificacao.Aggregates
{
    public class Notificacao
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public String Mensagem { get; set; }
        public String Titulo { get; set; }
        public virtual Usuario Destinatario { get; set; }
        public virtual Usuario? Remetente { get; set; }

        public TipoNotificacao TipoNotificacao { get; set; }

        public static Notificacao Criar(String titulo, String mensagem, TipoNotificacao tipoNotificacao, Usuario destino, Usuario? remetente = null)
        {
            if (tipoNotificacao == TipoNotificacao.Usuario && remetente == null)
            {
                throw new Exception("Para tipo de mensagem 'usuario', deve ser informado o remetente.");
            }

            if (String.IsNullOrWhiteSpace(titulo))
            {
                throw new Exception("Informe o titulo da notificacao.");
            }

            if (String.IsNullOrWhiteSpace(mensagem))
            {
                throw new Exception("Informe o mensagem da notificacao.");
            }

            return new()
            {
                Data = DateTime.Now,
                Mensagem = mensagem,
                TipoNotificacao = tipoNotificacao,
                Titulo = titulo,
                Destinatario = destino,
                Remetente = remetente
            };
        }
    }
}
