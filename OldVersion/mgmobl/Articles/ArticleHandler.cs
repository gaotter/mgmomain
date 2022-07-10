using mgmoarticontracts.Articles;
using mgmoarticontracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mgmoarticleblo.Articles
{
    public class ArticleHandler : IAricleHandler
    {
        private IArticleData _articleData;
        public ArticleHandler(IArticleData articleData)
        {
            _articleData = articleData;
        }

        public ArticleModel NewArticle(string id, string category)
        {
            return new ArticleModel(id, category);
        }    

        public ArticleModel GetArticle(string category, string articleId)
        {
            return _articleData.GetArticle(articleId, "");
        }

        public IEnumerable<ArticleModel> GetArticles(string category)
        {
            return _articleData.GetArticles(category);
        }

        public async Task<ArticleModel> StoreChanges(ArticleModel articleModel)
        {
            return await _articleData.AddUpdateArticle(articleModel);
        }
    }
}
