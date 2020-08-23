import _ from "lodash";
import Articles from './services/articles';
// styles
import "./style.css";

function component() {
  const articles = new Articles();

  const element = document.createElement("div");
  const btn = document.createElement('button');

  element.innerHTML = _.join(["Hello", "webpack served"], " ");
  element.classList.add("hello");

  btn.innerHTML = 'Click me';
  btn.onclick = () => {
      articles.fetchArticlesOldStyle().then(response => {
        response.json().then(data => {
            console.log("response data is ", data);
        });
      })
  };

  element.appendChild(btn);

  return element;
}

document.body.appendChild(component());
