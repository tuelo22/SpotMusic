using Microsoft.Extensions.Configuration;
using SpotMusic.Domain.Streaming.Aggregates;

namespace SpotMusic.Repository.Repository
{
    public class AutorCosmosRepository(IConfiguration configuration) : CosmosDBContext<Autor>(configuration)
    {
    }
}
