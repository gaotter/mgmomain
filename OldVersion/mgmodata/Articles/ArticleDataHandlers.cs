﻿using mgmoarticledata.Models;
using mgmoarticontracts.Articles;
using mgmoarticontracts.Models;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using MgmoTableStorageBase;
using System.Threading.Tasks;

namespace mgmoarticledata.Articles
{
    public class ArticleDataHandlers : TableStorageBase, IArticleData
    {
        string categoryesKey = "AllCategories234";

        public ArticleDataHandlers(ConnectionInfo connectionInfo) : base(connectionInfo)
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

        public IEnumerable<ArticleModel> GetArticles(string area = null)
        {
            var articleTable = GetArticleTable();

            var queryAll = new TableQuery<ArticleData>();

            if (area != null)
            {
                queryAll = new TableQuery<ArticleData>().
                Where(TableQuery.
                GenerateFilterCondition(nameof(ArticleData.PartitionKey), QueryComparisons.Equal, area));
            }


            var articles = articleTable.ExecuteQuery(queryAll);

            var articlesModel = articles.Select(art => Map(art));

            return articlesModel;
        }

        public IEnumerable<string> GetArticleCategories()
        {
            var articleTable = GetArticleTable();

            var query = new TableQuery<TableEntity>()
                .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, categoryesKey));

            var articles = articleTable.ExecuteQuery(query);

            return articles.Select(a => a.PartitionKey);
        }

        private ArticleModel Map(ArticleData a)
        {
            return new ArticleModel(a.RowKey, a.PartitionKey)
            {
                Content = a.Content,
                Published = a.Timestamp.DateTime,
                Title = a.Title,
                ImageUris = a.ImageUris,
                IsPublished = a.IsPublished

            };
        }

        private ArticleData Map(ArticleModel articleModel)
        {
            return new ArticleData
            {
                Title = articleModel.Title,
                Content = articleModel.Content,
                ImageUris = articleModel.ImageUris,
                IsPublished = articleModel.IsPublished,
                PartitionKey = articleModel.Category,
                RowKey = articleModel.Id != null ? articleModel.Id : Guid.NewGuid().ToString()
            };
        }

        public async Task<ArticleModel> AddUpdateArticle(ArticleModel article)
        {
            var tableClient = GetArticleTable();
                
            var articleData = Map(article);

            var insertOperation = TableOperation.InsertOrMerge(articleData);

            try
            {
                var result = await tableClient.ExecuteAsync(insertOperation);

                var r = result.Result;


                return Map(result.Result as ArticleData);
            }
            catch(Exception ex)
            {
                throw ex;
                // logg
            }


        }
    }
}
