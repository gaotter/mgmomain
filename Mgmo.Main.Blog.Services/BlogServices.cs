using Mgmo.Main.Blog.Core.Blo;
using Mgmo.Main.Blog.Core.Contracts;
using Mgmo.Main.Blog.Infratructure.StorageHandles;
using Mgmo.Main.Blog.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Mgmo.Main.Blog.Services
{
    public static class BlogServices
    {
        public static IServiceCollection AddBlogServices(this IServiceCollection services)
        {
            services.AddTransient<IBlogPostsStorageHandler, BlogPostsStorageHandler>();
            services.AddTransient<IBlogPostsBlo, BlogPostsBlo>();
            services.AddSingleton<BlogService>();

            return services;
        }

        public static async Task InitApplications(this IServiceProvider services)
        {
            var blogService = services.GetService<BlogService>();
            blogService.InitializeBlogPostService();
        }
    }
}
