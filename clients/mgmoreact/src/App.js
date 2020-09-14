import React from "react";
import ArticleList from "./aricles/articles-list";
import UseRxjs from "./exampels/rxjs/using-rxjs";
import "./App.css";

function App() {
  return (
    <div className="main">
      <ArticleList></ArticleList>
      <UseRxjs></UseRxjs>
    </div>
  );
}

export default App;
