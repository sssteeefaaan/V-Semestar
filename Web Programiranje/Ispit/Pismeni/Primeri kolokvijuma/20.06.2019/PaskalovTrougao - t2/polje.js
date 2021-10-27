export class Polje
{
    constructor(vrednost = 1)
    {
        this.vrednost = vrednost;
    }

    crtaj(host)
    {
        let kockica = document.createElement("div");
        kockica.className = "polje-div"+ this.vrednost ;
        kockica.innerHTML = this.vrednost;
        host.appendChild(kockica);
        return kockica;
    }
}