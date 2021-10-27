import { Silos } from "./silos.js";

export class Fabrika
{
    constructor(naziv, id = 0)
    {
        this.id = id;
        this.naziv = naziv;
        this.silosi = new Array();

        this.container = null;
    }

    dodajSilos(silos)
    {
        this.silosi = [...this.silosi, silos];
        if (this.container != null)
            this.osveziPrikaz();
    }

    nacrtajFabriku(container)
    {
        if (container == null)
            throw Error("Canvas is null!");
        this.container = document.createElement("div");
        this.container.classList.add("Fabrika");
        container.appendChild(this.container);

        this.nacrtajUnos();
        this.nacrtajPrikaz();
    }

    nacrtajUnos()
    {
        const header = document.createElement("div");
        header.classList.add("FabrikaUnos");
        this.container.appendChild(header);

        let elDiv = document.createElement("div");
        header.appendChild(elDiv);
        let el = document.createElement("label");
        el.innerHTML = "Silos:";
        elDiv.appendChild(el);

        this.izlistajSilose();

        elDiv = document.createElement("div");
        header.appendChild(elDiv);
        el = document.createElement("label");
        el.innerHTML = "Količina:";
        elDiv.appendChild(el);

        el = document.createElement("input");
        el.type = "number";
        el.placeholder = "Unesti količinu";
        el.min = 1;
        elDiv.appendChild(el);

        el = document.createElement("button");
        el.innerHTML = "Sipaj u silos";
        header.appendChild(el);

        el.addEventListener('click', () =>
        {
            const oznaka = header.querySelector("select[name='izbor']").value;
            const kol = parseInt(header.querySelector("input[type='number']").value);

            if (kol > 0)
                this.silosi.forEach(silos =>
                {
                    if (silos.o == oznaka) {
                        silos.sipaj(kol);
                    }
                });
            else
                alert("Količina mora biti broj veći od 0");
        });
    }

    izlistajSilose()
    {
        let el = this.container.querySelector("select[name='izbor']");
        if (el == null) {
            el = document.createElement("select");
            el.name = "izbor";
            this.container.querySelector(".FabrikaUnos>div").appendChild(el);
        }

        while (el.childNodes[0] != null) {
            el.removeChild(el.childNodes[0]);
        }

        let opt;
        this.silosi.forEach(silos =>
        {
            opt = document.createElement("option");
            opt.innerHTML = silos.o;
            el.appendChild(opt);
        });
    }

    nacrtajPrikaz()
    {
        const div = document.createElement("div");
        div.classList.add("FabrikaPrikaz");
        this.container.appendChild(div);

        let el = document.createElement("h2");
        el.innerHTML = this.naziv;
        div.appendChild(el);

        const miniDiv = document.createElement("div");
        miniDiv.classList.add("FabrikaSilosi");
        div.appendChild(miniDiv);

        this.osveziPrikaz();
    }

    osveziPrikaz()
    {
        this.izlistajSilose();

        let div = this.container.querySelector(".FabrikaSilosi");
        while (div.childNodes[0] != null) {
            div.removeChild(div.childNodes[0]);
        }

        this.silosi.forEach(silos =>
        {
            silos.nacrtajSilos(div);
        });
    }
}