using AutoMapper;
using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Domain.Streaming.ValueObject;
using SpotMusic.Repository.Repository;

namespace SpotMusic.Application.Streaming
{
    public class AutorService
    {
        private AutorRepository _autorRepository;
        private IMapper mapper;

        public AutorService(AutorRepository autorRepository, IMapper mapper)
        {
            this._autorRepository = autorRepository;
            this.mapper = mapper;
        }

        public AutorDto Criar (AutorDto Autordto)
        {
            Autor autor = Autor.Criar(Autordto.Nome, Autordto.Descricao, Autordto.Backdrop);

            this._autorRepository.Save(autor);

            return this.mapper.Map<AutorDto>(autor);
        }

        public AutorDto? Obter(Guid id)
        {
            var result = _autorRepository.GetById(id);

            if (result == null)
                return null;
            return this.mapper.Map<AutorDto>(result);
        }

        public IEnumerable<AutorDto> Obter()
        {
            var result = _autorRepository.GetAll;

            return this.mapper.Map<List<AutorDto>>(result);
        }
    }
}
