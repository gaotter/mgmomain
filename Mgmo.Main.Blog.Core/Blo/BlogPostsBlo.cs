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

        public async Task<BlogPostsDto> GetAllBlogPostasAsync(string continueToken)
        {
             var blogPosts = await _blogPostsStorageHandler.GetAllBlogPostasAsync(continueToken);

            return blogPosts;
        }

        public async Task<BlogPostDto> GetBlogAsync(string id, string category)
        {
            var blogPost = await _blogPostsStorageHandler.GetBlogAsync(id, category);

            return blogPost;
        }


    }
}
