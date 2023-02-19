using Mgmo.Main.Article.Infratructure.Articles;
using Mgmo.Main.Article.Infratructure.Interfaces.Stores;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mgmo.Main.Article.Core.Connector
{
    public static class InjectionServices
    {
        public static void AddArticleServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddOptions();
            services.AddSingleton<IArticleStore, ArticleStore>();
        }
    }
}
