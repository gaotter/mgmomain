namespace Mgmo.Main.Article.App.Models
{
    public record ArticleModel
    {
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string Body { get; set; } = string.Empty;
        public DateTime Updated { get; set; }
        public string Topic { get; set; } = string.Empty;
    }
}
