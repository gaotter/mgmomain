using mgmoarticleint.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace mgmoarticleblo.Articles
{
    public interface IAricleHandler
    {
        ArticleModel GetArticle(string category, string articleId);

        IEnumerable<ArticleModel> GetArticles(string category);
    }
}
