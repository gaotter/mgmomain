import "./examples.css";
import observableExample from "./observables";

export default function examplesList() {
  const examplesList = document.createElement("div");
  examplesList.classList.add("examples-list");

  const articleListHeader = document.createElement("h1");
  articleListHeader.innerHTML = "Examples";

  const examplePanel = document.createElement("div");

  const list = setUpExampleList();

  const listWrapper = document.createElement("div");
  listWrapper.appendChild(list);

  examplesList.appendChild(articleListHeader);
  examplesList.appendChild(listWrapper);
  examplesList.appendChild(examplePanel);

  return examplesList;

  function setUpExampleList() {
    const list = document.createElement("ul");

    const observableSelection = setUpObservableExambleItem();

    list.appendChild(observableSelection);
    return list;
  }

  function setUpObservableExambleItem() {
    const observableSelection = document.createElement("li");
    observableSelection.innerHTML = "observables example";
    observableSelection.onclick = () => {
      examplePanel.innerHTML = "";
      examplePanel.appendChild(observableExample());
    };
    return observableSelection;
  }
}
