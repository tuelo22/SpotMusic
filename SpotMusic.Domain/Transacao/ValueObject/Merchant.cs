namespace SpotMusic.Domain.Transacao.ValueObject
{
    public class Merchant
    {
        public Merchant(string nome)
        {
            Nome = nome;
        }

        public String Nome { get; set; }
    }
}
