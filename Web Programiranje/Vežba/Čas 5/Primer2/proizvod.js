export class Proizvod
{
    constructor(ime, sifra, cena, kolicina)
    {
        this.ime = ime;
        this.sifra = sifra;
        this.cena = cena;
        this.kolicina = kolicina;
        this.container = null;
    }

    ukupnaCena() { return this.cena * this.kolicina; }

    crtajRed(host)
    {
        const red = document.createElement("tr");
        host.appendChild(red);

        this.container = red;

        let el = [
            document.createElement("td"),   // Sifra
            document.createElement("td"),   // Ime
            document.createElement("td"),   // Cena
            document.createElement("td"),   // Kolicina
            document.createElement("td")    // Ukupna Cena
        ];

        el[0].innerHTML = this.sifra;
        el[1].innerHTML = this.ime;
        el[2].innerHTML = this.cena;
        el[3].innerHTML = this.kolicina;
        el[3].className = "Kolicina";
        el[4].innerHTML = this.ukupnaCena();
        el[4].className = "UkupnaCena";

        red.appendChild(el[0]);
        red.appendChild(el[1]);
        red.appendChild(el[2]);
        red.appendChild(el[3]);

        // dugmići
        let btn = [
            document.createElement("button"),   // "+"
            document.createElement("button")    // "-"
        ];
        btn[0].innerHTML = "+";
        btn[1].innerHTML = "-";
        btn[0].className = btn[1].className = "dugme";

        btn[0].onclick = el => { this.promeniKolicinu(1); };
        btn[1].onclick = el => { this.promeniKolicinu(-1); };

        red.appendChild(btn[0]);
        red.appendChild(btn[1]);

        // Ukupna cena
        red.appendChild(el[4]);

    }

    promeniKolicinu(dKol)
    {
        if (this.kolicina + dKol >= 0) {
            this.kolicina += dKol;
            let kol = this.container.querySelector(".Kolicina");
            kol.innerHTML = this.kolicina;

            kol = this.container.querySelector(".UkupnaCena");
            kol.innerHTML = this.ukupnaCena();
        }
    }
}