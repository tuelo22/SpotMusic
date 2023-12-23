using SpotMusic.Domain.Core.ValueObject;
using SpotMusic.Domain.Transacao.ValueObject;

namespace SpotMusic.Domain.Transacao.Aggregates
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public TimeSpan Hora { get; set; }
        public Monetario Valor { get; set; }
        public string Descricao { get; set; }
        public Merchant Merchant { get; set;}

    }
}
