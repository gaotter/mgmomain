

export default class ArticleData {
    fetchAricles() {
        return fetch("/api/articles");
    }
}