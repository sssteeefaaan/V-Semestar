import { Ucesnik } from "./ucesnik.js";
import { Help } from "./help.js";

export class Disciplina
{
    constructor(id = 0, turnirID = 0, naziv = "Unknown", lokacija = "Unknown", maxUcesnici = 0, pobednikID = 0, pobednik = null)
    {
        this.id = id;
        this.turnirID = turnirID;
        this.naziv = naziv;
        this.lokacija = lokacija;
        this.maxUcesnici = maxUcesnici;
        this.pobednikID = pobednikID;
        this.pobednik = pobednik;

        // Not in the dataBase
        this.ucesnici = [];
        this.clicked = false;
        this.container = null;
        this.ucesniciContainer = null;
    }

    // Inicijalizacija kontejnera za ispis informacija o disciplini
    // Inicijalizacija kontejnera za prikaz svih učesnika discipline
    proslediContainer(host)
    {
        if (this.container == null) {
            this.container = Help.napraviElement("div", host, "Disciplina");
        }
        if (this.ucesniciContainer == null)
            this.ucesniciContainer = Help.napraviElement("div", null, "UcesniciDiscipline");
    }

    // Dodavanje učesnika u disciplinu
    // Iscrtavanje novododatog učesnika
    dodajUcesnika(ucesnik)
    {
        if (this.ucesniciContainer != null) {
            if (this.ucesnici.length < this.maxUcesnici) {
                this.ucesnici = [...this.ucesnici, ucesnik];

                // Update View
                ucesnik.nacrtajUcesnika(this.ucesniciContainer);
                this.ispisInfo();
                //
            }
            else
                alert("Popunjen kapacitet učesnika!");
        }
        else
            alert("Nije prosleđen kontejner za učesnike!");
    }

    // Crta prikaz informacija o disciplini
    nacrtajDisciplinu(host, hostUcesnici)
    {
        this.proslediContainer(host);

        // Opis discipline
        let div = Help.napraviElement("div", this.container, "HeaderDiscipline");
        let label = Help.napraviElement("label", div);
        const col = Help.getColAndAvg();

        this.ispisInfo();
        this.container.style.backgroundColor = col[0];
        this.ucesniciContainer.style.color = col[1];
        label.style.backgroundColor = col[0];
        label.style.color = col[1];
        label.name = "OpisDiscipline";
        //

        // Kontrola
        div = Help.napraviElement("div", this.container, "KontrolaDiscipline");
        const buttons = [];
        ["Dodaj učesnika",
            "Prikaži",
            "Automatska igra",
            "Regularna igra",
            "Resetuj",
            "Obriši disciplinu"].forEach((el, ind) =>
            {
                buttons.push(Help.napraviElement("button", div));
                buttons[ind].innerHTML = el;
                buttons[ind].name = el;

                switch (el) {
                    case ("Dodaj učesnika"):
                        const indDodajUc = ind;
                        buttons[indDodajUc].onclick = () =>
                        {
                            this.nacrtajInputUcesnika();
                        };
                        break;
                    case ("Prikaži"):
                        const indShow = ind;
                        buttons[indShow].onclick = sender =>
                        {
                            if (this.ucesnici.length < 1) {
                                if (sender.cancelable)
                                    alert("Disciplina nema učesnike!");
                            }
                            else {
                                if (buttons[indShow].innerHTML == "Prikaži") {
                                    this.nacrtajStanje(hostUcesnici, col);
                                    buttons[indShow].innerHTML = "Sakrij";
                                    buttons[indShow].name = "Sakrij";
                                    if (sender.cancelable)
                                        this.ucesniciContainer.scrollIntoView({ behavior: "smooth", block: "center", inline: "nearest" });
                                }
                                else {
                                    this.ucesnici.forEach(uc => uc.compete = false)
                                    Help.removeChildFromElement(hostUcesnici, this.ucesniciContainer);
                                    buttons[indShow].innerHTML = "Prikaži";
                                    buttons[indShow].name = "Prikaži";

                                    buttons[indShow].parentNode
                                        .querySelectorAll("button[name='Pauziraj']")
                                        .forEach(el =>
                                        {
                                            el.innerHTML = "Automatska igra";
                                            el.name = "Automatska igra";
                                        });

                                    buttons[indShow].parentNode
                                        .querySelectorAll("button[name='Obustavi']")
                                        .forEach(el =>
                                        {
                                            el.innerHTML = "Regularna igra";
                                            el.name = "Regularna igra";
                                        });
                                }
                            }
                        };
                        break;
                    case ("Automatska igra"):
                        // Autoplay/Pause button
                        const indAuto = ind;
                        buttons[indAuto].onclick = sender =>
                        {
                            if (this.ucesnici.length < 1) {
                                if (sender.cancelable)
                                    alert("Disciplina nema učesnike!");
                            }
                            else {
                                if (buttons[indAuto].innerHTML == "Automatska igra") {
                                    buttons[indAuto].innerHTML = "Pauziraj";
                                    buttons[indAuto].name = "Pauziraj";

                                    buttons[indAuto].parentNode
                                        .querySelectorAll("button[name='Prikaži']")
                                        .forEach(el =>
                                        {
                                            el.innerHTML = "Sakrij";
                                            el.name = "Sakrij";
                                        });

                                    this.ucesnici.forEach(uc => uc.reset());
                                    this.finish(null);

                                    Help.removeChildFromElement(hostUcesnici, this.ucesniciContainer);

                                    this.nacrtajStanje(hostUcesnici, col);
                                    if (sender.cancelable)
                                        this.ucesniciContainer.scrollIntoView({ behavior: "smooth", block: "center", inline: "nearest" });
                                    this.ucesnici.forEach(uc =>
                                    {
                                        uc.compete = true;
                                        uc.race(Help.getRandomInt(25, 60), true);
                                    });
                                }
                                else {
                                    buttons[indAuto].innerHTML = "Automatska igra";
                                    buttons[indAuto].name = "Automatska igra";
                                    this.ucesnici.forEach(uc => uc.compete = false)
                                }
                            }
                        };
                        break;
                    case ("Regularna igra"):
                        // Regularplay/Pause button -> ukoliko korisnik krene da pritiska učesnika,
                        // onda učesnik prestaje automatski da se kreće i korisnik ima kontrolu nad njim
                        const indReg = ind;
                        buttons[indReg].onclick = sender =>
                        {
                            if (this.ucesnici.length < 1) {
                                if (sender.cancelable)
                                    alert("Disciplina nema učesnike!");
                            }
                            else {
                                if (buttons[indReg].innerHTML == "Regularna igra") {
                                    buttons[indReg].innerHTML = "Obustavi";
                                    buttons[indReg].name = "Obustavi";

                                    buttons[indReg].parentNode
                                        .querySelectorAll("button[name='Prikaži']")
                                        .forEach(el =>
                                        {
                                            el.innerHTML = "Sakrij";
                                            el.name = "Sakrij";
                                        });
                                    this.pokreniRegularnuIgru(buttons[indReg], hostUcesnici, col);
                                }
                                else {
                                    buttons[indReg].innerHTML = "Regularna igra";
                                    buttons[indReg].name = "Regularna igra";
                                    this.ucesnici.forEach(uc => uc.compete = false);
                                }
                            }
                        };
                        break;
                    case ("Resetuj"):
                        const indRes = ind;
                        buttons[indRes].onclick = sender =>
                        {
                            if (this.ucesnici.length < 1) {
                                if (sender.cancelable)
                                    alert("Disciplina nema učesnike!");
                            }
                            else {
                                buttons[indRes].parentNode
                                    .querySelectorAll("button[name='Pauziraj']")
                                    .forEach(el =>
                                    {
                                        el.innerHTML = "Automatska igra";
                                        el.name = "Automatska igra";
                                    });

                                buttons[indRes].parentNode
                                    .querySelectorAll("button[name='Obustavi']")
                                    .forEach(el =>
                                    {
                                        el.innerHTML = "Regularna igra";
                                        el.name = "Regularna igra";
                                    });

                                this.ucesnici.forEach(uc => uc.reset());
                                this.finish(null); // setuje pobednika na null i šalje update bazi
                            }
                        };
                        break;
                    case ("Obriši disciplinu"):
                        const indDel = ind;
                        buttons[indDel].onclick = () =>
                        {
                            this.nacrtajDelDiscipline();
                        };
                        break;
                }
            });
    }

    // Ispisuje naziv, lokaciju, (current/max) i potencijalnog pobednika
    ispisInfo()
    {
        const label = this.container.querySelector(".HeaderDiscipline>label");
        if (this.pobednik != null)
            label.innerHTML = `${ this.naziv }, ${ this.lokacija }, (${ this.ucesnici.length } / ${ this.maxUcesnici }), 👑 ${ this.pobednik.ime } ${ this.pobednik.prezime }`;
        else
            label.innerHTML = `${ this.naziv }, ${ this.lokacija }, (${ this.ucesnici.length } / ${ this.maxUcesnici })`;
    }

    // Crta deo za unos učesnika u disciplinu
    nacrtajInputUcesnika()
    {
        document.body.scrollIntoView();
        document.body.style.overflow = "hidden";
        const background = Help.napraviElement("div", document.body, "PopUpBackground");
        const divUc = Help.napraviElement("div", background, "PopUp");
        divUc.classList.add("TurnirUnosDialog");

        // Natpis
        Help.napraviElement("h1", divUc).innerHTML = `Dodajte učesnika u disciplinu '${ this.naziv }'`;

        // Input za podatke o učesniku
        let input;
        ["Ime", "Prezime", "Brzina"].forEach(el =>
        {
            input = Help.napraviElement("input", divUc);
            input.name = el;
            input.placeholder = el + " učesnika";
            if (el == "Brzina") {
                input.maxLength = 3;
                input.type = "number";
            }
        })

        const buttonsDiv = Help.napraviElement("div", divUc, "DialogDugmici");

        // Dugme za dodavanje učesnika i poništavanje
        const buttons = [];
        ["Dodaj učesnika", "Poništi"].forEach((el, ind) =>
        {
            buttons.push(Help.napraviElement("button", buttonsDiv));
            buttons[ind].innerHTML = el;
            buttons[ind].name = el;

            switch (el) {
                case ("Dodaj učesnika"):
                    const indDodaj = ind;
                    buttons[indDodaj].onclick = async () =>
                    {
                        const ime = divUc.querySelector("input[name='Ime']").value;
                        const prezime = divUc.querySelector("input[name='Prezime']").value;
                        const brzina = parseInt(divUc.querySelector("input[name='Brzina']").value);
                        if (Help.validacija([ime, prezime], [brzina])) {
                            const ucesnikID = await this.napraviNovogUcesnika(ime, prezime, brzina);
                            if (ucesnikID != 0) {
                                this.dodajUcesnika(new Ucesnik(ucesnikID, this.id, this.turnirID, ime, prezime, brzina));
                                document.body.style.overflow = "auto";
                                document.body.removeChild(buttonsDiv.parentNode.parentNode);
                                this.container.querySelector(".KontrolaDiscipline").querySelector("button[name='Resetuj']").click();
                                const uc = this.container.querySelector(".KontrolaDiscipline").querySelector("button[name='Prikaži']");
                                if (uc != null)
                                    uc.click();
                                else
                                    this.ucesniciContainer.scrollIntoView({ behavior: "auto", block: "center", inline: "nearest" });
                            }
                        }
                        else
                            alert("Polja ne smeju biti prazna!");
                    };
                    break;
                case ("Poništi"):
                    const indCan = ind;
                    buttons[indCan].onclick = () =>
                    {
                        document.body.style.overflow = "auto";
                        document.body.removeChild(buttonsDiv.parentNode.parentNode);
                        this.container.parentNode.scrollIntoView({ behavior: "auto", block: "center", inline: "nearest" });
                    };
                    break;
            }
        });
    }

    nacrtajDelDiscipline()
    {
        document.body.scrollIntoView();
        document.body.style.overflow = "hidden";
        const delBackground = Help.napraviElement("div", document.body, "PopUpBackground");
        const div = Help.napraviElement("div", delBackground, "PopUp");
        div.classList.add("TurnirUnosDialog");

        Help.napraviElement("h1", div).innerHTML = `Jeste li sigurni da želite obrisati disciplinu '${ this.naziv }'?`;

        const divButton = Help.napraviElement("div", div, "DialogDugmici");
        const buttons = [];
        ["Obriši", "Otkaži"].forEach((el, ind) =>
        {
            buttons.push(Help.napraviElement("button", divButton));
            buttons[ind].innerHTML = el;
            buttons[ind].name = el;

            switch (el) {
                case ("Obriši"):
                    const indDel = ind;
                    buttons[indDel].onclick = () =>
                    {
                        document.body.style.overflow = "auto";
                        document.body.removeChild(div.parentNode);
                        this.container.parentNode.scrollIntoView({ behavior: "auto", block: "center", inline: "nearest" });

                        this.deleteDisciplina();
                    };
                    break;
                case ("Otkaži"):
                    const indCancel = ind;
                    buttons[indCancel].onclick = () =>
                    {
                        document.body.style.overflow = "auto";
                        document.body.removeChild(div.parentNode);
                        this.container.parentNode.scrollIntoView({ behavior: "auto", block: "center", inline: "nearest" });
                    };
                    break;
            }
        });
    }

    pokreniRegularnuIgru(regButton, hostUcesnici, col)
    {
        document.body.scrollIntoView();
        document.body.style.overflow = "hidden";
        const delBackground = Help.napraviElement("div", document.body, "PopUpBackground");
        const div = Help.napraviElement("div", delBackground, "PopUp");
        div.classList.add("TurnirUnosDialog");

        Help.napraviElement("h1", div).innerHTML = `Izaberite svog takmičara iz discipline '${ this.naziv }'`;

        const select = Help.napraviElement("select", div);
        select.name = "RegularnaIgraSelect";

        let option;
        this.ucesnici.forEach(uc =>
        {
            option = Help.napraviElement("option", select);
            option.innerHTML = uc.ime + " " + uc.prezime;
            option.value = uc.id;
        });

        const control = Help.napraviElement("input", div);
        control.type = "text";
        control.maxLength = 1;
        control.placeholder = "Unesite karakter za pokretanje";

        const divButton = Help.napraviElement("div", div, "DialogDugmici");
        const buttons = [];
        ["Izaberi", "Otkaži"].forEach((el, ind) =>
        {
            buttons.push(Help.napraviElement("button", divButton));
            buttons[ind].innerHTML = el;
            buttons[ind].name = el;

            switch (el) {
                case ("Izaberi"):
                    const indIz = ind;
                    buttons[indIz].onclick = () =>
                    {
                        if (control.value.charCodeAt(0) < "a".charCodeAt(0) || control.value.charCodeAt(0) > "z".charCodeAt(0))
                            alert("Neispravan key!");
                        else {
                            const selectedID = parseInt(select.value);
                            const player = this.ucesnici.find(uc => uc.id == selectedID);

                            Help.clearElementOfChildren(div);
                            const lab = Help.napraviElement("label", div);
                            lab.htmlFor = "Timer";
                            lab.innerHTML = 3;
                            let countdown = 2;
                            const timeCode = window.setInterval(() =>
                            {
                                if (countdown > 0)
                                    lab.innerHTML = countdown;
                                else if (countdown == 0)
                                    lab.innerHTML = "GO!";
                                else {
                                    clearInterval(timeCode);
                                    document.body.style.overflow = "auto";
                                    document.body.removeChild(div.parentNode);

                                    this.ucesnici.forEach(uc => uc.reset());
                                    this.finish(null);
                                    Help.removeChildFromElement(hostUcesnici, this.ucesniciContainer);

                                    this.nacrtajStanje(hostUcesnici, col);
                                    this.ucesniciContainer.scrollIntoView({ behavior: "auto", block: "center", inline: "nearest" });
                                    player.selected = true;
                                    this.ucesnici.forEach(uc =>
                                    {
                                        uc.compete = true;
                                        uc.race(Help.getRandomInt(40, 60));
                                    });
                                    document.addEventListener('keydown', function stacy(event)
                                    {
                                        if (event.key == control.value)
                                            player.race(0, false, stacy);
                                    });
                                }
                                countdown--;
                            }, 1000);
                        }
                    }
                    break;
                case ("Otkaži"):
                    const indOtk = ind;
                    buttons[indOtk].onclick = () =>
                    {
                        document.body.style.overflow = "auto";
                        document.body.removeChild(div.parentNode);
                        this.container.parentNode.scrollIntoView({ behavior: "auto", block: "center", inline: "nearest" });
                    }
                    break;
            }
        });
    }

    // Crta učesnike na disciplini
    nacrtajStanje(hostUcesnici, col)
    {
        this.ucesniciContainer.style.backgroundColor = col[0];
        this.ucesnici.forEach(el => el.nacrtajUcesnika(this.ucesniciContainer));
        hostUcesnici.insertBefore(this.ucesniciContainer, hostUcesnici.firstChild);

        // Nije najefikasnije odrađeneno, pogotovo što se konstantno zove,
        // Bolji prilaz bi bio Observer
        this.ucesniciContainer.addEventListener("move", () =>
        {
            const positions = this.ucesnici.map(x => x.pos);
            positions.sort((a, b) => b - a);
            let k;//, pos;
            for (var j = 0; j < this.ucesnici.length; j++) {
                k = 0;
                while (k < positions.length && positions[k] != this.ucesnici[j].pos)
                    k++;
                //pos = positions[k];
                this.ucesnici[j].promeniRang(k + 1);
            }
        });
    }

    // Ispis pobednika discipline
    finish(pob)
    {
        this.pobednik = pob;
        this.pobednikID = this.pobednik != null ? this.pobednik.id : null;
        this.ispisInfo();
        this.updateDisciplina();
    }

    // Upisuje izmene u bazu
    updateDisciplina()
    {
        fetch("https://0c0bfc1858a2.ngrok.io/Evidencija/UpdateDisciplina", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                id: this.id,
                turnirID: this.turnirID,
                naziv: this.naziv,
                lokacija: this.lokacija,
                maxUcesnici: this.maxUcesnici,
                trenutniBrojUcesnika: this.ucesnici.length,
                pobednikID: this.pobednikID
            })
        }).then(response =>
        {
            if (response.ok) {
                console.log("Successfully updated disciplina!");
            }
            else {
                response.json().then(badRequest =>
                {
                    console.log(badRequest.message);
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

    //Pribavlja učesnika iz baze, koji je pobednik discipline
    async nabaviPobednika()
    {
        const response = await fetch(`https://0c0bfc1858a2.ngrok.io/Evidencija/ReadUcesnik/${ this.pobednikID }`);
        if (response.ok) {
            console.log("Uspešno nabavljen pobednik!");
            const pobednik = await response.json();
            this.pobednik = new Ucesnik(this.pobednikID, this.id, this.turnirID, pobednik.ime, pobednik.prezime, pobednik.brzina, pobednik.pozicija, pobednik.rang, pobednik.selected, pobednik.compete);
            return this.pobednik;
        }
        else
            response.json()
                .then(er => console.log(er.message))
                .catch(er => console.log(er));
        return null;
    }

    // Kreiranje novog učesnika u bazi ( vraća njegov id u bazi )
    async napraviNovogUcesnika(ime, prezime, brzina)
    {
        var response = await fetch(`https://0c0bfc1858a2.ngrok.io/Evidencija/CreateUcesnik/${ this.turnirID }/${ this.id }`, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({
                ime: ime,
                prezime: prezime,
                brzina: brzina
            })
        });

        if (response.ok) {
            console.log("Uspešno napravljen novi učesnik");
            let id = await response.json();
            return id;
        }
        else {
            response.json().then(error => alert(error.message));
        }
        return 0;
    }

    deleteDisciplina()
    {
        fetch(`https://0c0bfc1858a2.ngrok.io/Evidencija/DeleteDisciplina/${ this.turnirID }/${ this.id }`,
            {
                method: "DELETE"
            })
            .then(response =>
            {
                if (response.ok) {
                    console.log("Uspešno uklonjena disciplina");
                    this.container.parentNode.dispatchEvent(new CustomEvent("del", { "detail": { "zaBrisanje": this } }));
                    if (this.ucesniciContainer != null && this.ucesniciContainer.parentNode != null)
                        this.ucesniciContainer.parentNode.removeChild(this.ucesniciContainer);
                    if (this.container != null && this.container.parentNode != null)
                        this.container.parentNode.removeChild(this.container);

                }
                else
                    response.json()
                        .then(er => console.log(er.message))
                        .catch(error => console.log("error unpacking json " + error));
            })
            .catch(error => console.log("error unpacking response " + error));
    }
}