using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AricleContracts.Business
{
    public interface IArticles
    {
        IEnumerable<IArticle> GetAllArticles();
        IArticle GetArticle(string id);
        IArticle CreateArtilce();
    }
}
