using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Mgmo.Main.Article.Data.Config;
using Mgmo.Main.Article.Infratructure.Interfaces.Stores;

namespace Mgmo.Main.Article.Infratructure.Articles
{
    public class ArticleStore : IArticleStore
    {
        private readonly AppConfig _appConfig;
        // Set up a connection to azure storage account
        public ArticleStore(AppConfig appConfig)
        {
            _appConfig = appConfig;
        }

        public async Task<TableItem> GetArticleTable()
        {
            // Create a table client for interacting with the table service
            var tableClient = new TableServiceClient(_appConfig.StorageConnectionString);
            // Create a table client for interacting with the table service
            var table = await tableClient.CreateTableIfNotExistsAsync("article");

            return table.Value;
        }
    }
}