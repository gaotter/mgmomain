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
        private const string BlogTableName = "BlogPosts";
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

        public async Task<BlogPostsDto> GetAllBlogPostasAsync(string continueToken)
        {
            var tableClint = await GetTable("BlogPosts");

            AsyncPageable< BlogEntity> blogEntitiesPagebale = tableClint.QueryAsync<BlogEntity>(maxPerPage: 3);
            
            var blogPosts = await GetBlogPostDtos(blogEntitiesPagebale, continueToken);

            return blogPosts;
        }

        public async Task<BlogPostDto> GetBlogAsync(string id, string category)
        {
            var tableClint = await GetTable(BlogTableName);

            var blogEntity = await tableClint.GetEntityAsync<BlogEntity>(category, id);

            return new BlogPostDto(blogEntity.Value.Id, blogEntity.Value.Title, blogEntity.Value.Category, blogEntity.Value.Content, blogEntity.Value.PublishedAt, blogEntity.Value.MainImageUrl, blogEntity.Value.ImageUrls?.Split(";"));
        }

        private static async Task<BlogPostsDto> GetBlogPostDtos(AsyncPageable<BlogEntity> blogEntities, string paginationContinueToken)
        {
            
            var posts = new List<BlogPostDto>();
            var nextToken = paginationContinueToken ?? string.Empty;
            await foreach (var blogEntityGroup in blogEntities.AsPages(paginationContinueToken))
            {
               nextToken = blogEntityGroup.ContinuationToken;
                foreach (var blogPost in blogEntityGroup.Values)
                    posts.Add(new BlogPostDto(blogPost.Id, blogPost.Title, blogPost.Category, blogPost.Content, blogPost.PublishedAt, blogPost.MainImageUrl, blogPost.ImageUrls?.Split(";")));
                break;
            }
            var blogPosts = new BlogPostsDto
            { 
                PaginationContinueToken = nextToken, Posts = posts,
                
            };

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
