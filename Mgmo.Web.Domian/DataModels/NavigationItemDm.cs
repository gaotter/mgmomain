namespace Mgmo.Web.Domian.DataModels
{
    public record class NavigationItemDm
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string StaticName { get; set; } = "";
    }
}
