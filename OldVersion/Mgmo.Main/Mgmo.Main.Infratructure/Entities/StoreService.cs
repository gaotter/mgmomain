using Azure.Data.Tables;
using Azure.Identity;
using Mgmo.Main.Infratructure.Entities.Contracts;

namespace Mgmo.Main.Infratructure.Entities
{
    public class StoreService : IStoreService
    {
        private readonly Dictionary<string, object> _store = new Dictionary<string, object>();
        public async Task Store<T>(string id, string subid, T entity)
        {
            _store[$"{id}-{subid}"] = entity;
        }

        public async Task<T> Get<T>(string id, string subid)
        {
            return (T)_store[$"{id}-{subid}"];
        }

        public async Task<IEnumerable<T>> GetAll<T>(string id)
        {
            return _store.Where(x => x.Key.StartsWith(id)).Select(x => (T)x.Value);
        }

        // http://127.0.0.1:10002/devstoreaccount1
        private dynamic GetTableClient()
        {
            var client = new TableClient (new Uri("http://127.0.0.1:10002/devstoreaccount1/"), new DefaultAzureCredential());
        }
        
    }
}
