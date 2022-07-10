using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mgmoarticleconnector.ViewModels;
using mgmomain.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace mgmoapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArticlesController : ControllerBase
    {
        public IArticleService _articleService;

        public ArticlesController(IArticleService articleService)
        {
            _articleService = articleService;
        }
        
        [HttpGet("articles")]
        public IEnumerable<ArticleViewModel> GetAllArticles()
        {
            return _articleService.GetAllAzureArticles();
        }

        [HttpPost("articles")]
        public async Task<ActionResult<ArticleViewModel>> PostArticle(ArticleViewModel article)
        {
            return await _articleService.StoreArticle(article);
        }
    }
}
