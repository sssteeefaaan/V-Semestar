addEventListener("DOMContentLoaded", () =>
{
    let div = document.body.querySelector(".box");

    let buttonBack = document.createElement("button");
    buttonBack.innerHTML = "Lista turnira";
    buttonBack.classList.add("BackToTurniri");
    buttonBack.onclick = () => { window.location = `./ViewTurniri`; };
    div.appendChild(buttonBack);

    let button = document.createElement("button");
    button.innerHTML = "Napravi novu disciplinu";
    button.classList.add("CreateDisciplina");
    button.onclick = () => { window.location = `./CreateDisciplina${ window.location.href.substr(window.location.href.indexOf("?")) } `; };
    div.appendChild(button);
});