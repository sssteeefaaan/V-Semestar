import { Disciplina } from "./disciplina.js";
import { Ucesnik } from "./ucesnik.js";
import { Help } from "./help.js";

export class Turnir
{
    constructor(id, naziv)
    {
        this.id = id;
        this.naziv = naziv;

        // Not in the database
        this.discipline = [];
        this.container = null;
    }

    // Glavni kontejner u koji se crtaju svi elementi turnira
    proslediContainer(host)
    {
        if (this.container == null)
            this.container = Help.napraviElement("div", host, "Turnir");
    }

    // Dodaje novu disciplinu u turnir
    // Iscrtava njen prikaz
    dodajDisciplinu(dsc)
    {
        if (this.container != null) {
            dsc.nacrtajDisciplinu(this.container.querySelector(".TurnirPrikazDisciplina"),
                this.container.querySelector(".TurnirPrikazUcesnika"));
            this.discipline.push(dsc);
        }
    }

    // Crta sve elemente turnira u prosleđeni kontejner
    nacrtajTurnir(host)
    {
        this.proslediContainer(host);

        // Header
        this.nacrtajHeaderTurnira();

        // Prikaz Disciplina
        this.nacrtajPrikazDisciplina();

        // Prikaz Ucesnika
        // Crtaće ga prikaz disciplina
    }

    // Crta header (naziv turnira i dugmići za kontrolu)
    nacrtajHeaderTurnira()
    {
        let headerDiv = Help.napraviElement("div", this.container, "TurnirHeaderDiv");

        // Natpis
        let div = Help.napraviElement("div", headerDiv, "TurnirHeader");
        Help.napraviElement("h1", div).innerHTML = this.naziv;

        // Dugmad
        div = Help.napraviElement("div", headerDiv, "TurnirHeaderButton");

        const buttons = [];
        ["Dodaj disciplinu",
            "Prikaži sve",
            "Pokreni sve",
            "Resetuj sve"
        ].forEach((el, ind) =>
        {
            buttons.push(Help.napraviElement("button", div));
            buttons[ind].innerHTML = el;
            buttons[ind].name = el;

            switch (el) {
                case ("Dodaj disciplinu"):
                    const indDodaj = ind;
                    buttons[indDodaj].onclick = () =>
                    {
                        this.nacrtajInputDiscipline();
                    };
                    break;
                case ("Prikaži sve"):
                    const indPrikazi = ind;
                    buttons[indPrikazi].onclick = () =>
                    {
                        if (buttons[indPrikazi].innerHTML == "Prikaži sve") {
                            buttons[indPrikazi].innerHTML = "Sakrij sve";
                            buttons[indPrikazi].name = "Sakrij sve";
                            headerDiv.parentNode
                                .querySelector(".TurnirPrikazDisciplina")
                                .querySelectorAll("button[name='Prikaži']")
                                .forEach(el => el.dispatchEvent(new Event("click")));
                            this.container.querySelector(".TurnirPrikazUcesnika").scrollIntoView({ behavior: "smooth", block: "start" });
                        }
                        else {
                            buttons[indPrikazi].innerHTML = "Prikaži sve";
                            buttons[indPrikazi].name = "Prikaži sve";
                            buttons[indPrikazi].parentNode
                                .querySelectorAll("button[name='Pauziraj sve']")
                                .forEach(el =>
                                {
                                    el.innerHTML = "Pokreni sve";
                                    el.name = "Pokreni sve";
                                });
                            headerDiv.parentNode
                                .querySelector(".TurnirPrikazDisciplina")
                                .querySelectorAll("button[name='Sakrij']")
                                .forEach(el => el.dispatchEvent(new Event("click")));
                        }
                    };
                    break;
                case ("Pokreni sve"):
                    const indPlay = ind;
                    buttons[indPlay].onclick = () =>
                    {
                        if (buttons[indPlay].innerHTML == "Pokreni sve") {
                            buttons[indPlay].innerHTML = "Pauziraj sve";
                            buttons[indPlay].name = "Pauziraj sve";
                            buttons[indPlay].parentNode
                                .querySelectorAll("button[name='Prikaži sve']")
                                .forEach(el =>
                                {
                                    el.innerHTML = "Sakrij sve";
                                    el.name = "Sakrij sve";
                                });
                            headerDiv.parentNode
                                .querySelector(".TurnirPrikazDisciplina")
                                .querySelectorAll("button[name='Automatska igra']")
                                .forEach(el =>
                                    el.dispatchEvent(new Event("click"))
                                );
                            this.container.querySelector(".TurnirPrikazUcesnika").scrollIntoView({ behavior: "smooth", block: "start" });
                        }
                        else {
                            buttons[indPlay].innerHTML = "Pokreni sve";
                            buttons[indPlay].name = "Pokreni sve";
                            headerDiv.parentNode
                                .querySelector(".TurnirPrikazDisciplina")
                                .querySelectorAll("button[name='Pauziraj']")
                                .forEach(el =>
                                    el.dispatchEvent(new Event("click"))
                                );
                        }
                    };
                    break;
                case ("Resetuj sve"):
                    const indRes = ind;
                    buttons[indRes].onclick = () =>
                    {
                        buttons[indRes].parentNode
                            .querySelectorAll("button[name='Pauziraj sve']")
                            .forEach(el =>
                            {
                                el.innerHTML = "Pokreni sve";
                                el.name = "Pokreni sve";
                            });
                        headerDiv.parentNode
                            .querySelector(".TurnirPrikazDisciplina")
                            .querySelectorAll("button[name='Resetuj']")
                            .forEach(el => el.dispatchEvent(new Event("click")));
                    };
                    break;
            }
        });
    }

    // Crta deo za upis nove discipline u turnir
    nacrtajInputDiscipline()
    {
        document.body.scrollIntoView();
        document.body.style.overflow = "hidden";
        const inputBackground = Help.napraviElement("div", document.body, "PopUpBackground");
        const divDsc = Help.napraviElement("div", inputBackground, "PopUp");
        divDsc.classList.add("TurnirUnosDialog");

        // Natpis
        Help.napraviElement("h1", divDsc).innerHTML = `Dodajte disciplinu u turnir '${ this.naziv }'`;

        // Input za podatke o disciplini
        let input;
        ["Naziv", "Lokacija", "Max"].forEach(el =>
        {
            input = Help.napraviElement("input", divDsc);
            input.name = el;
            if (el == "Max") {
                input.type = "number";
                input.placeholder = "Maksimalni broj takmičara";
            }
            else
                input.placeholder = el + " discipline";
        })

        const buttonsDiv = Help.napraviElement("div", divDsc, "DialogDugmici");
        // Dugme za prosleđivanje discipline i poništavanje
        const buttons = [];
        ["Dodaj novu disciplinu", "Poništi"].forEach((el, ind) =>
        {
            buttons.push(Help.napraviElement("button", buttonsDiv));
            buttons[ind].innerHTML = el;
            buttons[ind].name = el;

            switch (el) {
                case ("Dodaj novu disciplinu"):
                    const indDod = ind;
                    buttons[indDod].onclick = async () =>
                    {
                        const naziv = divDsc.querySelector("input[name='Naziv']").value;
                        const lokacija = divDsc.querySelector("input[name='Lokacija']").value;
                        const max = parseInt(divDsc.querySelector("input[name='Max']").value);

                        if (Help.validacija([naziv, lokacija], [max])) {
                            var dsc = await this.napraviNovuDisciplinu(naziv, lokacija, max);
                            if (dsc != null) {
                                this.dodajDisciplinu(dsc);
                                document.body.style.overflow = "auto";
                                document.body.removeChild(buttonsDiv.parentNode.parentNode);
                                this.container.querySelector(".TurnirPrikazDisciplina> :last-child").scrollIntoView({ behavior: "smooth", block: "center", inline: "nearest" });
                                this.container.querySelector(".TurnirPrikazDisciplina> :last-child").dispatchEvent()
                            }
                        }
                        else
                            alert("Polja ne smeju biti prazna!");
                    };
                    break;
                case ("Poništi"):
                    const indPon = ind;
                    buttons[indPon].onclick = () =>
                    {
                        document.body.style.overflow = "auto";
                        document.body.removeChild(buttonsDiv.parentNode.parentNode);
                        this.container.scrollIntoView({ behavior: "auto", block: "center", inline: "nearest" });
                    };
                    break;
            }
        });
    }

    // Prikaz disciplina
    nacrtajPrikazDisciplina()
    {
        let div = Help.napraviElement("div", this.container, "TurnirPrikazDisciplina");

        // Ispituje da li je neko pobedio (desila se pobeda)
        div.addEventListener("win", (ev) =>
        {
            this.discipline.forEach(dsc =>
            {
                dsc.ucesnici.forEach(ucesnik =>
                {
                    if (ev.detail.pobednik == ucesnik) {
                        dsc.finish(ucesnik);
                    }
                });
            });
        });

        div.addEventListener("del", (ev) =>
        {
            this.discipline = this.discipline.filter(el => el !== ev.detail.zaBrisanje);
        });

        let div2 = Help.napraviElement("div", this.container, "TurnirPrikazUcesnika");
        this.discipline.forEach(el => el.nacrtajDisciplinu(div, div2));
    }

    // Upis podataka turnira u bazu
    updateTurnir()
    {
        fetch("https://0c0bfc1858a2.ngrok.io/Evidencija/UpdateTurnir", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                id: this.id,
                naziv: this.naziv,
                brojDisciplina: this.discipline.length
            })
        }).then(response =>
        {
            if (response.ok) {
                console.log("Successfully updated turnir!");
            }
            else {
                response.json().then(badRequest =>
                {
                    console.log("Bad request " + badRequest.message);
                }).catch(er =>
                {
                    console.log("Error occurred " + er);
                });
            }
        }).catch(er =>
        {
            console.log("Error occurred " + er);
        });
    }

    // Kreiranje nove discipline u bazi (vraća Disciplinu koja je kreirana)
    async napraviNovuDisciplinu(naziv, lokacija, max)
    {
        const response = await fetch(`https://0c0bfc1858a2.ngrok.io/Evidencija/CreateDisciplina/${ this.id }`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                naziv: naziv,
                lokacija: lokacija,
                maxUcesnici: max
            })
        });

        if (response.ok) {
            console.log("Uspešno napravljena nova disciplina");
            const id = await response.json();
            return new Disciplina(id, this.id, naziv, lokacija, max);
        }
        else {
            response.json()
                .then(er => alert(er.message))
                .catch(er => console.log(er));
        }
        return null;
    }
}