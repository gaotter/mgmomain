using Mgmo.Main.Article.App.ArticleData;
using Mgmo.Main.Article.App.Cosmos;

namespace Mgmo.Main.Article.App.Article
{
    public static class AppStart
    {
        public static IArticleApp GetArticleApp(string storageConnectionString)
        {
            var dataHandler = new DataHandler("Article", storageConnectionString);
            var articleApp = new ArticleApp(dataHandler);

            return articleApp;
        }
    }
}
