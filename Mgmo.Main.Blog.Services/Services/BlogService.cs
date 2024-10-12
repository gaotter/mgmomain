using Mgmo.Main.Blog.Core.Contracts;
using Mgmo.Main.Blog.Core.Dto;

namespace Mgmo.Main.Blog.Services.Services
{
    public class BlogService
    {

        private readonly IBlogPostsBlo _blogPostBlo;

        public BlogService(IBlogPostsBlo blogPostsBlo)
        {
            _blogPostBlo = blogPostsBlo;
        }

        public BlogPostsDto InitialBlogPosts { get; private set; }

        public async Task InitializeBlogPostService()
        {           

            if (InitialBlogPosts is null)
            {
                var blogPosts = await _blogPostBlo.GetAllBlogPostasAsync(null);
                InitialBlogPosts = blogPosts;
            }
        }

        public async Task<BlogPostsDto> GetBlogPosts(string pageToken)
        {
            return await _blogPostBlo.GetAllBlogPostasAsync(pageToken);
        }

    }
}
