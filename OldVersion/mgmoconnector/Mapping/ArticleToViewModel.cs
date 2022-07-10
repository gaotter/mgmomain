using mgmoarticontracts.Models;
using mgmoarticleconnector.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace mgmoarticleconnector.Mapping
{
    static class ArticleToViewModel
    {
        public static ArticleViewModel Map(ArticleModel model)
        {
            var mappedViewModel = new ArticleViewModel
            {
                Id = model.Id,
                Title = model.Title,
                Category = model.Category,
                Content = model.Content,
                PublishDate = model.Published
            };

            return mappedViewModel;
        }

        public static ArticleModel Map(ArticleViewModel model)
        {
            var articleModel = new ArticleModel(model.Id, model.Category)
            {
                Title = model.Title,
                Content = model.Content,
                ImageUris = model.ImageUris,
                IsPublished = model.IsPublished,
                Published = model.PublishDate
            };

            return articleModel;
        }
    }
}
