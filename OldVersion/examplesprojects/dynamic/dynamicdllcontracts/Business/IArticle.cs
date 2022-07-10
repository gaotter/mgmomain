using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AricleContracts.Business
{
    public interface IArticle
    {
        public string Id { get; init; }
        public string Content { get; }
        public string Title { get; }
        void UpdateTitle(string title);
        void UpdateDescription(string description);        
    }
}
