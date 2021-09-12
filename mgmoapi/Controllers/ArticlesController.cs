﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mgmoarticleconnector.ViewModels;
using mgmomain.Data;
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
        
        public IEnumerable<ArticleViewModel> GetAllArticles()
        {
            return _articleService.GetAllAzureArticles();
        }

        [HttpPost]
        public async Task<ActionResult<ArticleViewModel>> PostArticle(ArticleViewModel article)
        {
            return await _articleService.StoreArticle(article);
        }
    }
}
