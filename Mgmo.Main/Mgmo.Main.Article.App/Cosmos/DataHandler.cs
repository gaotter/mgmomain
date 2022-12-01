using Azure.Data.Tables;

namespace Mgmo.Main.Article.App.Cosmos
{
    public class DataHandler : IDataHandler
    {
        private TableServiceClient tableServiceClient;
        private readonly string tableName;
        private readonly string connectionString;

        public DataHandler(string tableName, string connectionString)
        {
            this.tableName = tableName;
            this.connectionString = connectionString;
        }       
        
        private TableServiceClient GetTableServiceClient()
        {
            if (tableServiceClient != null)
                return tableServiceClient;

            tableServiceClient = new TableServiceClient(Environment.GetEnvironmentVariable(connectionString));
            return tableServiceClient;
        }

        public async Task Store<T>(T item) where T : class, ITableEntity, new()
        {
            TableClient tableClient = await GetTableClient();

            await tableClient.AddEntityAsync(item);
        }

        private async Task<TableClient> GetTableClient()
        {
            var tableClient = GetTableServiceClient().GetTableClient(tableName: tableName);

            await tableClient.CreateIfNotExistsAsync();
            return tableClient;
        }

        public async Task<T> Get<T>(string rowKey, string partitionKey) where T : class, ITableEntity, new()
        {
            var tableClient = await GetTableClient();
            var item = await tableClient.GetEntityAsync<T>(rowKey: rowKey, partitionKey: partitionKey);

            return item;
        }
    }
}
