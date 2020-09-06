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

  const elementMainPage = document.createElement("div");

  const titleElement = document.createElement("h1");
  titleElement.innerHTML = "Welcome to my vanilla js example page";
  elementMainPage.appendChild(titleElement);

  const examlesList = document.createElement("ul");

  const exampleElementTitle = "Examples";
  const exampleRoute = `#${routing.routes.examples}`;
  const exampleElementListItem = document.createElement("li");

  const elementLink = document.createElement("a");
  elementLink.href = exampleRoute;
  elementLink.innerHTML = exampleElementTitle;

  examlesList.appendChild(exampleElementListItem);

  exampleElementListItem.appendChild(elementLink);

  elementMainPage.appendChild(examlesList);
  element.appendChild(elementMainPage);

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
      default:
        element.innerHTML = "";
        element.appendChild(elementMainPage);
        break;
    }
  });

  return element;
}

document.body.appendChild(component());
