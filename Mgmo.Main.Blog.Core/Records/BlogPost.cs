namespace Mgmo.Main.Blog.Core.Records
{
    public record BlogPost
    {
        public BlogPost(int id, string title, string content, DateTime publishedAt, string mainImageUrl, IEnumerable<string> imageUrls)
        {
            Id = id;
            Title = title;
            Content = content;
            PublishedAt = publishedAt;
            MainImageUrl = mainImageUrl;
            ImageUrls = imageUrls;
        }

        public int Id { get; init; }
        public string Title { get; init; }
        public string Content { get; init; }
        public DateTime PublishedAt { get; init; }
        public string MainImageUrl { get; init; }
        public IEnumerable<string> ImageUrls { get; init; }
    }
}
