export class Silos
{
    constructor(oznaka = "Unknown", kapacitet = 100, trenutnaKolicina = 0, id = 0, fabrikaID = 0)
    {
        this.id = id;
        this.fabrikaID = fabrikaID;
        this.o = oznaka;
        this.cap = kapacitet;
        this.cur = trenutnaKolicina;

        this.container = null;
    }

    nacrtajSilos(container)
    {
        this.container = document.createElement("div");
        this.container.classList.add("Silos");
        container.appendChild(this.container);

        let el;
        [this.o, this.cur].forEach(stavka =>
        {
            el = document.createElement("label");
            if (stavka == this.cur) {
                el.innerHTML = stavka + "t/" + this.cap + "t";
                el.htmlFor = "Količina";
            }
            else
                el.innerHTML = stavka;
            this.container.appendChild(el);
        });

        el = document.createElement("div");
        el.classList.add("SilosOkvir");
        this.container.appendChild(el);

        const el2 = document.createElement("div");
        el2.classList.add("SilosPopunjenost");
        el2.style.height = (this.cur / this.cap) * 100 + "%";
        el.appendChild(el2);
    }

    sipaj(kol)
    {
        this.updateSilos(kol);
    }

    updateSilos(kol)
    {
        fetch("https://localhost:5001/AzurirajSilos",
            {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    id: this.id,
                    oznaka: this.o,
                    kapacitet: this.cap,
                    trenutnaKolicina: this.cur + kol,
                    fabrikaID: this.fabrikaID
                })
            }).then(response =>
            {
                if (response.ok) {
                    console.log("Uspešno ažuriran silos!");

                    this.cur += kol;
                    let el = this.container.querySelector("label[for='Količina']");
                    el.innerHTML = this.cur + "t/" + this.cap + "t";

                    el = this.container.querySelector(".SilosPopunjenost");
                    el.style.height = (this.cur / this.cap) * 100 + "%";
                    return true;
                }
                else
                    response.json().
                        then(data => alert(data.message))
                        .catch(error => console.log(error));
            })
            .catch(error => console.log(error));
        return false;
    }
}