using Mgmo.Main.Blog.Core.Contracts;
using Mgmo.Main.Blog.Core.Dto;

namespace Mgmo.Main.WebApp.Services
{
    public class BlogService
    {

        private readonly IBlogPostsBlo _blogPostBlo;

        public BlogService(IBlogPostsBlo blogPostsBlo) 
        {
            _blogPostBlo = blogPostsBlo;
        }
        
        public BlogPostsDto InitialBlogPosts { get; private set; } = new BlogPostsDto();

        public async Task InitializeBlogPostService()
        {
            var blogPosts = await _blogPostBlo.GetAllBlogPostasAsync(null);

            if (blogPosts is not null)
            {
                InitialBlogPosts = blogPosts;
            }
        }

    }
}
