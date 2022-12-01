namespace Mgmo.Main.Article.Dto.AppDto
{
    public record Paragrapth
    {
        public string Content { get; set; } = "";
        public IEnumerable<string> ImageUrls { get; set; } = new List<string>();
    }
}
