import _ from "lodash";
import Articles from "./services/articles";
import artilceList from "./parts/article-list/articles-list";
import examplesList from "./parts/examples/examples";
import * as routing from "./routing/routes";
// styles
import "./style.css";

function component() {
  const articles = new Articles();

  const element = document.createElement("div");
  element.classList.add("main");

  routing.getCurrentRoute().subscribe((e) => {
    console.log("found route", e.foundRoute);
    switch (e.foundRoute) {
      case routing.routes.aricles:
        element.innerHTML = "";
        element.appendChild(artilceList());
        break;
      case routing.routes.examples:
        element.innerHTML = "";
        element.appendChild(examplesList());
        break;
    }
  });

  return element;
}

document.body.appendChild(component());
