using AricleContracts.Business;
using AricleContracts.Data;
using AricleContracts.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AricleHandler.Aricle
{
    public class Article : IArticle    {

        private IArticleStore store;

        public Article(IArticleStore store)
        {
            this.store = store;
        }

        private string title;
        private string description;
        private string _id;

        public string Content => description;

        public string Title => title;

        public string Id
        {
            get
            {
                return _id;
            }
            init
            {
                _id = value;
            }
        }

        public void UpdateDescription(string description)
        {
            this.description = description;
            StoreArticle();
        }

        public void UpdateTitle(string title)
        {
            this.title = title;
            StoreArticle();
        }

        private void StoreArticle()
        {            
            if(_id == null)
            {
                _id = Guid.NewGuid().ToString();
            }
            store.StoreAricle(new ArticleRecord(_id, title, description));
        }        
    }
}
