namespace Mgmo.Main.Infratructure.Entities.Contracts
{
    public interface IStoreService
    {
        Task<T> Get<T>(string id, string subid);
        Task<IEnumerable<T>> GetAll<T>(string id);
        Task Store<T>(string id, string subid, T entity);
    }
}