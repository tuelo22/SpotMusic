using AutoMapper;
using SpotMusic.Application.Streaming.Dto;
using SpotMusic.Application.Streaming.Storage;
using SpotMusic.Domain.Streaming.Aggregates;
using SpotMusic.Repository.Repository;

namespace SpotMusic.Application.Streaming
{
    public class AutorService(
        AutorRepository autorRepository, 
        AutorCosmosRepository autorCosmosRepository, 
        IMapper mapper,
        AzureStorageAccount azureStorageAccount)
    {
        public async Task<AutorDto> Criar (AutorDto Autordto)
        {
            string urlBackDrop = string.Empty;

            if (!string.IsNullOrEmpty(Autordto.Backdrop))
            {
                urlBackDrop = await azureStorageAccount.UploadImage(Autordto.Backdrop);
            }

            Autor autor = Autor.Criar(Autordto.Nome, Autordto.Descricao, urlBackDrop);

            autorRepository.Save(autor);

            await autorCosmosRepository.SaveOrUpate(autor, autor.AutorKey);

            return mapper.Map<AutorDto>(autor);
        }

        public async Task<AutorDto?> Obter(Guid id)
        {
            var result = await autorCosmosRepository.ReadItem(id.ToString());

            if (result == null)
                return null;
            return mapper.Map<AutorDto>(result);
        }

        public async Task<IEnumerable<AutorDto>> Obter()
        {
            var result = await autorCosmosRepository.ReadAllItem();

            return mapper.Map<List<AutorDto>>(result);
        }

        public async Task Salvar(AutorDto dto)
        {
            var autor = mapper.Map<Autor>(dto);

            autorRepository.Save(autor);
            await autorCosmosRepository.SaveOrUpate(autor, autor.AutorKey);
        }
    }
}
