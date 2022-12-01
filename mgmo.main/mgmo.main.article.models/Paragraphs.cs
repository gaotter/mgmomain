namespace mgmo.main.article.models
{
    public record Paragraphs
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}
