using mgmoconnector.ViewModels;
using System.Collections.Generic;

namespace mgmomain.Data
{
    public interface IArticleService
    {
        IEnumerable<ArticleViewModel> GetAllAzureArticles(string category = null);
        string GetArticleTitle();
    }
}