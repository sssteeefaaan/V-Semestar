import { Help } from "./help.js"
export class Ucesnik
{
    constructor(id = 0, disciplinaID = 0, turnirID = 0, ime = "Unknown", prezime = "Unknown", brzina = 0, pos = 0, rang = 0, compete = false, selected = false)
    {
        this.id = id;
        this.disciplinaID = disciplinaID;
        this.turnirID = turnirID;
        this.ime = ime;
        this.prezime = prezime;
        this.brzina = brzina;
        this.pos = pos;
        this.rang = rang;
        this.compete = compete;
        this.selected = selected;

        // Not in the database
        this.changed = false;
        this.container = null;
        this.contestant = null;
    }

    // Kretanje učesnika
    move()
    {
        if (this.container != null && this.contestant != null) {
            const end = this.container.clientWidth - this.contestant.offsetWidth;
            if (end > this.pos + this.brzina)
                this.pos += this.brzina;
            else {
                this.pos = end;
                this.compete = false;
            }
            // Update view
            this.contestant.style.marginLeft = this.pos + "px";
            this.container.parentNode.dispatchEvent(new Event("move"));
            //
            return (this.pos == end) ? 1 : 0;
        }
        return -1;
    }

    // Crta učesnika, ime, prezime, rang na određenoj poziciji
    nacrtajUcesnika(host)
    {
        if (this.container == null) {
            this.container = Help.napraviElement("div", host, "UcesnikRed");
            this.container.style.color = "black"; // this.container.parentNode.color;

            if (this.contestant == null) {

                const col = Help.getColAndAvg();

                let header = Help.napraviElement("label", this.container, "PunoIme");
                header.innerHTML = `${ this.ime } ${ this.prezime }`;
                header.style.color = col[0];
                header.style.textShadow = "1px 1px black";

                this.contestant = Help.napraviElement("div", this.container, "Ucesnik");
                this.contestant.style.backgroundColor = col[0];
                this.contestant.style.border = "2px solid " + col[1];

                let label = Help.napraviElement("label", this.contestant);
                if (this.rang != 0)
                    label.innerHTML = this.rang;
                label.htmlFor = "Rang";
                label.style.color = col[1];
            }
        }
        this.container.onclick = () =>
        {
            this.selected = true;
            if (this.compete)
                this.checkWin(this.move());
        }
    }

    // Ukoliko se učesnik i dalje takmiči, menja njegov rang ( poziva se pri trkanju )
    promeniRang(broj = 0)
    {
        if (this.compete || broj == 0) {
            this.changed = true;

            if (broj > 0) {
                this.contestant.querySelector("label[for='Rang']").innerHTML = broj;
                this.rang = broj;
            }
            else {
                this.contestant.querySelector("label[for='Rang']").innerHTML = "";
                this.rang = null;
            }
        }
    }

    // Vraća podatke učesnika na disciplini na podrazumevane vrednosti 
    reset()
    {
        this.promeniRang();
        this.compete = false;
        this.selected = false;
        this.pos = 0;
        this.changed = true;

        // Update View
        this.contestant.style.marginLeft = 0 + "px";
        this.container.style.border = "2px solid black";// + this.container.parentNode.style.color;
        //

        // Update database
        this.updateUcesnik();
        //
    }

    // Trkanje
    race(millSec = 0, auto = false, byEvent = null)
    {
        const val = this.move();
        if (this.compete && val == 0 && (auto || !this.selected))
            setTimeout(this.race.bind(this), millSec, millSec, auto);
        this.checkWin(val);
        if (val == 1 && byEvent != null)
            document.removeEventListener('keydown', byEvent);
    }

    // Ispituje se da li se stiglo do kraja i ukoliko je prvi tamo, proglašava ga pobednikom discipline
    checkWin(val)
    {
        if (val == 1) {
            // Update database
            this.updateUcesnik();
            //
            if (this.rang == 1) {
                this.container
                    .parentNode
                    .parentNode
                    .parentNode
                    .querySelector(".TurnirPrikazDisciplina")
                    .dispatchEvent(new CustomEvent("win", { "detail": { "pobednik": this } }));
                this.contestant.querySelector("label[for='Rang']").innerHTML = "👑";
                this.container.style.border = "2px dashed black";// + this.container.parentNode.style.color;
            }
        }
    }

    // Šalje promene podataka o učesniku na upis u bazu
    updateUcesnik()
    {
        if (this.changed) {
            fetch("https://0c0bfc1858a2.ngrok.io/Evidencija/UpdateUcesnik", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify({
                    id: this.id,
                    disciplinaID: this.disciplinaID,
                    turnirID: this.turnirID,
                    ime: this.ime,
                    prezime: this.prezime,
                    brzina: this.brzina,
                    rang: this.rang,
                    pozicija: this.pos,
                    selected: this.selected,
                    compete: this.compete
                })
            }).then(response =>
            {
                if (response.ok) {
                    console.log("Successfully updated ucesnik!");
                    this.changed = false;
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
    }
}