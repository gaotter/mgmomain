import "./articles-list.css";

export default function articleList() {
  const articleListMain = document.createElement("div");
  articleListMain.classList = "article-lists";

  const articleListHeader = document.createElement("h1");
  articleListHeader.innerHTML = "Article lists";

  articleListMain.appendChild(articleListHeader);

  return articleListMain;
}
