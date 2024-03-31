using Mgmo.Main.Core.Areas.Articles;
using Mgmo.Main.Core.Areas.Articles.Contracts;

namespace Mgmo.Main.WebApp.ServiceConnection
{
    public static class ArticleService
    {
        public static void AddArticleService(this IServiceCollection services)
        {
            services.AddTransient<IArticleHandler, ArticleHandler>();
        }
    }
}
