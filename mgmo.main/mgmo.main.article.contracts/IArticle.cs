namespace Mgmo.Main.Article.Contracts
{
    public interface IArticle
    {
        public Task<Models.Article> Get();

        public Task<Models.Article> Create(Models.Article article);

        public Task<Models.Article> Update(Models.Article article);
    }
}