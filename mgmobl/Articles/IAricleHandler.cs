using mgmoarticontracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mgmoarticleblo.Articles
{
    public interface IAricleHandler
    {
        ArticleModel GetArticle(string category, string articleId);

        IEnumerable<ArticleModel> GetArticles(string category);

        ArticleModel NewArticle(string id, string category);

        Task<ArticleModel> StoreChanges(ArticleModel articleModel);

    }
}
