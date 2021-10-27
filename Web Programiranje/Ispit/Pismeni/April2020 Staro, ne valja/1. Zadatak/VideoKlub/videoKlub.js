import { Help } from "./help.js";
import { Polica } from "./polica.js";


export class VideoKlub
{
    constructor(id, naziv = "Unknown")
    {
        this.id = id;
        this.naziv = naziv;
        this.police = [];
        this.container = null;
    }

    proslediContainer(host)
    {
        if (host) {
            this.container = Help.napraviElement("div", host, "VideoKlub");
            let div = Help.napraviElement("div", this.container, "VideoKlubHeaderDiv");
            let header = Help.napraviElement("h2", div, "VideoKlubHeader");
            header.innerHTML = "Video klub: \"" + this.naziv + "\"";

            div = Help.napraviElement("div", this.container, "VideoKlubBody");
            Help.napraviElement("div", div, "Unos");
            Help.napraviElement("div", div, "Izlog");
        }
    }

    dodajPolicu(polica)
    {
        if (this.container) {
            let host = this.container.querySelector(".Izlog");
            polica.proslediContainer(host);

            this.police.push(polica);
            this.nacrtajPolice(host);
        }
    }

    nacrtajVideoKlub(host)
    {
        if (!this.container)
            this.proslediContainer(host);

        let inputCont = this.container.querySelector(".Unos");
        let contentCont = this.container.querySelector(".Izlog");

        this.nacrtajUnos(inputCont);
        this.nacrtajPolice(contentCont);
    }

    nacrtajUnos(inputCont)
    {
        let div = Help.napraviElement("div", inputCont, "ZanrHeaderDiv");
        let header = Help.napraviElement("h3", div, "ZanrHeader");
        header.innerHTML = "Izaberite žanr:";

        let div2, input, label;
        this.police.forEach(el =>
        {
            div2 = Help.napraviElement("div", div, "RadioButtonDiv");
            input = Help.napraviElement("input", div2, "RadioInput");
            if (el.oznaka === this.police[0].oznaka)
                input.checked = true;
            input.type = "radio";
            input.name = "zanr";
            input.value = el.oznaka;

            label = Help.napraviElement("label", div2, "RadioLabel");
            label.innerHTML = el.oznaka;
        })

        div = Help.napraviElement("div", inputCont, "BrojDVD");
        header = Help.napraviElement("h4", div, "BrojHeader");
        header.innerHTML = "Broj DVD-ova:";

        input = Help.napraviElement("input", div, "BrojUnos");
        input.type = "number";
        let dugmeD = Help.napraviElement("button", div, "Dugme");
        dugmeD.innerHTML = "Dodaj na policu";
        dugmeD.onclick = el =>
        {
            const zanrD = this.container.querySelector(".RadioInput:checked").value;
            const brojD = parseInt(this.container.querySelector(".BrojUnos").value);
            if (brojD > 0) {
                const policaD = this.police.find(el => el.oznaka == zanrD);
                policaD.izmeniDVD(brojD);
            }
        };

        let dugmeU = Help.napraviElement("button", div, "Dugme");
        dugmeU.innerHTML = "Skini sa police";
        dugmeU.onclick = el =>
        {
            const zanrU = this.container.querySelector(".RadioInput:checked").value;
            const brojU = parseInt(this.container.querySelector(".BrojUnos").value);
            if (brojU > 0) {
                const policaU = this.police.find(el => el.oznaka == zanrU);
                policaU.izmeniDVD(brojU * (-1));
            }
        };
    }

    nacrtajPolice(host)
    {
        this.police.forEach(el =>
        {
            el.nacrtajPolicu(host);
        })
    }
}