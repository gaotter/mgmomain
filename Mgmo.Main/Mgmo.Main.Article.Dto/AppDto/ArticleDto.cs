namespace Mgmo.Main.Article.Dto.AppDto
{
    public record ArticleDto
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public IEnumerable<Paragrapth> Paragrapths { get; set; } = new List<Paragrapth>();
        public string Author { get; set; } = "";
        public string Category { get; set; } = "";
        public string Tags { get; set; } = "";
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
