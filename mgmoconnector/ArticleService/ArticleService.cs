using mgmoarticleblo.Articles;
using mgmoarticleint.Models;
using mgmoconnector.Mapping;
using mgmoconnector.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgmomain.Data
{
    public class ArticleService
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

        public IEnumerable<ArticleViewModel> GetAllAzureArticles(string category)
        {
            return _articleHandler.GetArticles(category).Select(model => ArticleToViewModel.Map(model));
        }
    }
}
