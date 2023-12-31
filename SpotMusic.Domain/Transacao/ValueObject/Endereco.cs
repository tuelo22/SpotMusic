﻿namespace SpotMusic.Domain.Transacao.ValueObject
{
    public record Endereco
    {
        public String Estado { get; set; }
        public String Cidade { get; set; }
        public String Rua { get; set; }
        public String Numero { get; set; }
        public String? Complemento { get; set; }

        public static Endereco Criar(String estado, String cidade, String Rua, String numero, String? complemento)
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

            return new Endereco
            {
                Estado = estado,
                Cidade = cidade,
                Rua = Rua,
                Numero = numero,
                Complemento = complemento
            };
        }
    }
}
