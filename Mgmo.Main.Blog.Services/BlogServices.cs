using Mgmo.Main.Blog.Core.Blo;
using Mgmo.Main.Blog.Core.Contracts;
using Mgmo.Main.Blog.Infratructure.StorageHandles;
using Microsoft.Extensions.DependencyInjection;

namespace Mgmo.Main.Blog.Services
{
    public static class BlogServices
    {
        public static IServiceCollection AddBlogServices(this IServiceCollection services)
        {
            services.AddTransient<IBlogPostsStorageHandler, BlogPostsStorageHandler>();
            services.AddTransient<IBlogPostsBlo, BlogPostsBlo>();

            return services;
        }
    }
}
