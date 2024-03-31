using System;
using System.Collections.Generic;
using System.Text;

namespace mgmoarticontracts.Models
{
   public record ArticleModel
    {
        public ArticleModel(string id, string category)
        {
            Id = id;
            Category = category;
        }

        public string Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Published { get; set; }
        public IEnumerator<string> ImageUris { get; set; }
        public bool IsPublished { get; set; }
    }
}
