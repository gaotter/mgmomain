import _ from "lodash";
import printMe from './print.js';
// styles
import "./style.css";

function component() {
  const element = document.createElement("div");
  const btn = document.createElement('button');

  element.innerHTML = _.join(["Hello", "webpack served"], " ");
  element.classList.add("hello");

  btn.innerHTML = 'Click me';
  btn.onclick = printMe;

  element.appendChild(btn);

  return element;
}

document.body.appendChild(component());
