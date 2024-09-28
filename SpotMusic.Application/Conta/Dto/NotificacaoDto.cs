namespace SpotMusic.Application.Conta.Dto
{
    public struct NotificacaoDto
    {
        public Guid Id { get; set; }
        public DateTime Data { get; set; }
        public string Mensagem { get; set; }
        public string Titulo { get; set; }
        public string Origem { get; set; }
        public Guid IdDestinatario { get; set; }
        public Guid? IdRemetente { get; set; }
        public string? NomeRemetente { get; set; }
    }
}
