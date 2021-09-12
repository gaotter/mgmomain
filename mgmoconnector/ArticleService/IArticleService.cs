using mgmoarticleconnector.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mgmomain.Data
{
    public interface IArticleService
    {
        IEnumerable<ArticleViewModel> GetAllAzureArticles(string category = null);
        string GetArticleTitle();

        Task<ArticleViewModel> StoreArticle(ArticleViewModel article);
    }
}