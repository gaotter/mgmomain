using mgmoarticleblo.Articles;
using mgmoarticontracts.Models;
using mgmoarticleconnector.Mapping;
using mgmoarticleconnector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgmomain.Data
{
    public class ArticleService : IArticleService
    {
        IAricleHandler _articleHandler;
        public ArticleService(IAricleHandler aricleHandler)
        {
            _articleHandler = aricleHandler;
        }

        public string GetArticleTitle()
        {
            return _articleHandler.GetArticle("ssss", "ssss").Content;
        }

        public IEnumerable<ArticleViewModel> GetAllAzureArticles(string category = null)
        {
            return _articleHandler.GetArticles(category).Select(model => ArticleToViewModel.Map(model));
        }

        public async Task<ArticleViewModel> StoreArticle(ArticleViewModel article)
        {
            var model = ArticleToViewModel.Map(article);
            var updatedModel = await _articleHandler.StoreChanges(model);

            return ArticleToViewModel.Map(updatedModel);

        }
    }
}
