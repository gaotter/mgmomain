using Mgmo.Web.Domian.DomainModels;

namespace Mgmo.Web.Services.Navigation.Contracts
{
    public interface NavigationCon
    {
        public Task<IEnumerable<NavigationItemDo>> GetNavigationItems();
    }
}
