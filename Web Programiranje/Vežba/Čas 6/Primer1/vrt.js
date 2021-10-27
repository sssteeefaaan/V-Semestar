import { Lokacija } from "./lokacija.js";

export class Vrt
{
    constructor(naziv, n, m, kapacitet)
    {
        this.naziv = naziv;
        this.n = n;
        this.m = m;
        this.kapacitet = kapacitet;
        this.kontejner = null;
        this.lokacije = [];
    }

    dodajLokaciju(lok)
    {
        this.lokacije.push(lok);
    }

    crtajVrt(host)
    {
        if (!host)
            throw new Error("Nije prosledjen host!");
        this.kontejner = document.createElement("div");
        this.kontejner.classList.add("kontejner");
        host.appendChild(this.kontejner);

        let div = document.createElement("div");
        let naslov = document.createElement("h2");
        naslov.innerHTML = this.naziv;
        div.className = "Naslov";
        div.appendChild(naslov);
        this.kontejner.appendChild(div);

        div = document.createElement("div");
        div.className = "Sadrzaj";
        this.kontejner.appendChild(div);
        this.crtajFormu(div);
        this.crtajLokacije(div);
    }

    crtajFormu(div)
    {
        const kontForma = document.createElement("div");
        kontForma.className = "kontForma";
        div.appendChild(kontForma);

        let divBox = document.createElement("div");
        divBox.classList.add("Section");
        divBox.classList.add("UnosZivotinja");

        var elLabela = document.createElement("h3");
        elLabela.innerHTML = "Unos životinja:";

        divBox.appendChild(elLabela);
        kontForma.appendChild(divBox);

        divBox = document.createElement("div");
        divBox.classList.add("Section");
        divBox.classList.add("ZivotinjskaVrsta");

        elLabela = document.createElement("label");
        elLabela.innerHTML = "Životinjska vrsta:";

        let elInput = document.createElement("input");
        elInput.className = "vrsta";
        elInput.type = "text";

        divBox.appendChild(elLabela);
        divBox.appendChild(elInput);
        kontForma.appendChild(divBox);

        divBox = document.createElement("div");
        divBox.classList.add("Section");
        divBox.classList.add("BrojZivotinja");

        elLabela = document.createElement("label");
        elLabela.innerHTML = "Broj životinja:";

        elInput = document.createElement("input");
        elInput.className = "kolicina";
        elInput.type = "number";

        divBox.appendChild(elLabela);
        divBox.appendChild(elInput);
        kontForma.appendChild(divBox);

        divBox = document.createElement("div");
        divBox.classList.add("Section");
        divBox.classList.add("Staniste");

        elLabela = document.createElement("label");
        elLabela.innerHTML = "Stanište:";
        divBox.appendChild(elLabela);

        let tipoviStanista = ["Šuma", "Savana", "Močvara", "Pustinja", "Džungla", "Reka"];
        let tipoviBoja = ["lime", "orange", "darkgreen", "yellow", "green", "blue"];

        let opcija, labela, divRb;
        tipoviStanista.forEach((staniste, index) =>
        {
            divRb = document.createElement("div");
            divRb.className = "RadioButton" + staniste;
            opcija = document.createElement("input");
            labela = document.createElement("label");

            opcija.type = "radio";
            opcija.name = this.naziv;
            opcija.value = staniste;
            opcija.boja = tipoviBoja[index];
            if (index == 0)
                opcija.checked = true;

            labela.innerHTML = staniste;

            divRb.appendChild(opcija);
            divRb.appendChild(labela);
            divBox.appendChild(divRb);
        })
        kontForma.appendChild(divBox);

        divBox = document.createElement("div");
        divBox.classList.add("Section");
        divBox.classList.add("Selection");

        let divBoxMini = document.createElement("div");
        divBox.classList.add("Section");
        divBoxMini.classList.add("SelectionX");

        let selX = document.createElement("select");
        selX.className = "selX";
        labela = document.createElement("label");
        labela.innerHTML = "X: ";
        divBoxMini.appendChild(labela);
        divBoxMini.appendChild(selX);

        for (var i = 1; i <= this.m; i++) {
            opcija = document.createElement("option");
            opcija.innerHTML = i;
            opcija.value = i;
            selX.appendChild(opcija);
        }

        divBox.appendChild(divBoxMini);

        divBoxMini = document.createElement("div");
        divBox.classList.add("Section");
        divBoxMini.classList.add("SelectionY");

        let selY = document.createElement("select");
        selY.className = "selY";
        labela = document.createElement("label");
        labela.innerHTML = "Y: ";
        divBoxMini.appendChild(labela);
        divBoxMini.appendChild(selY);

        for (var i = 1; i <= this.n; i++) {
            opcija = document.createElement("option");
            opcija.innerHTML = i;
            opcija.value = i;
            selY.appendChild(opcija);
        }
        divBox.appendChild(divBoxMini);
        kontForma.appendChild(divBox);

        divBox = document.createElement("div");
        divBox.classList.add("Section");
        divBox.classList.add("DodajDugme");

        const dugme = document.createElement("button");
        dugme.innerHTML = "Dodaj životinje";
        dugme.className = "dugme";
        dugme.onclick = (el) =>
        {
            const vrsta = this.kontejner.querySelector(".vrsta").value;
            const kolicina = parseInt(this.kontejner.querySelector(".kolicina").value);
            const tip = this.kontejner.querySelector(`input[name="${ this.naziv }"]:checked`).boja;
            const x = parseInt(this.kontejner.querySelector(".selX").value);
            const y = parseInt(this.kontejner.querySelector(".selY").value);

            const lok = this.lokacije.find(el => { return el.x == x && el.y == y; });
            const lokPot = this.lokacije.find(el => { return el.vrsta == vrsta && (el.kolicina + kolicina <= this.kapacitet) && (el.x != x || el.y != y); });
            if (lokPot != null)
                alert(`Imate slobodnog mesta za ${ vrsta } na poziciji (${ lokPot.x }, ${ lokPot.y })!`);
            else
                lok.change(vrsta, kolicina, tip);
        }
        divBox.appendChild(dugme);
        kontForma.appendChild(divBox);
    }

    crtajLokacije(div)
    {
        const kontLokacije = document.createElement("div");
        kontLokacije.className = "kontLokacije";
        div.appendChild(kontLokacije);

        let red, kavez;
        for (var i = 1; i <= this.m; i++) {
            red = document.createElement("div");
            red.className = "red";
            for (var j = 1; j <= this.n; j++) {
                kavez = new Lokacija(j, i, null, null, this.kapacitet);
                this.dodajLokaciju(kavez);
                kavez.crtajLokaciju(red);
            }
            kontLokacije.appendChild(red);
        }
    }
}