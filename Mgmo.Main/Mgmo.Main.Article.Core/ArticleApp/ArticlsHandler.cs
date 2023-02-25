using Mgmo.Main.Article.Core.Interfaces;
using Mgmo.Main.Article.Infratructure.Interfaces.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mgmo.Main.Article.Core.ArticleApp
{
    public class ArticlsHandler : IArticlsHandler
    {
        private readonly IArticleStore articleStore;

        public ArticlsHandler(IArticleStore articleStore)
        {
            this.articleStore = articleStore;
        }


    }
}
