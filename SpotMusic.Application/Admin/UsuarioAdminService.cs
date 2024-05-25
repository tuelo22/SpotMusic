using AutoMapper;
using SpotMusic.Application.Admin.Dto;
using SpotMusic.Domain.Admin.Aggregates;
using SpotMusic.Repository.Repository.Admin;

namespace SpotMusic.Application.Admin
{
    public class UsuarioAdminService(
        UsuarioAdminRepository usuarioAdminRepository,
        IMapper mapper)
    {
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
