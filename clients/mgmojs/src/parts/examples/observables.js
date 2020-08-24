export default function observableExample() {
    const observableExample = document.createElement("div");

    observableExample.innerHTML = `En observable kan gi eller pushe verdier til flere observsers. 
    Når man kjører en next i en observable kjører kaller den en en av tre verdier i en observers om subscriber på en obsevable`;

    return observableExample;
}