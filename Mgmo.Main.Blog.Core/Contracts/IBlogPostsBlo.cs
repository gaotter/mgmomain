using Mgmo.Main.Blog.Core.Dto;

namespace Mgmo.Main.Blog.Core.Contracts
{
    public interface IBlogPostsBlo
    {
        public Task AddBlogPostAsync(BlogPostDto blogPost);
        public Task<IEnumerable<BlogPostDto>> GetAllBlogPostasAsync();
    }
}
