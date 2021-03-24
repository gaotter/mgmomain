using System;
using System.Collections.Generic;
using System.Text;

namespace mgmoarticontracts.Models
{
   public class ArticleModel
    {
        public string Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Published { get; set; }
        public IEnumerator<string> ImageUris { get; set; }
    }
}
