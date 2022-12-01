namespace mgmo.main.article.contracts
{
    public interface IArticle
    {
        public Task<models.Article> Get();

        public Task<models.Article> Create(models.Article article);

        public Task<models.Article> Update(models.Article article);
    }
}