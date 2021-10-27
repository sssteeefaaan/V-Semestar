import { Polje } from "./polje.js";

export class Trougao
{
    constructor(brojNivoa, imeAutora)
    {
        this.brojNivoa = brojNivoa;
        this.polja = new Array();
        this.container = null;
        this.imeAutora = imeAutora;
    }

    crtaj(host)
    {
        if(!host)
            throw new Error("Nema host");

        this.container = document.createElement("div");
        this.container.className = "container";
        host.appendChild(this.container);

        this.crtajFormu();
    }

    crtajFormu()
    {
        const containerForme = document.createElement("div");
        containerForme.className = "containerForme";
        this.container.appendChild(containerForme);

        const gornji = document.createElement("div");
        gornji.className = "gornji";
        containerForme.appendChild(gornji);

        const donji = document.createElement("div");
        donji.className = "donji";
        containerForme.appendChild(donji);

        const playground = document.createElement("div");
        playground.className = "playground";
        this.container.appendChild(playground);

        const imeAutora = document.createElement("h3");
        imeAutora.className = "naslov";
        imeAutora.innerHTML = "Autor: " + this.imeAutora;
        gornji.appendChild(imeAutora);

        const brojNivoa = document.createElement("label");
        donji.appendChild(brojNivoa);

        const unos = document.createElement("input");
        unos.type = "number";
        unos.className = "unos";
        donji.appendChild(unos);

        const generisi = document.createElement("button");
        generisi.className = "generisi";
        generisi.innerHTML = "Genrerisi";
        donji.appendChild(generisi);

        generisi.onclick = (ev) =>
        {
            this.dogadjaj(playground)
        }


    }

    dogadjaj(playground)
    {
        const nivo = this.container.querySelector(".unos");
        let broj = nivo.value;
        this.crtajPrikaz(broj, playground);
    }

    crtajPrikaz(broj, playground)
    {
        playground.innerHTML = "";

        let polje = null;

        let polja = 1;


        for(let i = 0; i < broj; i++)
        {
            const red = document.createElement("div");
            red.className = "red";
            playground.appendChild(red);

            this.polja[i] = new Array();


            for(let j = 0; j< i+1; j++)
            {
                
                if(j < 1 || i== j)
                {
                    polje = new Polje(1);

                } else {
                    polje = new Polje(this.polja[i-1][j-1].broj + this.polja[i-1][j].broj);
                }
                this.polja[i].push(polje);
                polje.Crtaj(red);
            }
            polja++;
        }
    }
}