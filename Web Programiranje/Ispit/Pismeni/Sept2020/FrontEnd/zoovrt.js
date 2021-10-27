import { Staniste } from "./stanište.js";

export class ZooVrt
{
    constructor(naziv = "Unknown", n = 0, m = 0, max = 0, tipoviStanista = null, bojeStanista = null, id = 0)
    {
        this.naziv = naziv;
        this.n = n;
        this.m = m;
        this.max = max;
        this.id = id;

        this.tipoviStanista = tipoviStanista;
        this.bojeStanista = bojeStanista;
        this.stanista = new Array();

        this.container = null;
    }

    nacrtaj(parent)
    {
        this.container = document.createElement("div");
        this.container.classList.add("ZooVrt");
        parent.appendChild(this.container);

        this.nacrtajHeader();
        this.nacrtajBody();
    }

    nacrtajHeader()
    {
        const header = document.createElement("div");
        header.classList.add("ZooVrtHeader");
        this.container.appendChild(header);

        let el = document.createElement("h2");
        el.innerHTML = this.naziv;
        header.appendChild(el);
    }

    nacrtajBody()
    {
        const body = document.createElement("div");
        body.classList.add("ZooVrtBody");
        this.container.appendChild(body);

        this.nacrtajUnos(body);
        this.nacrtajPrikaz(body);
    }

    nacrtajUnos(body)
    {
        const unos = document.createElement("div");
        unos.classList.add("Unos");
        body.appendChild(unos);

        let el = document.createElement("h4");
        el.innerHTML = "Unos životinja";
        unos.appendChild(el);

        el = document.createElement("input");
        el.type = "text";
        el.name = "vrsta";
        el.placeholder = "Ime vrste";
        unos.appendChild(el);

        el = document.createElement("input");
        el.type = "number";
        el.name = "količina";
        el.placeholder = "Količina";
        unos.appendChild(el);

        el = document.createElement("label");
        el.innerHTML = "Tip staništa";
        unos.appendChild(el);

        let div;

        this.tipoviStanista.forEach((tip, ind) =>
        {
            div = document.createElement("div");
            div.classList.add("Dugmici");
            unos.appendChild(div);

            el = document.createElement("input");
            el.type = "radio";
            el.value = this.bojeStanista[ind];
            el.name = "tip";
            if (ind == 0)
                el.checked = true;
            div.appendChild(el);

            el = document.createElement("label");
            el.innerHTML = tip;
            div.appendChild(el);
        });

        div = document.createElement("div");
        div.classList.add("Koordinate");
        unos.appendChild(div);

        let div2, el2, bounds = [this.n, this.m];
        ["X", "Y"].forEach((kord, ind) =>
        {
            div2 = document.createElement("div");
            div2.classList.add("Koordinata");
            div.appendChild(div2);

            el = document.createElement("label");
            el.innerHTML = kord;
            div2.appendChild(el);

            el = document.createElement("select");
            el.name = kord;
            div2.appendChild(el);

            for (let i = 1; i <= bounds[ind]; i++) {
                el2 = document.createElement("option");
                el2.value = i - 1;
                el2.innerHTML = i;

                el.appendChild(el2);
            }
        });

        el = document.createElement("button");
        el.innerHTML = "Dodaj životinje";
        unos.appendChild(el);
        el.addEventListener('click', () =>
        {
            const vrsta = unos.querySelector("input[name='vrsta']").value;
            const kolicina = parseInt(unos.querySelector("input[name='količina']").value);
            const boja = unos.querySelector("input[name='tip']:checked").value;
            const x = parseInt(unos.querySelector("select[name='X']").value);
            const y = parseInt(unos.querySelector("select[name='Y']").value);

            if (vrsta == "")
                alert("Unesite vrstu!");
            else if (kolicina < 0 || isNaN(kolicina))
                alert("Unesite ispravnu količinu!");
            else {
                const staniste = this.stanista.find(st => st.vrsta == vrsta && st.trenutno + kolicina <= st.max);
                if (staniste != null && this.stanista[(this.n - 1) * x + y] != staniste)
                    alert("Vec postoji ta vrsta!");
                else if (this.stanista[(this.n - 1) * x + y].vrsta != "Prazno")
                    alert("Već je uneto stanište!");
                else
                    this.stanista[(this.n - 1) * x + y].osvezi(vrsta, kolicina, boja);
            }
        });
    }

    nacrtajPrikaz(body)
    {
        const prikaz = document.createElement("div");
        prikaz.classList.add("Prikaz");
        body.appendChild(prikaz);

        let div;
        for (let i = 0; i < this.n; i++) {
            div = document.createElement("div");
            div.classList.add("Red");
            prikaz.appendChild(div);

            for (let j = 0; j < this.m; j++) {
                if (this.stanista[(this.n - 1) * i + j] == null)
                    this.dodajStaniste(i, j);
                this.stanista[(this.n - 1) * i + j].nacrtaj(div);
            }
        }
    }

    dodajStaniste(i, j)
    {
        fetch(`https:/localhost:5001/DodajStaniste/${ this.id }`, {
            method: 'put',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                vrsta: "Prazno",
                boja: 'lightgrey',
                max: this.max,
                trenutno: 0
            })
        }).then(response =>
        {
            response.json().then(val =>
            {
                if (response.ok)
                    this.stanista[(this.n - 1) * i + j] = new Staniste("Prazno", 'lightgrey', this.max, 0, val, this.id);
                else
                    alert(val.message);
            }).catch(error => console.log(error));
        }).catch(error => console.log(error));
    }
}