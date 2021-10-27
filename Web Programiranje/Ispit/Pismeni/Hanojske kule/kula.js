import { Deo } from "./deo.js";

export class Kula
{
    constructor(w, h, brojDelova)
    {
        this.w = w;
        this.h = h;
        this.brojDelova = brojDelova;
        this.redovi = [];
        this.delovi = [];
        this.kliknuto = false;
        this.container = null;
    }

    nacrtajKulu(host)
    {
        this.container = Deo.napraviElement("div", host, "Kula");
        this.container.style.width = this.w + "px";
        this.container.style.height = this.h + "px";
        for (var i = 0; i < this.brojDelova; i++) {
            this.redovi.push(Deo.napraviElement("div", this.container, "Red"));
            this.delovi.push(new Deo(this.w * Math.exp(-i / this.brojDelova), this.h / (this.brojDelova + 1), this.brojDelova - i));
            this.delovi[i].nacrtajDeo(this.redovi[i]);
        }
        this.container.onclick = (el) =>
        {
            if (this.kliknuto = !this.kliknuto)
                this.container.style.border = "5px solid black";
            else
                this.container.style.border = "1px solid black";
        };
    }

    dodajRed(red)
    {
        this.container.appendChild(red[0]);
        this.redovi.push(red[0]);
        this.delovi.push(red[1]);
    }

    ukloniRed()
    {
        if (this.redovi.length > 0) {
            let ret = [this.redovi.pop(), this.delovi.pop()];
            ret[0].parentNode.removeChild(ret[0]);
            return ret;
        }
        return null;
    }
}