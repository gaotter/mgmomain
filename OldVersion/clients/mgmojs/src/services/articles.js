

export default class Articles {

    constructor() {}
    fetchArticlesOldStyle() {
        return fetch("/api/articles");
    }
}