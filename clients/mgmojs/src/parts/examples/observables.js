import { Observable, fromEvent, from, of, combineLatest } from "rxjs";
import { ajax } from "rxjs/ajax";
import {
  tap,
  map,
  delay,
  mergeMap,
  switchMap,
  concatMap,
  elementAt,
  timeout,
} from "rxjs/operators";

export default function observableExample() {
  const observableExample = document.createElement("div");

  function appendParagrapth(parrent, content) {
    const paragraphsElement = document.createElement("p");
    paragraphsElement.innerHTML = content;

    parrent.appendChild(paragraphsElement);
  }

  function setUpNextLogic() {
    let currentIndex = 0;
    const examplesList = [
      () => fromObservableExample(),
      () => pipesObservableExample(),
    ];

    const nextButton = document.createElement("button");
    nextButton.innerHTML = "Next example";
    nextButton.onclick = () => {
      const exampleToShow = examplesList[currentIndex];
      if (currentIndex < examplesList.length) {
        exampleToShow();
        currentIndex = currentIndex + 1;
      }
    };

    observableExample.appendChild(nextButton);
  }

  setUpNextLogic();

  basicObservableExample();

  const getDataButton = document.createElement("button");
  getDataButton.innerHTML = "Get som data";

  return observableExample;

  function basicObservableExample() {
    appendParagrapth(
      observableExample,
      `Eksempel under viser hvordan man lager en observable i sin enkleste form. 
      Ved å implementer en observer som har tre funksjoner: next() som blir kalt hver gang next blir kalt i observable, error() som blir kalt en gang i alle som observer, 
      men som avslutter observable, og complete() som kaller observer complete og avslutter observable .  Om en observable er avsluttet må man lage en ny å subscribe på den`
    );

    observableAsClassExample();
  }

  function fromObservableExample() {
    appendParagrapth(
      observableExample,
      `For å gjøre det enklere å bruke obsevables mot vanlige javascript hendelser eller typer er det laget en del hjelpe funksjoner`
    );
    obsevableFormAnEvent();
  }

  function pipesObservableExample() {
    appendParagrapth(
      observableExample,
      `Pipes gjør det mulig å endre endre/filtrere eller mappe data eller en observable til en ny observable`
    );
    obsevablePipesExample();
  }

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

      // setTimeout(() => {
      //   subscriber.error({ message: "500" });
      // }, 2000);

      //   setTimeout(() => {
      //     subscriber.complete();
      //   }, 3000);

      setTimeout(() => {
        subscriber.next({ message: "am I to late to the game?" });
      }, 4000);

      setTimeout(() => {
        subscriber.complete();
      }, 5000);
    });

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

  // Hjelpe metoder for event osv
  function obsevableFormAnEvent() {
    const observableButton = document.createElement("button");
    observableButton.innerHTML = "Observable from  button";

    const showArrayExample = document.createElement("button");
    showArrayExample.innerHTML = "show observables from array";

    const fromAjaxExampleButton = document.createElement("button");
    fromAjaxExampleButton.innerHTML = "fetch some data from the server";

    observableExample.appendChild(observableButton);
    observableExample.appendChild(showArrayExample);
    observableExample.appendChild(fromAjaxExampleButton);

    const observerOnButtonEvent = new ObserverAsAClass(observableExample);
    const observerOnArray = new ObserverAsAClass(observableExample);
    const observerOnObject = new ObserverAsAClass(observableExample);
    const observerOnServerdata = new ObserverAsAClass(observableExample);
    // her brukes en hjelpemetode som gjør det veldig enkelt å gjøre om et dom event til
    // en obsevable.
    const observableFromButtonEvent = fromEvent(observableButton, "click");

    // setter opp to observable som lytter på click eventet
    observableFromButtonEvent.subscribe(observerOnButtonEvent);

    showArrayExample.onclick = () => {
      const testArray = ["Hei", "på", "deg"];
      // her gjøres en array om til en observable, der hver element blir trigget en etter en.
      const observableFromArray = from(testArray);
      observableFromArray.subscribe(observerOnArray);

      // her generes en observable som vil sende med objektet til all som subscriber, så complete.
      const observableFromObj = of({ message: "jeg er bare et enkelt object" });

      observableFromObj.subscribe(observerOnObject);
    };

    fromAjaxExampleButton.onclick = () => {
      const formAjax = ajax("/api/ping?data=test");

      formAjax.subscribe(observerOnServerdata);
    };
  }

  function obsevablePipesExample() {
    const observableButton = document.createElement("button");
    observableButton.innerHTML = "Observable from  button";

    const showArrayExample = document.createElement("button");
    showArrayExample.innerHTML = "show observables from array";

    const fromAjaxExampleButton = document.createElement("button");
    fromAjaxExampleButton.innerHTML = "fetch some data from the server";

    observableExample.appendChild(observableButton);
    observableExample.appendChild(showArrayExample);
    observableExample.appendChild(fromAjaxExampleButton);

    const observerOnButtonEvent = new ObserverAsAClass(observableExample);
    const observerOnArray = new ObserverAsAClass(observableExample);
    const observerOnServerdata = new ObserverAsAClass(observableExample);
    // her mapper jeg om event objektet i en fromEventet til det jeg ønsker brukeren skal se.
    const observableFromButtonEvent = fromEvent(observableButton, "click").pipe(
      map((event) => "jeg vil gjøre noe basert på dette klikket")
    );

    observableFromButtonEvent.subscribe(observerOnButtonEvent);

    showArrayExample.onclick = () => {
      function delayPromise(data) {
        return new Promise((r) => setTimeout(() => r(data), 1000));
      }

      const testArray = [
        "Hei",
        "på",
        "deg",
        "har",
        "du",
        "det",
        "bra",
        "i",
        "dag",
        "?",
        "😋😋",
      ];
      // her gjøres en array om til en observable, der hver element blir trigget en etter en.
      const observableFromArray = from(testArray).pipe(
        concatMap((v) => from(delayPromise(v)))
      );
      observableFromArray.subscribe(observerOnArray);
    };  

    // setter opp to observable som lytter på click eventet
    const callServerButtonEvent = fromEvent(fromAjaxExampleButton, "click");

    // const mappedToFromAjax = callServerButtonEvent.pipe(
    //   switchMap((e) => ajax("/api/ping?data=test")),
    //   map((r) => r.response)
    // );

      // bruker en compinder to å slå sammen to observables
      const twoInOne = combineLatest([
        ajax("/api/ping?data=kall1"),
        ajax("/api/ping?data=kall2"),
      ]).pipe(
        map(([response1, response2]) => {
          return {
            response1: response1.response,
            response2: response2.response,
          };
        })
      );

    const mappedToFromAjax = callServerButtonEvent.pipe(
      switchMap((e) => twoInOne)
    );    

    mappedToFromAjax.subscribe(observerOnServerdata);
  }
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
    this._currentElement.innerHTML = "";
    const text = `I got some data from the observable yay!! 😎: ${JSON.stringify(
      data
    )} at ${new Date().getTime()}`;

    this._currentElement.innerHTML = text;
  }

  error(err) {
    console.error("something is not right", err);
  }
  complete() {
    console.log("done");
  }
}
