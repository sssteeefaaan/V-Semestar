import { Kula } from "./kula.js";
import { Deo } from "./deo.js";

export class Tabla
{
    constructor(h, brojKula, brojStepena)
    {
        this.h = h;
        this.brojKula = brojKula;
        this.brojStepena = brojStepena;
        this.kule = [];
        this.canvas = null;
        this.container = null;
        this.izabrana = null;
        this.moves = 0;
        this.historyUndo = [];
        this.historyRedo = [];
    }

    nacrtajTablu(host)
    {
        this.canvas = Deo.napraviElement("div", host, "Tabla");

        let div = Deo.napraviElement("div", this.canvas, "Header");
        let state = Deo.napraviElement("h2", div, "Potezi");
        state.innerHTML = "Moves: " + this.moves;

        let undo = Deo.napraviElement("button", div, "Undo");
        undo.innerHTML = "Undo";
        let redo = Deo.napraviElement("button", div, "Redo");
        redo.innerHTML = "Redo";

        undo.onclick = (el) =>
        {
            if (this.historyUndo.length >= 2) {
                let temp = this.historyUndo.pop();
                let temp2 = this.historyUndo.pop();

                this.historyRedo.push(temp);
                this.historyRedo.push(temp2);

                temp2.dodajRed(temp.ukloniRed());
                this.moves--;
                state.innerHTML = "Moves: " + this.moves;
            }
        };

        redo.onclick = (el) =>
        {
            if (this.historyRedo.length >= 2) {
                let temp = this.historyRedo.pop();
                let temp2 = this.historyRedo.pop();

                this.historyUndo.push(temp);
                this.historyUndo.push(temp2);

                temp2.dodajRed(temp.ukloniRed());
                this.moves++;
                state.innerHTML = "Moves: " + this.moves;
            };
        };

        this.container = Deo.napraviElement("div", this.canvas, "PoljeZaIgru");
        this.container.style.height = this.h + "px";
        let brojStepena = this.brojStepena;
        for (var i = 0; i < this.brojKula; i++) {
            this.kule.push(new Kula(parseInt(this.container.offsetWidth) / (this.brojKula), this.h, brojStepena));
            this.kule[i].nacrtajKulu(this.container);
            brojStepena = 0;
        }
        this.container.onclick = (el) =>
        {
            let selected = false;
            this.kule.forEach(element =>
            {
                if (element.kliknuto) {
                    selected = true;
                    if (this.izabrana != null && this.izabrana != element) {
                        this.izabrana.kliknuto = false;
                        element.kliknuto = false;

                        this.izabrana.container.style.border = "1px solid black";
                        element.container.style.border = "1px solid black";

                        if (this.izabrana.delovi.length > 0 && (element.delovi.length < 1 || (this.izabrana.delovi[this.izabrana.delovi.length - 1].name < element.delovi[element.delovi.length - 1].name))) {
                            this.historyUndo.push(this.izabrana);
                            this.historyUndo.push(element);

                            let red = this.izabrana.ukloniRed();
                            element.dodajRed(red);
                            this.moves++;
                            state.innerHTML = "Moves: " + this.moves;
                        }
                        else
                            alert("Nije dozvoljeno prebacivanje");

                        this.izabrana = null;
                    }
                    else
                        this.izabrana = element;
                }
            })
            if (selected == false)
                this.izabrana = null;
        };
    }
}