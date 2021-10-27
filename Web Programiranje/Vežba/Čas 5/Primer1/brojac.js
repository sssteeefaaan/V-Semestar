export class Brojac
{
    constructor(vrednost)
    {
        this.trVrednost = vrednost;
    }

    crtaj(host)
    {
        if (!host)
            throw new Error("Host ne postoji!");
        const dugme = document.createElement("button");
        dugme.className = "brojac";
        // dugme.classList.add("brojac");
        dugme.innerHTML = this.trVrednost;
        host.appendChild(dugme);
        dugme.onclick = (el) =>
        {
            // 
            this.smanji(dugme);
        }
    }

    smanji(d)
    {
        this.trVrednost--;
        d.innerHTML = this.trVrednost;
        if (this.trVrednost === 0)
            d.classList.add("crveno");
    }
}