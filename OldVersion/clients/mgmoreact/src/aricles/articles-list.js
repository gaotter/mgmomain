
import React from 'react';
import ArticleData from './aricles.data';


export default class ArticleList extends React.Component {

    articles = [];
    articleData = new ArticleData();
    async getArticleList() {
       const response = await this.articleData.fetchAricles();
       const responseData = await response.json();
       console.log("reasonse data", responseData);
       
    }

    render() {
        return (<div className="article-list">
            <button onClick={() => this.getArticleList()}>Get Articles</button>
        </div>)
    }
}