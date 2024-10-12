namespace Mgmo.Main.Blog.Core.Dto
{
    public class BlogPostsDto
    {
        public string? PaginationContinueToken { get; set; }

        public IEnumerable<BlogPostDto> Posts { get; set; } = Enumerable.Empty<BlogPostDto>();
    }
}
