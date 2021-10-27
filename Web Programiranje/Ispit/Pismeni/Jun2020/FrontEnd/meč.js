import { Igrac } from "./igrač.js";

export class Mec
{
    constructor(lokacija = "Unknown", vreme = new Date(), igraci, brojMeceva = 2)
    {
        this.lokacija = lokacija;
        this.vreme = vreme;
        if (igraci == null || igraci.length != 2)
            throw new Error("Potrebno je tačno dva igrača za tim!");
        this.igraci = igraci;
        this.brojMeceva = brojMeceva;

        this.container = null;
    }

    nacrtaj(parent)
    {
        this.container = document.createElement("div");
        this.container.classList.add("Mec");
        parent.appendChild(this.container);

        this.nacrtajHeader();
        this.nacrtajBody();
    }

    nacrtajHeader()
    {
        const header = document.createElement("div");
        header.classList.add("MecHeader");
        this.container.appendChild(header);

        let el = document.createElement("h4");
        el.innerHTML = `Lokacija: ${ this.lokacija }`;
        header.appendChild(el);

        el = document.createElement("label");
        el.htmlFor = "time";
        //window.setInterval(this.timer.bind(this), 1000);
        header.appendChild(el);
        this.timer();
    }

    timer()
    {
        this.container.querySelector("label[for='time']").innerHTML = /*new Date()*/this.vreme.toLocaleTimeString("en-us",
            {
                weekday: "short", month: "short",
                day: "numeric", year: "numeric",
                hour: "2-digit", minute: "2-digit",
                second: "2-digit", hour12: false,
                timeZone: 'GMT', timeZoneName: 'short'
            });
    }

    nacrtajBody()
    {
        const body = document.createElement("div");
        body.classList.add("MecBody");
        this.container.appendChild(body);

        let el;
        ["MecPrviIgrac", "MecInfo", "MecDrugiIgrac"].forEach(element =>
        {
            el = document.createElement("div");
            el.classList.add(element);
            body.appendChild(el);

            if (element === "MecPrviIgrac")
                this.igraci[0].nacrtaj(el);
            else if (element === "MecDrugiIgrac")
                this.igraci[1].nacrtaj(el);
        });

        el = this.container.querySelector(".MecInfo");

        let div, el2, div2;

        ["Rezultat", "Poeni"].forEach(element =>
        {
            div = document.createElement("div");
            div.classList.add(element);
            el.appendChild(div);

            if (element === "Rezultat") {
                ["Rezultat", "0 - 0", "(-)"].forEach((element2, ind) =>
                {
                    el2 = document.createElement("h3");
                    if (ind == 0) {
                        el2.innerHTML = element2;
                    }
                    else if (ind == 1) {
                        el2.className = "MatchResult";
                    }
                    else {
                        el2.className = "Sets";
                    }
                    div.appendChild(el2);
                });
            }
            else {
                ["Poeni", " "].forEach(element2 =>
                {
                    el2 = document.createElement("h4");
                    if (element2 === " ") {
                        el2.className = "Score";
                    }
                    else {
                        el2.innerHTML = element2;
                    }
                    div.appendChild(el2);
                });

                div2 = document.createElement("div");
                div2.classList.add("Dugmici");
                div.appendChild(div2);
                ["PrviIgrac", "DrugiIgrac"].forEach(buttons =>
                {
                    el2 = document.createElement("button");
                    el2.innerHTML = "+";
                    el2.name = buttons;
                    div2.appendChild(el2);

                    el2.addEventListener('click', (event) =>
                    {
                        console.log(event.target.name);
                        if (this.igraci[0].poeni[this.igraci[0].poeni.length - 1] < 6 && this.igraci[1].poeni[this.igraci[1].poeni.length - 1] < 6) {
                            if (event.target.name == "PrviIgrac")
                                this.igraci[0].poeni[this.igraci[0].poeni.length - 1] += 1;
                            else
                                this.igraci[1].poeni[this.igraci[1].poeni.length - 1] += 1;
                        }
                        else {
                            if (event.target.name == "PrviIgrac") {
                                this.igraci[0].poeni.push(1);
                                this.igraci[1].poeni.push(0);
                            }
                            else {
                                this.igraci[0].poeni.push(0);
                                this.igraci[1].poeni.push(1);
                            }
                        }
                        this.updateScore();
                    });
                });
            }
        });
        this.updateScore();
        this.updateResult();
    }

    updateResult()
    {
        let el = this.container.querySelector("h3[class='MatchResult']");
        el.innerHTML = `${ this.igraci[0].poeni.filter(el => el == 6).length } - ${ this.igraci[1].poeni.filter(el => el == 6).length }`;
        if (this.igraci[0].poeni.length != this.igraci[1].poeni.length)
            throw new Error("Igrači nisu igrali isti broj setova!");

        el = this.container.querySelector("h3[class='Sets']");
        let content = "";
        this.igraci[0].poeni.forEach((poen, ind) =>
        {
            content += `(${ poen } - ${ this.igraci[1].poeni[ind] }), `;
        });
        el.innerHTML = content.slice(0, -2);
        if (this.igraci[0].poeni.length >= this.brojMeceva)
            this.container.querySelector(".Dugmici").childNodes.forEach(bttn => bttn.disabled = true);
    }
    updateScore()
    {
        let el = this.container.querySelector("h4[class='Score']");
        if (this.igraci[0].poeni[this.igraci[0].poeni.length - 1] < 6 && this.igraci[1].poeni[this.igraci[1].poeni.length - 1] < 6)
            el.innerHTML = `${ this.igraci[0].poeni[this.igraci[0].poeni.length - 1] } - ${ this.igraci[1].poeni[this.igraci[1].poeni.length - 1] }`;
        else {
            el.innerHTML = "-----";
            this.updateResult();
        }
    }
}