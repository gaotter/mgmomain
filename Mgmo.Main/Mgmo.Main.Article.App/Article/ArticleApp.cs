using Mgmo.Main.Article.App.Article;
using Mgmo.Main.Article.App.Cosmos;
using Mgmo.Main.Article.Dto.AppDto;

namespace Mgmo.Main.Article.App.ArticleData
{
    public class ArticleApp : IArticleApp
    {
        private readonly IDataHandler dataHandler;
        public ArticleApp(IDataHandler dataHandler)
        {
            this.dataHandler = dataHandler;
        }
        
        public Dto.AppDto.ArticleData GetArticle(string v)
        {
            return null;
        }
    }
}
