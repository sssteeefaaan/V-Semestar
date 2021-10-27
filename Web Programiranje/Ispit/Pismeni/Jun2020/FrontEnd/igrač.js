export class Igrac
{
    constructor(ime = "Unknown", godine = 0, ATP = 0, poeni = new Array(), slika = null)
    {
        this.ime = ime;
        this.godine = godine;
        this.ATP = ATP;
        this.poeni = poeni;
        if (this.poeni[0] == null)
            this.poeni.push(0);
        this.slika = slika;

        this.container = null;
    }

    nacrtaj(parent)
    {
        this.container = document.createElement("div");
        this.container.classList.add("Igrac");
        parent.appendChild(this.container);

        let el;
        [this.slika, `Ime: ${ this.ime }`, `Godine: ${ this.godine }`, `ATP rang: ${ this.ATP }`].forEach((element, ind) =>
        {
            if (ind == 0) {
                el = document.createElement("img");
                el.src = this.slika;
                this.container.appendChild(el);
            }
            else {
                el = document.createElement("label");
                el.innerHTML = element;
                this.container.appendChild(el);
            }
        });
    }
}