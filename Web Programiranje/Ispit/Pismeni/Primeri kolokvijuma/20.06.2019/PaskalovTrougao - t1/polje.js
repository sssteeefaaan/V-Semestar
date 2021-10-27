export class Polje
{
    constructor(broj)
    {
        (!broj) ? this.broj = 1 : this.broj = broj;
    }

    Crtaj(host)
    {
        if(!host)
            throw new Error("Nema");

        const miniPolje = document.createElement("div");
        miniPolje.className = "miniPolje";   
        miniPolje.innerHTML = this.broj;
        host.appendChild(miniPolje); 
    }
}