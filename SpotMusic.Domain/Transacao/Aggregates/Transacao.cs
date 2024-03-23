using SpotMusic.Domain.Core.ValueObject;
using SpotMusic.Domain.Transacao.ValueObject;

namespace SpotMusic.Domain.Transacao.Aggregates
{
    public class Transacao
    {
        public Guid Id { get; set; }
        public required DateTime Data { get; set; }
        public required Monetario Valor { get; set; }
        public required string Descricao { get; set; }
        public required Merchant Merchant { get; set;}
    }
}
