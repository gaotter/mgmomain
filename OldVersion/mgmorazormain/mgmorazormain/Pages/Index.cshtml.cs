using mgmoarticleconnector.ViewModels;
using mgmomain.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgmorazormain.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly IArticleService articleService;

        public IEnumerable<ArticleViewModel> Articles
        { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IArticleService articleService)
        {
            this.logger = logger;
            this.articleService = articleService;
        }

        public void OnGet()
        {
            Articles = articleService.GetAllAzureArticles();
        }
    }
}
