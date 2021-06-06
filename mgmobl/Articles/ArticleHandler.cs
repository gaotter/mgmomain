﻿using mgmoarticontracts.Articles;
using mgmoarticontracts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace mgmoarticleblo.Articles
{
    public class ArticleHandler : IAricleHandler
    {
        private IArticleData _articleData;
        public ArticleHandler(IArticleData articleData)
        {
            _articleData = articleData;
        }

        public ArticleModel NewArticle(string id, string category)
        {
            return new ArticleModel(id, category);
        }

        public ArticleModel StoreChanges(ArticleModel articleModel)
        {
            throw new NotImplementedException();
        }

        ArticleModel IAricleHandler.GetArticle(string category, string articleId)
        {
            return _articleData.GetArticle(articleId, "");
        }

        IEnumerable<ArticleModel> IAricleHandler.GetArticles(string category)
        {
            return _articleData.GetArticles(category);
        }


    }
}
