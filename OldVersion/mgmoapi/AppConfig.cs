namespace mgmoapi
{
    public class AppConfig
    {
        public AzureAd AzureAd { get; set; }
    }

    public class AzureAd
    {
        public string Instance { get; set; }
        public string Domain { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string CallbackPath { get; set; }

        public string Audience { get; set; }
    }
}
