import { Help } from "./help.js";

export class Polica
{
    constructor(videoKlubID, oznaka = "unknown", boja = "black", max = 0, curr = 0)
    {
        this.videoKlubID = videoKlubID;
        this.oznaka = oznaka;
        this.boja = boja;
        this.max = max;
        this.curr = curr;
        this.container = null;
    }

    izmeniDVD(broj = 1)
    {
        fetch(`https://localhost:5001/VideoKlub/PromeniDVD/${ this.videoKlubID }/${ this.oznaka }/${ broj }`, {
            method: "POST"
        }).then(p =>
        {
            if (p.ok) {
                this.curr += broj;
                this.nacrtajDiskove(this.container.querySelector(".Sadrzaj"));
                this.container.querySelector(".Stanje").innerHTML = this.curr + "/" + this.max;
            }
            else {
                p.json().then(er =>
                    console.log(er)
                ).catch(er =>
                    console.log("Error unpacking json " + er)
                );
            }
        }).catch(er =>
        {
            console.log("Error unpacking answer " + er);
        });
        // if (this.curr + broj <= this.max) {
        //     this.curr += broj;
        //     this.nacrtajDiskove(this.container.querySelector(".Sadrzaj"));
        //     this.container.querySelector(".Stanje").innerHTML = this.curr + "/" + this.max;
        // }
        // else
        //     alert(`Polica sa žanrom ${ this.oznaka } nema dovoljan kapacitet!`);
    }

    nacrtajPolicu(host)
    {
        if (!this.container)
            this.proslediContainer(host);

        let labelCont = this.container.querySelector(".Zanr");
        let contentCont = this.container.querySelector(".Sadrzaj");

        labelCont.innerHTML = this.oznaka;
        this.nacrtajDiskove(contentCont);
        this.container.querySelector(".Stanje").innerHTML = this.curr + "/" + this.max;
    }

    proslediContainer(host)
    {
        this.container = Help.napraviElement("div", host, "Polica");
        Help.napraviElement("div", this.container, "Zanr");
        Help.napraviElement("div", this.container, "Sadrzaj");
        Help.napraviElement("div", this.container, "Stanje")
    }

    nacrtajDiskove(contentCont)
    {
        let div;
        while (contentCont.childNodes.length < this.max) {
            div = Help.napraviElement("div", contentCont, "DVD");
        }
        div = contentCont.querySelectorAll(".DVD");
        div.forEach((el, ind) =>
        {
            if (ind < this.curr) {
                el.classList.remove("Empty");
                el.classList.add("Taken");
                el.style.backgroundColor = this.boja;
            }
            else {
                el.classList.remove("Taken");
                el.classList.add("Empty");
                el.style.backgroundColor = "white";
            }
        })
    }
}