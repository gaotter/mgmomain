using Azure;
using Azure.Data.Tables;
using Azure.Identity;
using Mgmo.Main.Blog.Core.Contracts;
using Mgmo.Main.Blog.Core.Dto;
using Mgmo.Main.Blog.Infratructure.TableEnteties;
using Microsoft.Extensions.Configuration;

namespace Mgmo.Main.Blog.Infratructure.StorageHandles
{
    public class BlogPostsStorageHandler : IBlogPostsStorageHandler
    {
        private readonly string? _connectionString;
        public BlogPostsStorageHandler(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureStorage");
        }
        public async Task AddBlogPostAsync(BlogPostDto blogPost)
        {
            // Map to table entity
            var blogEntity = new BlogEntity(blogPost.Id, blogPost.Title, blogPost.Category, blogPost.Content, blogPost.PublishedAt, blogPost.MainImageUrl, blogPost.ImageUrls);
            // Save to table storage
            var tableClint = GetTable("BlogPosts");

          //  await tableClint.AddEntityAsync(blogEntity);
        }

        public async Task<IEnumerable<BlogPostDto>> GetAllBlogPostasAsync()
        {
            var tableClint = await GetTable("BlogPosts");
            

            var blogEntitiesPagebale = tableClint.QueryAsync<BlogEntity>();

            var blogPosts = await GetBlogPostDtos(blogEntitiesPagebale);

            return blogPosts;
        }

        private static async Task<IEnumerable<BlogPostDto>> GetBlogPostDtos(AsyncPageable<BlogEntity> blogEntities)
        {
            var blogPosts = new List<BlogPostDto>();

            await foreach (var blogEntity in blogEntities)
            {
                blogPosts.Add(new BlogPostDto(blogEntity.Id, blogEntity.Title, blogEntity.Category, blogEntity.Content, blogEntity.PublishedAt, blogEntity.MainImageUrl, blogEntity.ImageUrls?.Split(";")));
            }

            return blogPosts;
        }

        private async Task<TableClient> GetTable(string tableName)
        {
            // get table client
            var accountUri = new Uri("https://mgmomainsa.table.core.windows.net");

            if (string.IsNullOrEmpty(_connectionString))
            {
                var tokenCredential = new DefaultAzureCredential();
                var serviceClient = new TableServiceClient(accountUri, tokenCredential);

                var tableClient = serviceClient.GetTableClient(tableName);
                await tableClient.CreateIfNotExistsAsync();

                return tableClient;
            }
            else
            {
                var serviceClient = new TableServiceClient(_connectionString);

                var tableClient = serviceClient.GetTableClient(tableName);
                await tableClient.CreateIfNotExistsAsync();

                return tableClient;
            }
        }
    }
}
