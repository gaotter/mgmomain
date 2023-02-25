using Mgmo.Main.Article.Core.ArticleApp;
using Mgmo.Main.Article.Core.Interfaces;
using Mgmo.Main.Article.Infratructure.Articles;
using Mgmo.Main.Article.Infratructure.Interfaces.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace Mgmo.Main.Article.Core.Connector
{
    public static class InjectionServices
    {
        public static void AddArticleServices(this IServiceCollection services)
        {
            services.AddOptions();
            
            services.AddTransient<IArticleStore, ArticleStore>();
            services.AddTransient<IArticlsHandler, ArticlsHandler>();
        }
    }
}
