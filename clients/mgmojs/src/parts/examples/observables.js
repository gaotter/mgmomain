import { Observable } from "rxjs";
import { get } from "lodash";

export default function observableExample() {
  const observableExample = document.createElement("div");

  function appendParagrapth(parrent, content) {
    const paragraphsElement = document.createElement("p");
    paragraphsElement.innerHTML = content;

    parrent.appendChild(paragraphsElement);
  }

  appendParagrapth(
    observableExample,
    `En observable kan gi eller pushe verdier til flere observsers. 
    Når man kjører en next i en observable kjører kaller den en en av tre verdier i en observers om subscriber på en obsevable`
  );
  const getDataButton = document.createElement("button");
  getDataButton.innerHTML = "Get som data";

  observableAsClassExample();
  observableExample.appendChild(getDataButton);

  return observableExample;

  // Basic observable class and direct
  function observableAsClassExample() {
    // en observable i sin enkleste form. Den den for inn en subscriber som den kaller
    // next. Når next kalles vil alle observere som subscriber bli kalt.
    const observable = new Observable((subscriber) => {
      // når blir denne kalt?
      console.log("subscribe on me!!");

      // Men en gang noen subscriber for de denne meldingen
      subscriber.next({ message: "data directly" });

      // simulere at det tar litt tid.
      setTimeout(() => {
        subscriber.next({ message: "from timer" });
      }, 1000);

      //   setTimeout(() => {
      //     subscriber.error({ message: "500" });
      //   }, 2000);

      //   setTimeout(() => {
      //     subscriber.complete();
      //   }, 3000);

      setTimeout(() => {
        subscriber.next({ message: "am I to late to the game?" });
      }, 4000);
    });

    observableExample.appendChild(getDataButton);

    const observer1 = new ObserverAsAClass(observableExample);
    const observer2 = new ObserverAsAClass(observableExample);

    console.log("first observer subscribe");
    observable.subscribe(observer1);
    console.log("second observer subscribe");
    observable.subscribe(observer2);
    console.log("third observer subscribe");
    observable.subscribe(
      (d) => console.log("just what to log the data", d),
      (err) => console.error("Nooo", err)
    );
  }

  function obsevableFormAnEvent() {}
}

class ObserverAsAClass {
  constructor(parrentElement) {
    parrentElement;
    this._currentElement = document.createElement("div");

    this._currentElement.innerHTML = "no data";
    parrentElement.appendChild(this._currentElement);
  }
  next(data) {
    console.log("sub", data);
    const text = `I got some data from the observable yay!! data: ${JSON.stringify(
      data
    )}`;

    this._currentElement.innerHTML = text;
  }

  error(err) {
    console.error("something is not right", err);
  }
  complete() {
    console.log("done");
  }
}
