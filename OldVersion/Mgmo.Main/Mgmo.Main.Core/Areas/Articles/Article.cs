using Mgmo.Main.Infratructure.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mgmo.Main.Core.Areas.Articles
{
    public record Article
    {
        public Article(IStoreService storeService, string id, string title, string content, string author, DateTime created, DateTime updated, IEnumerable<string> tags)
        {
            Id = id;
            Title = title;
            Content = content;
            Author = author;
            Created = created;
            Updated = updated;
            Tags = tags;
        }

        public string Id { get; init; }
        public string Title { get; init; }
        public string Content { get; init; }
        public string Author { get; init; }
        public DateTime Created { get; init; }
        public DateTime Updated { get; init; }
        public IEnumerable<string> Tags { get; init; }

        public async Task Store(IStoreService storeService)
        {
            await storeService.Store("articles", Id, this);
        }
    }
}
