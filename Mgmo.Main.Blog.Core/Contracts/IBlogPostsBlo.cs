using Mgmo.Main.Blog.Core.Dto;

namespace Mgmo.Main.Blog.Core.Contracts
{
    public interface IBlogPostsBlo
    {
        public Task AddBlogPostAsync(BlogPostDto blogPost);
        public Task<BlogPostsDto> GetAllBlogPostasAsync(string continueToken);
        Task<BlogPostDto> GetBlogAsync(string id, string category);
    }
}
