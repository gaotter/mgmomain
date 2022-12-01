namespace mgmo.main.article.models
{
    public record Article
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string Category { get; set; } = "General";
        public IEnumerable<Paragraphs> Paragraphs { get; set; } = Enumerable.Empty<Paragraphs>();

    }
}
