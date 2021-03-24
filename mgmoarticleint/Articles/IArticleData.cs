using mgmoarticontracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace mgmoarticontracts.Articles
{
    public interface IArticleData
    {
        ArticleModel GetArticle(string area, string articleID);

        IEnumerable<ArticleModel> GetArticles(string area);
    }
}
