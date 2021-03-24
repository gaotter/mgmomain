using mgmoarticontracts.Models;
using mgmoconnector.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace mgmoconnector.Mapping
{
    static class ArticleToViewModel
    {
        public static ArticleViewModel Map(ArticleModel model)
        {
            var mappedViewModel = new ArticleViewModel
            {
                Title = model.Title,
                Category = model.Category,
                Content = model.Content,
                PublishDate = model.Published
            };

            return mappedViewModel;
        }
    }
}
