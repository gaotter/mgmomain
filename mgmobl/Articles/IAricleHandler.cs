using mgmoarticontracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mgmoarticleblo.Articles
{
    public interface IAricleHandler
    {
        public ArticleModel GetArticle(string category, string articleId);

       public IEnumerable<ArticleModel> GetArticles(string category);

       

       public Task<ArticleModel> StoreChanges(ArticleModel articleModel);

    }
}
