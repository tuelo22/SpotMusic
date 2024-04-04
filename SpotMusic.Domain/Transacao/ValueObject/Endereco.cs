namespace SpotMusic.Domain.Transacao.ValueObject
{
    public record Endereco
    {
        public required String Estado { get; set; }
        public required String Cidade { get; set; }
        public required String Rua { get; set; }
        public required String Numero { get; set; }
        public required String CEP { get; set; }
        public String? Complemento { get; set; }

        public Endereco()
        {
               
        }

        public static Endereco Criar(String estado, String cidade, String Rua, String numero, String Cep, String? complemento)
        {
            if (String.IsNullOrEmpty(estado))
            {
                throw new ArgumentNullException("E obrigatorio informar o Estado.");
            }
            if (String.IsNullOrEmpty(Rua))
            {
                throw new ArgumentNullException("E obrigatorio informar a Rua.");
            }
            if (String.IsNullOrEmpty(cidade))
            {
                throw new ArgumentNullException("E obrigatorio informar a Cidade.");
            }
            if (String.IsNullOrEmpty(numero))
            {
                throw new ArgumentNullException("E obrigatorio informar o numero.");
            }

            if (String.IsNullOrEmpty(Cep))
            {
                throw new ArgumentNullException("E obrigatorio informar o CEP.");
            }

            return new Endereco
            {
                Estado = estado,
                Cidade = cidade,
                Rua = Rua,
                Numero = numero,
                CEP = Cep,
                Complemento = complemento
            };
        }
    }
}
