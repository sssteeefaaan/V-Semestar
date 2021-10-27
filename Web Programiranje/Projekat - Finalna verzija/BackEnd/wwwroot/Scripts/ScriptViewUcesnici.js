addEventListener("DOMContentLoaded", () =>
{
    let div = document.body.querySelector(".box");

    let buttonBack = document.createElement("button");
    buttonBack.innerHTML = "Lista disciplina";
    buttonBack.classList.add("BackToTurniri");
    buttonBack.onclick = () => { window.location = `./ViewDisciplineTurnira${ window.location.href.substr(window.location.href.indexOf("?"), window.location.href.indexOf("&") - window.location.href.indexOf("?")) }`; };
    div.appendChild(buttonBack);

    let button = document.createElement("button");
    button.innerHTML = "Ubaci novog učesnika";
    button.classList.add("CreateUcesnik");
    button.onclick = () =>
    { window.location = `./CreateUcesnik${ window.location.href.substr(window.location.href.indexOf("?")) } `; };
    div.appendChild(button);
});