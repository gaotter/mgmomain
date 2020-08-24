import "./examples.css";
import observableExample from "./observables";

export default function examplesList() {
  const examplesList = document.createElement("div");
  examplesList.classList.add("examples-list");

  const articleListHeader = document.createElement("h1");
  articleListHeader.innerHTML = "Examples";

  const list = document.createElement("ul");

  const examplePanel = document.createElement("div");

  const observableSelection = document.createElement("li");
  observableSelection.innerHTML = "observables example";
  observableSelection.onclick = () => {
    examplePanel.innerHTML = "";
    examplePanel.appendChild(observableExample());
  };

  list.appendChild(observableSelection);

  const listWrapper = document.createElement("div");
  listWrapper.appendChild(list);

  examplesList.appendChild(articleListHeader);
  examplesList.appendChild(listWrapper);
  examplesList.appendChild(examplePanel);

  return examplesList;
}
