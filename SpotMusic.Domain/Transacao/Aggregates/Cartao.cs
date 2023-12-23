using SpotMusic.Domain.Core.Enum;
using SpotMusic.Domain.Core.ValueObject;
using SpotMusic.Domain.Transacao.ValueObject;

namespace SpotMusic.Domain.Transacao.Aggregates
{
    public class Cartao
    {
        private const int INTERVALO_TRANSACAO = -2;
        private const int REPETICAO_TRANSACAO_MERCHANT = 1;

        public Guid Id { get; set; }
        public TipoStatus Status { get; set; }
        public Monetario Limite { get; set; }
        public String Numero { get; set; }
        public List<Transacao> Transacoes { get; set; } = new List<Transacao>();
        public Endereco EnderecoCobranca { get; set; }

        public void CriarTransacao(Merchant merchant, Monetario valor, string descricao = "")
        {
            this.IsCartaoAtivo();

            Transacao transacao = new()
            {
                Merchant = merchant,
                Valor = valor,
                Descricao = descricao,
                Data = DateTime.Now
            };

            this.VerificaLimite(transacao);
            this.ValidarTransacao(transacao);

            transacao.Id = Guid.NewGuid();

            this.Limite -= transacao.Valor;

            this.Transacoes.Add(transacao);
        }

        private void ValidarTransacao(Transacao transacao)
        {
            if(EnderecoCobranca == null)
            {
                throw new Exception("Para realizar transações é obrigatório informar o endereço de cobrança.");
            }

            var ultimasTransacoes = this.Transacoes.Where(x => x.Data >= DateTime.Now.AddMinutes(INTERVALO_TRANSACAO));

            if(ultimasTransacoes.Count() >= 3)
            {
                throw new Exception("Cartão utilizado muitas vezes em um periodo curto");
            }

            var tracacaoRepetidaPorMerchant = ultimasTransacoes
                .Where(x => x.Merchant.Nome.ToUpper() == transacao.Merchant.Nome.ToLower() 
                       && x.Valor == transacao.Valor).Count() == REPETICAO_TRANSACAO_MERCHANT;

            if (tracacaoRepetidaPorMerchant)
            {
                throw new Exception("Transacao duplicada");
            }
        }

        private void VerificaLimite(Transacao transacao)
        {
            if(this.Limite < transacao.Valor)
            {
                throw new Exception("Cartão não possui limite para esta transacao");
            }            
        }

        private void IsCartaoAtivo()
        {
            if(this.Status == TipoStatus.Inativo)
            {
                throw new Exception("Cartão não está ativo");
            }
        }
    }
}
