namespace SpotMusic.Application.Conta.Request
{
    public struct CartaoDto
    {
        public Guid Id { get; set; }
        public String Status { get; set; }
        public Decimal Limite { get; set; }
        public String Numero { get; set; }
        public String EnderecoCobranca { get; set; }
    }
}
