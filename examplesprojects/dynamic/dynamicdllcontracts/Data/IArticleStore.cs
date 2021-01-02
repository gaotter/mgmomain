using AricleContracts.Business;
using AricleContracts.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AricleContracts.Data
{
    public interface IArticleStore
    {
        void StoreAricle(ArticleRecord article);
        void StoreArticles(IEnumerable<ArticleRecord> articles);
        ArticleRecord GetArticle(string id);
        IEnumerable<ArticleRecord> GetArticles();
    }
}
