
using Azure;
using Azure.Data.Tables;

namespace Mgmo.Main.Blog.Infratructure.TableEnteties
{
    public class BlogEntity : ITableEntity 
    {
        public BlogEntity()
        {
        }

        public BlogEntity(int id, string title, string category, string content, DateTime publishedAt, string mainImageUrl, IEnumerable<string> imageUrls)
        {
            PartitionKey = category;
            RowKey = id.ToString();
            Title = title;
            Category = category;
            Content = content;
            PublishedAt = publishedAt;
            MainImageUrl = mainImageUrl;
            ImageUrls = string.Join(";", imageUrls);
        }

        public int Id { get 
            {
                int.TryParse(RowKey, out int id);
                return id;
            } 
        }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public DateTime PublishedAt { get; set; }
        public string MainImageUrl { get; set; }
        public string ImageUrls { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
