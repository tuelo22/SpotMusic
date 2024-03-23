using AutoMapper;
using SpotMusic.Application.Conta.Request;
using SpotMusic.Domain.Conta.Aggregates;
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

        public UsuarioService(IMapper mapper, UsuarioRepository usuarioRepository, PlanoRepository planoRepository)
        {
            Mapper = mapper;
            UsuarioRepository = usuarioRepository;
            PlanoRepository = planoRepository;
        }

        public UsuarioDto Criar(UsuarioDto dto)
        {
            if (this.UsuarioRepository.Exists(x=> x.Email == dto.Email))
            {
                throw new Exception("Usuário já existente na base.");
            }

            Plano? plano = PlanoRepository.GetById(dto.PlanoId);

            if(plano == null)
            {
                throw new Exception("Plano não localizado.");
            }

            Usuario usuario = new();

            Cartao cartao = this.Mapper.Map<Cartao>(dto.Cartao);

            usuario.CriarConta(dto.Nome, dto.Email, dto.Senha, dto.Telefone,dto.DataNascimento, plano, cartao);

            this.UsuarioRepository.Save(usuario);

            var result = this.Mapper.Map<UsuarioDto>(usuario);

            return result;
        }

        public UsuarioDto? Obter(Guid id)
        {
            var usuario = this.UsuarioRepository.GetById(id);

            if (usuario == null)
                return null;

            return this.Mapper.Map<UsuarioDto>(usuario);
        }
    }
}
