import _ from "lodash";
import Articles from './services/articles';
import artilceList from './parts/article-list/articles-list';
// styles
import "./style.css";

function component() {
  const articles = new Articles();

  const element = document.createElement("div"); 
  element.classList.add("main");

  element.appendChild(artilceList());
  return element;
}

document.body.appendChild(component());
