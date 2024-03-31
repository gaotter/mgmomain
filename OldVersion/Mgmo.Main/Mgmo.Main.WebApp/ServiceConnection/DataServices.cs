using Mgmo.Main.Infratructure.Entities;
using Mgmo.Main.Infratructure.Entities.Contracts;

namespace Mgmo.Main.WebApp.ServiceConnection
{
    public static class DataServices
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            services.AddSingleton<IStoreService, StoreService>();
        }
    }
}
