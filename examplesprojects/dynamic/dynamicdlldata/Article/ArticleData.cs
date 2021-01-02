using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using AricleContracts.Data;
using AricleContracts.Business;
using AricleContracts.Records;

namespace dynamicaricledata.Article
{
    class ArticleData : IArticleStore
    {

        //just for testing
        List<ArticleRecord> articleDatabase = new List<ArticleRecord>();

        public ArticleRecord GetArticle(string id)
        {
            return articleDatabase.FirstOrDefault(a => a.id == id);
        }

        public IEnumerable<ArticleRecord> GetArticles()
        {
            return articleDatabase.Select(d => d);
        }

        public void StoreAricle(ArticleRecord record)
        {
            var machingIndex = articleDatabase.FindIndex(r => r.id == record.id);

            if(machingIndex > -1)
            {
                articleDatabase[machingIndex] = record;
            } 
            else
            {
                articleDatabase.Add(record);
            }           

        }

        public void StoreArticles(IEnumerable<ArticleRecord> articles)
        {
            foreach(var article in articles)
            {
                StoreAricle(article);
            }
        }
    }
}
