using Azure.Data.Tables;
using Azure.Data.Tables.Models;
using Mgmo.Main.Article.Data.Config;
using Mgmo.Main.Article.Data.Models;
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

        public async Task<TableClient> GetArticleTableClient()
        {
            // Create a table client for interacting with the table service
            var tableServiceClient = new TableServiceClient(_appConfig.StorageConnectionString);
            var tableClient = tableServiceClient.GetTableClient("articles");

            // Create a table client for interacting with the table service
            _  = await tableServiceClient.CreateTableIfNotExistsAsync("articles");

            return tableClient;
        }

        public async Task<IEnumerable<ArticleModel>> GetAllArticles()
        {
            var articleTableClient = await GetArticleTableClient();

            var articles = articleTableClient.Query< ArticleModel>(x => true);

            
        }

    }
}