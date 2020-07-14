using mgmoarticleint.Articles;
using mgmoarticleint.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace mgmoarticleblo.Articles
{
    public class ArticleHandler : IAricleHandler
    {
        private IArticleData _articleData;
        public ArticleHandler(IArticleData articleData)
        {
            _articleData = articleData;
        }

        ArticleModel IAricleHandler.GetArticle(string category, string articleId)
        {
            return _articleData.GetArticle(articleId, "");
        }

        IEnumerable<ArticleModel> IAricleHandler.GetArticles(string category)
        {
            return _articleData.GetArticles(category);
        }
    }
}
