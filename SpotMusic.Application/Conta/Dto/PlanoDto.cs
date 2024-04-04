namespace SpotMusic.Application.Conta.Dto
{
    public struct PlanoDto
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
