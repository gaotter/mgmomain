using Mgmo.Main.Article.App.ArticleData;

namespace Mgmo.Main.Article.UnitTests
{
    public class ArticleTests
    {
        [Fact]
        public void GetArticle_should_return_a_article_using_id()
        {
            var article = new ArticleApp().GetArticle("1");

            Assert.Equal("1", article.Id);
            Assert.Equal("Title", article.Title);
            Assert.Equal("Content", article.Content);
            Assert.Equal("Author", article.Author);
            Assert.Equal("Category", article.Category);
            Assert.Equal("Tags", article.Tags);
            Assert.Equal(new DateTime(2021, 1, 1), article.Created);
            Assert.Equal(new DateTime(2021, 1, 1), article.Updated);
            
        }
    }
}