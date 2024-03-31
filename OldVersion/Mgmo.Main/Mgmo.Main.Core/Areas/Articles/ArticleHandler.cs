using Mgmo.Main.Core.Areas.Articles.Contracts;
using Mgmo.Main.Infratructure.Entities.Contracts;

namespace Mgmo.Main.Core.Areas.Articles
{
    public class ArticleHandler : IArticleHandler
    {
        private IStoreService StoreService { get; }
        public ArticleHandler(IStoreService storeService)
        {
            StoreService = storeService;
        }

        public async Task<Article> Create(string title, string content, string author, IEnumerable<string> tags)
        {
            var id = Guid.NewGuid().ToString();
            var article = new Article(StoreService, id, title, content, author, DateTime.UtcNow, DateTime.UtcNow, tags);
            await article.Store(StoreService);
            return article;
        }

        public async Task<Article> Get(string id)
        {
            return await StoreService.Get<Article>("articles", id);
        }

        public async Task<Article> Update(string id, string title, string content, string author, IEnumerable<string> tags)
        {
            var article = await StoreService.Get<Article>("articles", id);
            article = article with
            {
                Title = title,
                Content = content,
                Author = author,
                Updated = DateTime.UtcNow,
                Tags = tags
            };
            await article.Store(StoreService);
            return article;
        }

        public async Task<IEnumerable<Article>> GetAll()
        {
            return await StoreService.GetAll<Article>("articles");
        }
    }
}
