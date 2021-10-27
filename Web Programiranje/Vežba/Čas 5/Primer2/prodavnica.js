import { Proizvod } from "./proizvod.js";

export class Prodavnica
{
    constructor()
    {
        this.proizvodi = [];
        this.container = null;
    }

    dodajProizvod(proizvod)
    {
        this.proizvodi.push(proizvod);

    }

    crtaj(host)
    {
        if (!host)
            throw new Error("Ne postoji host!");

        const tabela = document.createElement("table");
        this.container = tabela;
        host.appendChild(tabela);

        this.crtajZaglavlje();

        this.proizvodi.forEach(el =>
        {
            el.crtajRed(tabela);
        })
    }

    crtajZaglavlje()
    {
        let red = document.createElement("tr");
        red.className = "Zaglavlje";
        this.container.appendChild(red);

        let el = [
            document.createElement("td"),
            document.createElement("td"),
            document.createElement("td"),
            document.createElement("td"),
            document.createElement("td"),
            document.createElement("td")
        ];

        el[0].innerHTML = "Šifra";
        el[1].innerHTML = "Ime";
        el[2].innerHTML = "Cena";
        el[3].innerHTML = "Količina";
        el[4].innerHTML = "";
        el[5].innerHTML = "Ukupna Cena Proizvoda";

        red.appendChild(el[0]);
        red.appendChild(el[1]);
        red.appendChild(el[2]);
        red.appendChild(el[3]);
        red.appendChild(el[4]);
        red.appendChild(el[5]);
    }

    dodajNoviProizvod()
    {
        let newRow = document.createElement("tr");
        this.container.appendChild(newRow);

        let newColumn = document.createElement("td");
        let pr = document.createElement("input");
        pr.type = "number";
        pr.placeholder = "Šifra proizvoda";
        pr.className = "sifra";
        newColumn.appendChild(pr);
        newRow.appendChild(newColumn);

        newColumn = document.createElement("td");
        pr = document.createElement("input");
        pr.type = "text";
        pr.placeholder = "Ime proizvoda";
        pr.className = "ime";
        newColumn.appendChild(pr);
        newRow.appendChild(newColumn);

        newColumn = document.createElement("td");
        pr = document.createElement("input");
        pr.type = "number";
        pr.placeholder = "Cena proizvoda";
        pr.className = "cena";
        newColumn.appendChild(pr);
        newRow.appendChild(newColumn);

        newColumn = document.createElement("td");
        pr = document.createElement("input");
        pr.type = "number";
        pr.placeholder = "Količina proizvoda";
        pr.className = "kolicina";
        newColumn.appendChild(pr);
        newRow.appendChild(newColumn);

        newColumn = document.createElement("td");
        pr = document.createElement("input");
        pr.type = "submit";
        pr.className = "Ubaci";
        pr.value = "Ubaci";
        pr.onclick = (el) => { this.ubaciProizvod(newRow); this.container.removeChild(newRow); };
        newColumn.appendChild(pr);
        newRow.appendChild(newColumn);
    }

    ubaciProizvod(row)
    {
        let newProizvod = new Proizvod(row.querySelector(".ime").value, row.querySelector(".sifra").value, row.querySelector(".cena").value, row.querySelector(".kolicina").value);
        this.proizvodi.push(newProizvod);
        newProizvod.crtajRed(this.container);
    }
}