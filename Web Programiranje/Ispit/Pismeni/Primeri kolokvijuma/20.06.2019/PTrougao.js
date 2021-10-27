import { Polje } from "./Polje.js";

export class PTrougao
{
    constructor(autor = "Nepoznato", godStud = "Nepoznato", brojNivoa = 3)
    {
        this.autor = autor;
        this.godStud = godStud;
        this.brojNivoa = brojNivoa;
        this.nivoi = [];
        this.container = null;
    }

    nacrtajTrougao(div)
    {
        if (div == null)
            throw Error("Niste uneli div");
        this.container = document.createElement("div");
        this.container.className = "TrougaoContainer";
        div.appendChild(this.container);

        this.nacrtajHeader();
        this.osveziNivoe();
    }

    nacrtajHeader()
    {
        const header = document.createElement("div");
        header.className = "TrougaoHeader";
        this.container.appendChild(header);

        let element = document.createElement("h3");
        element.innerHTML = `Autor: ${ this.autor } - godina: ${ this.godStud }`;
        header.appendChild(element);

        const unos = document.createElement("div");
        header.appendChild(unos);

        element = document.createElement("label");
        element.innerHTML = "Broj nivoa:";
        unos.appendChild(element);

        element = document.createElement("input");
        element.type = "number";
        element.min = 3;
        element.placeholder = "broj mora biti veći od 2";
        unos.appendChild(element);

        element = document.createElement("button");
        element.innerHTML = "Generiši";
        unos.appendChild(element);

        element.onclick = () =>
        {
            const brNivoa = parseInt(header.querySelector("input").value);
            if (brNivoa > 3) {
                this.brojNivoa = brNivoa;
                this.osveziNivoe();
            }
            else
                alert("Broj nivoa mora biti veći od 2!");
        };
    }

    osveziNivoe()
    {
        let nivoi = this.container.querySelector(".TrougaoNivoi");
        if (nivoi == null) {
            nivoi = document.createElement("div");
            nivoi.className = "TrougaoNivoi";
            this.container.appendChild(nivoi);
        }

        this.obrisiNivoe();

        let nivo, nizPolja;
        for (let i = 0; i < this.brojNivoa; i++) {
            nivo = document.createElement("div");
            nivo.className = "Nivo";
            nivoi.appendChild(nivo);

            nizPolja = [];
            for (let j = 0; j < i + 1; j++) {
                nizPolja.push(new Polje(i, j));
                nizPolja[j].nacrtajPolje(nivo);
            }
            this.nivoi.push(nizPolja);
        }
    }

    obrisiNivoe()
    {
        let nivoi = this.container.querySelector(".TrougaoNivoi");
        if (nivoi != null) {
            while (nivoi.childNodes[0] != null) {
                nivoi.removeChild(nivoi.childNodes[0]);
            }
        }
    }
}