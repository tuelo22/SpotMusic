using AutoMapper;
using SpotMusic.Application.Admin.Dto;
using SpotMusic.Domain.Admin.Aggregates;
using SpotMusic.Domain.Extensions;
using SpotMusic.Repository.Repository.Admin;

namespace SpotMusic.Application.Admin
{
    public class UsuarioAdminService(
        UsuarioAdminRepository usuarioAdminRepository,
        IMapper mapper)
    {
        public UsuarioAdmin Autenticate(string email, string senha)
        {
            return usuarioAdminRepository.GetByEmailSenha(email, senha.Criptografar());
        }

        public IEnumerable<UsuarioAdminDto> ObterTodos()
        {
            var result = usuarioAdminRepository.GetAll();

            return mapper.Map<List<UsuarioAdminDto>>(result);
        }

        public void Salvar(UsuarioAdminDto dto)
        {
            var usuario = mapper.Map<UsuarioAdmin>(dto);

            usuario.CriptografarSenha();

            usuarioAdminRepository.Save(usuario);
        }
    }
}
