import { MeteoPodatak } from "./MeteoPodatak.js";

export class Grad
{
    constructor(naziv, godinaMerenja)
    {
        this.naziv = naziv;
        this.god = godinaMerenja;
        this.podaci = new Array();

        this.container = null;
    }

    dodajMesec(mesec)
    {
        this.podaci.push(mesec);
        if (this.container != null)
            this.osveziPrikaz();
    }

    nacrtajPrikaz(container)
    {
        this.container = document.createElement("div");
        this.container.classList.add("Grad");
        container.appendChild(this.container);

        this.nacrtajHeader();
        this.osveziPrikaz();
    }

    nacrtajHeader()
    {
        const header = document.createElement("div");
        header.classList.add("GradHeader");
        this.container.appendChild(header);

        let el = document.createElement("h3");
        el.innerHTML = `Grad ${ this.naziv }, godina: ${ this.god }.`;
        header.appendChild(el);

        el = document.createElement("div");
        el.classList.add("ButtonDiv");
        header.appendChild(el);

        let radio, lbl;
        ["Temperatura", "Padavine", "Broj sunčanih dana"].forEach((val, ind) =>
        {
            radio = document.createElement("input");
            radio.type = "radio";
            radio.name = "izbor";
            radio.value = val[0];
            if (ind == 0)
                radio.checked = true;
            el.appendChild(radio);

            lbl = document.createElement("label");
            lbl.forHTML = val[0];
            lbl.innerHTML = val;
            el.appendChild(lbl);
        });

        el = document.createElement("button");
        el.innerHTML = "Prikaži";
        el.name = "Prikaži";
        header.appendChild(el);
        el.addEventListener('click', () =>
        {
            this.osveziPrikaz();
        });
    }

    osveziPrikaz()
    {
        let prikaz = this.container.querySelector(".GradPrikaz");
        if (prikaz == null) {
            prikaz = document.createElement("div");
            prikaz.classList.add("GradPrikaz");
            this.container.appendChild(prikaz);
        }

        let max = 0;
        const tip = this.container.querySelector(".GradHeader>.ButtonDiv>input[type='radio']:checked").value;
        if (tip == "T")
            max = Math.max(...this.podaci.map(el => el.temp));
        else if (tip == "P")
            max = Math.max(...this.podaci.map(el => el.pad));
        else
            max = Math.max(...this.podaci.map(el => el.sun));
        console.log(max);

        this.podaci.forEach(el =>
        {
            el.nacrtajPodatak(prikaz, tip, max);
        });
    }
}