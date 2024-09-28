using AutoMapper;
using SpotMusic.Application.Conta.Dto;
using SpotMusic.Application.Conta.Request;
using SpotMusic.Domain.Conta.Aggregates;
using SpotMusic.Domain.Extensions;
using SpotMusic.Domain.Notificacao.Aggregates;
using SpotMusic.Domain.Notificacao.Enum;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Transacao.Aggregates;
using SpotMusic.Repository.Repository;

namespace SpotMusic.Application.Conta
{
    public class UsuarioService
    {
        private IMapper Mapper;
        private UsuarioRepository UsuarioRepository;
        private PlanoRepository PlanoRepository;

        private CartaoService CartaoService;
        private AzureServiceBusService ServiceBusService { get; set; }

        public UsuarioService(
            IMapper mapper,
            UsuarioRepository usuarioRepository,
            PlanoRepository planoRepository,
            CartaoService cartaoService,
            AzureServiceBusService azureServiceBusService)
        {
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
            PlanoRepository = planoRepository;
            CartaoService = cartaoService;
            ServiceBusService = azureServiceBusService;
        }

        public async Task<UsuarioDto> Criar(UsuarioDto dto)
        {
            if (this.UsuarioRepository.Exists(x => x.Email == dto.Email))
            {
                throw new Exception("Usuário já existente na base.");
            }

            Plano? plano = PlanoRepository.GetById(dto.PlanoId);

            if (plano == null)
            {
                throw new Exception("Plano não localizado.");
            }

            Usuario usuario = new();

            Cartao cartao = CartaoService.ConsultarCartaoAtivo(dto.Cartao);

            usuario.CriarConta(dto.Nome, dto.Email, dto.Senha, dto.Telefone, dto.DataNascimento, plano, cartao);

            this.UsuarioRepository.Save(usuario);

            var result = this.Mapper.Map<UsuarioDto>(usuario);

            Notificacao notificacao = Notificacao.Criar(
                "Bem vindo !",
                $"Seja bem vindo ao Spotify Like {usuario.Nome}",
                TipoNotificacao.Sistema, usuario, null);

            var notificacaodto = this.Mapper.Map<NotificacaoDto>(notificacao);

            await this.ServiceBusService.SendMessage(notificacaodto);

            return result;
        }

        public UsuarioDto? Obter(Guid id)
        {
            var usuario = this.UsuarioRepository.GetById(id);

            if (usuario == null)
                return null;

            return this.Mapper.Map<UsuarioDto>(usuario);
        }

        public async Task<UsuarioDto?> Autenticar(string email, string senha)
        {
            var SenhaCriptografada = senha.Criptografar();

            var usuario = this.UsuarioRepository.Find(x => x.Email == email && x.Senha == SenhaCriptografada).FirstOrDefault();

            if (usuario == null)
                return null;

            Notificacao notificacao = Notificacao.Criar(
                "Alerta",
                $"{usuario.Nome} acabou de fazer login as {DateTime.Now}",
                TipoNotificacao.Sistema,
                usuario,
                null);

            var notificacaodto = this.Mapper.Map<NotificacaoDto>(notificacao);

            await this.ServiceBusService.SendMessage(notificacaodto);

            return this.Mapper.Map<UsuarioDto>(usuario);
        }

        public List<PlanoDto> ObterPlanos()
        {
            var plano = this.PlanoRepository.GetAll().ToList();

            return this.Mapper.Map<List<PlanoDto>>(plano);
        }
    }
}
