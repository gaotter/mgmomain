using Mgmo.Web.Domian.DataModels;

namespace Mgmo.Web.Services.Navigation.Contracts
{
    public interface NavigationDCon
    {
        public Task<IEnumerable<NavigationItemDm>> GetNavigationItems();
    }
}
