using mgmoarticledata.Models;
using mgmoarticleint.Articles;
using mgmoarticleint.Models;
using Microsoft.Azure.Cosmos.Table;
using System.Collections.Generic;
using System.Linq;

namespace mgmoarticledata.Articles
{
    public class ArticleDataHandlers : IArticleData
    {
        ConnectionInfo _connectionInfo;
        CloudStorageAccount storageAccount;
        CloudTableClient tableClinet;

        public ArticleDataHandlers(ConnectionInfo connectionInfo)
        {
            _connectionInfo = connectionInfo;

            storageAccount = CloudStorageAccount.Parse(connectionInfo.ConnectionString);
            tableClinet = storageAccount.CreateCloudTableClient();


        }
        public ArticleModel GetArticle(string articleArea, string articleId)
        {
            var articlesTable = GetArticleTable();

            var query = new TableQuery<ArticleData>().
                Where(
                TableQuery.CombineFilters(
                    TableQuery.GenerateFilterCondition(nameof(ArticleData.PartitionKey), QueryComparisons.Equal, articleArea),
                    TableOperators.And,
                    TableQuery.GenerateFilterCondition(nameof(ArticleData.RowKey), QueryComparisons.Equal, articleId)
                    )
                );

            var articles = articlesTable
                .ExecuteQuery(query);

            var firstArticle = articles.FirstOrDefault();

            var articleModel = firstArticle != null ? Map(firstArticle) : null;

            return articleModel;
        }

        private CloudTable GetArticleTable()
        {
            var articlesTable = tableClinet.GetTableReference(_connectionInfo.Container);

            articlesTable.CreateIfNotExists();
            return articlesTable;
        }

        public IEnumerable<ArticleModel> GetArticles(string area)
        {
            var articleTable = GetArticleTable();

            var queryAll = new TableQuery<ArticleData>().
                Where(TableQuery.
                GenerateFilterCondition(nameof(ArticleData.PartitionKey), QueryComparisons.Equal, area));

            var articles = articleTable.ExecuteQuery(queryAll);

            var articlesModel = articles.Select(art => Map(art));

            return articlesModel;
        }

        private static ArticleModel Map(ArticleData a)
        {
            return new ArticleModel
            {
                Category = a.PartitionKey,
                Id = a.RowKey,
                Content = a.Content,
                Published = a.Timestamp.DateTime,
                Title = a.Title,
                ImageUris = a.ImageUris
            };
        }
    }
}
