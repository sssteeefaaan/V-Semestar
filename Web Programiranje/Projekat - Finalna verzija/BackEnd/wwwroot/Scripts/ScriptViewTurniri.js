addEventListener("DOMContentLoaded", () =>
{
    let div = document.body.querySelector(".box");
    let button = document.createElement("button");
    button.innerHTML = "Napravi novi turnir";
    button.classList.add("CreateTurnir");
    button.onclick = () => { window.location = "./CreateTurnir" };
    div.appendChild(button);
});