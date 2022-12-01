using Azure;
using Azure.Data.Tables;

namespace Mgmo.Main.Article.Dto.AppDto
{
    public record ArticleData : ITableEntity
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public IEnumerable<Paragrapth> Paragrapths { get; set; } = new List<Paragrapth>();
        public string Author { get; set; } = "";
        public string Category { get; set; } = "";
        public string Tags { get; set; } = "";
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
