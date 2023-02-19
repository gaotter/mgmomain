using Mgmo.Main.Article.Data.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Mgmo.Main.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public AppConfig AppConfig { get; set; } = null!;

        public IndexModel(IOptionsSnapshot<AppConfig> appConfig, ILogger<IndexModel> logger)
        {
            _logger = logger;
            AppConfig = appConfig.Value;
        }

        public void OnGet()
        {

        }
    }
}