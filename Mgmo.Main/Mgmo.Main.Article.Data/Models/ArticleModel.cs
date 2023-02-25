using Azure;
using Azure.Data.Tables;

namespace Mgmo.Main.Article.Data.Models
{
    public record ArticleModel : ITableEntity
    {
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string Body { get; set; } = string.Empty;
        public DateTime Updated { get; set; }
        public string Topic { get; set; } = string.Empty;
        public string PartitionKey { get; set; } 
        public string RowKey { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTimeOffset? Timestamp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ETag ETag { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
