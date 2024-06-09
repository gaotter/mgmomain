using Mgmo.Main.Blog.Core.Contracts;
using Mgmo.Main.Blog.Core.Dto;

namespace Mgmo.Main.Blog.Core.Blo
{
    public class BlogPostsBlo : IBlogPostsBlo
    {
        private readonly IBlogPostsStorageHandler _blogPostsStorageHandler;

        public BlogPostsBlo(IBlogPostsStorageHandler blogPostsStorageHandler)
        {
            _blogPostsStorageHandler = blogPostsStorageHandler;
        }
        public Task AddBlogPostAsync(BlogPostDto blogPost)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BlogPostDto>> GetAllBlogPostasAsync()
        {
             var blogPosts = await _blogPostsStorageHandler.GetAllBlogPostasAsync();

            return blogPosts;
        }
    }
}
