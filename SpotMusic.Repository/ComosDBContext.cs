using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace SpotMusic.Repository
{
    public class CosmosDBContext<T> where T : class
    {
        private CosmosClient Client { get; set; }
        private string AccountEndpoint { get; set; }
        private string TokenCredential { get; set; }

        private const string DATABASENAME = "spotmusic";

        private string? ContainerName { get; set; }

        private Database Database { get; set; }
        private Container Container { get; set; }

        public CosmosDBContext(IConfiguration configuration)
        {
            this.AccountEndpoint = configuration["CosmosConnection:AccountEndpoint"]?.ToString() ?? string.Empty;
            this.TokenCredential = configuration["CosmosConnection:TokenCredential"]?.ToString() ?? string.Empty;

            this.Client = new CosmosClient(AccountEndpoint, TokenCredential);
            this.Database = this.Client.GetDatabase(DATABASENAME);

            this.ContainerName = typeof(T).Name.ToLower();
            this.Container = Database.GetContainer(this.ContainerName);
        }

        public async Task SaveOrUpate(T entity, string partitionKey) 
        {
            await Container.UpsertItemAsync<T>(item: entity, partitionKey: new PartitionKey(partitionKey));
        }

        public async Task Delete(string id, string partitionKey)
        {
            await Container.DeleteItemAsync<T>(id, new PartitionKey(partitionKey));
        }

        public async Task<List<T>> ReadAllItem()
        {
            var query = new QueryDefinition(
                   query: "SELECT * FROM " + this.ContainerName
            );

            using FeedIterator<T> feedIterator = Container.GetItemQueryIterator<T>(query) as FeedIterator<T>;

            List<T> result = [];

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<T> response = await feedIterator.ReadNextAsync();

                foreach (var item in response)
                {
                    result.Add(item);
                }
            }

            return result;

        }

        public async Task<T?> ReadItem(string id)
        {
            var query = new QueryDefinition(
                  query: "SELECT * FROM " + this.ContainerName + " c where c.id = @id"
            ).WithParameter("@id", id);

            using FeedIterator<T> feedIterator = Container.GetItemQueryIterator<T>(query) as FeedIterator<T>;

            List<T> result = [];

            while (feedIterator.HasMoreResults)
            {
                FeedResponse<T> response = await feedIterator.ReadNextAsync();

                foreach (var item in response)
                {
                    result.Add(item);
                }
            }

            return result.FirstOrDefault();
        }
    }
}
