import { Polica } from "./polica.js";

export class VideoKlub
{
    constructor(naziv, id = 0)
    {
        this.naziv = naziv;
        this.id = id;
        this.police = new Array();
        this.container = null;
    }

    dodajPolicu(polica)
    {
        this.police.push(polica);
        if (this.container != null) {
            this.police[this.police.length - 1].nacrtaj(this.container.querySelector(".VideoKlubPrikaz"));
            this.osveziUnos();
        }
    }
    nacrtaj(parent)
    {
        this.container = document.createElement("div");
        this.container.classList.add("VideoKlub");
        parent.appendChild(this.container);

        this.nacrtajHeader();
        this.nacrtajBody();
    }

    nacrtajHeader()
    {
        const header = document.createElement("div");
        header.classList.add("VideoKlubHeader");
        this.container.appendChild(header);

        const h2 = document.createElement("h2");
        h2.innerHTML = `Video klub "${ this.naziv }"`;
        header.appendChild(h2);
    }

    nacrtajBody()
    {
        const body = document.createElement("div");
        body.classList.add("VideoKlubBody");
        this.container.appendChild(body);

        this.nacrtajUnos();
        this.nacrtajPrikaz();
    }
    nacrtajUnos()
    {
        const unos = document.createElement("div");
        unos.classList.add("VideoKlubUnos");
        this.container.childNodes[1].appendChild(unos);

        let div = document.createElement("div");
        div.classList.add("VideoKlubUnosDugmici");
        unos.appendChild(div);

        this.osveziUnos();

        div = document.createElement("div");
        div.classList.add("VideoKlubUnosOstalo");
        unos.appendChild(div);

        let el = document.createElement("label");
        el.innerHTML = "Broj DVD-ova:";
        div.appendChild(el);

        el = document.createElement("input");
        el.type = "number";
        el.min = 1;
        div.appendChild(el);

        el = document.createElement("button");
        el.innerHTML = "Dodaj na policu";
        div.appendChild(el);

        el.addEventListener('click', () =>
        {
            const oznakaPolice = unos.querySelector("input[name='Kategorija']:checked").value;
            const broj = parseInt(unos.querySelector("input[type='number']").value);

            this.police.forEach(polica =>
            {
                if (polica.oznaka == oznakaPolice)
                    polica.dodajDVD(broj);
            });
        });
    }

    osveziUnos()
    {
        const unos = this.container.querySelector(".VideoKlubUnosDugmici");
        if (unos != null) {
            while (unos.childNodes[0] != null) {
                unos.removeChild(unos.childNodes[0]);
            }

            let radio, label, div;
            this.police.map(polica => polica.oznaka).forEach(oznaka =>
            {
                div = document.createElement("div");
                div.classList.add("VideoKlubUnosRadio");
                unos.appendChild(div);

                radio = document.createElement("input");
                radio.type = "radio";
                radio.name = "Kategorija";
                radio.value = oznaka;
                div.appendChild(radio);

                label = document.createElement("label");
                label.innerHTML = oznaka;
                label.htmlFor = oznaka;
                div.appendChild(label);
            });
        }
    }

    nacrtajPrikaz()
    {
        const prikaz = document.createElement("div");
        prikaz.classList.add("VideoKlubPrikaz");
        this.container.childNodes[1].appendChild(prikaz);

        this.police.forEach(polica =>
        {
            polica.nacrtaj(prikaz);
        });
    }
}