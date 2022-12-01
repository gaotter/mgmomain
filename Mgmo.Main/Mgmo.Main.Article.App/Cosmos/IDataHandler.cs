using Azure.Data.Tables;

namespace Mgmo.Main.Article.App.Cosmos
{
    public interface IDataHandler
    {
        Task<T> Get<T>(string rowKey, string partitionKey) where T : class, ITableEntity, new();
        Task Store<T>(T item) where T : class, ITableEntity, new();
    }
}