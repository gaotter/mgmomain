using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace mgmoarticledata.Models
{
    class ArticleData : TableEntity
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public IEnumerator<string> ImageUris { get; set; }
    }
}
