using mgmoarticontracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mgmoarticontracts.Articles
{
    public interface IArticleData
    {
        ArticleModel GetArticle(string area, string articleID);

        IEnumerable<ArticleModel> GetArticles(string area);

        Task<ArticleModel> AddUpdateArticle(ArticleModel article);
    }
}
