namespace Mgmo.Main.Core.Areas.Articles.Contracts
{
    public interface IArticleHandler
    {
        Task<Article> Create(string title, string content, string author, IEnumerable<string> tags);
        Task<Article> Get(string id);
        Task<IEnumerable<Article>> GetAll();
        Task<Article> Update(string id, string title, string content, string author, IEnumerable<string> tags);
    }
}