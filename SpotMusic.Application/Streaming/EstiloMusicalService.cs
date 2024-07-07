using AutoMapper;
using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Repository.Repository;

namespace SpotMusic.Application.Streaming
{
    public class EstiloMusicalService(EstiloMusicalRepository _EstiloMusicalRepository, IMapper mapper)
    {
        public List<EstiloMusicalDto> Obter()
        {
            var result = _EstiloMusicalRepository.GetAll();

            var estilos = mapper.Map<List<EstiloMusicalDto>>(result);

            return estilos ?? [];
        }
    }
}
