using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace mgmoarticleconnector.ViewModels
{
    public class ArticleViewModel
    {
        public string Id { get; set; }
        public string Category { get; set; }

        public string Title { get; set; }

        public bool IsPublished { get; set; }

        public DateTime PublishDate { get; set; }

        public string Content { get; set; }

        public IEnumerator<string> ImageUris { get; set; }
    }
}
