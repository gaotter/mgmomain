namespace Mgmo.Main.Blog.Core.Dto
{
    public record BlogPostDto
    {
        public BlogPostDto(int id, string title, string categoty, string content, DateTime publishedAt, string mainImageUrl, IEnumerable<string> imageUrls)
        {
            Id = id;
            Title = title;
            Category = categoty;
            Content = content;
            PublishedAt = publishedAt;
            MainImageUrl = mainImageUrl;
            ImageUrls = imageUrls;
        }

        public int Id { get; init; }
        public string Title { get; init; }
        public string Category { get; init; }
        public string Content { get; init; }
        public DateTime PublishedAt { get; init; }
        public string MainImageUrl { get; init; }
        public IEnumerable<string> ImageUrls { get; init; }
    }
}
