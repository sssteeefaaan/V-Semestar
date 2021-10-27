export class Polica
{
    constructor(oznaka = "Unknown", maxDVD = 0, trenutniBrojDVD = 0, id = 0, videoKlubID = 0)
    {
        this.oznaka = oznaka;
        this.maxDVD = maxDVD;
        this.curDVD = trenutniBrojDVD;
        this.id = id;
        this.videoKlubID = videoKlubID;

        this.container = null;
    }

    dodajDVD(broj)
    {
        if (this.curDVD + broj < this.maxDVD) {
            this.curDVD += broj;
            this.azuriraj();
            this.osveziPrikaz();
        }
        else
            alert("Nema više mesta na polici!");
    }

    nacrtaj(parent)
    {
        this.container = document.createElement("div");
        this.container.classList.add("Polica");
        parent.appendChild(this.container);

        const div = document.createElement("div");
        div.classList.add("PolicaDVD");
        this.container.appendChild(div);

        let label = document.createElement("label");
        label.innerHTML = this.oznaka;
        label.htmlFor = this.oznaka;
        div.appendChild(label);

        const div2 = document.createElement("div");
        div2.classList.add("PolicaDVDPrikaz");
        div.appendChild(div2);

        label = document.createElement("label");
        label.htmlFor = "broj";
        this.container.appendChild(label);

        this.osveziPrikaz();
    }

    osveziPrikaz()
    {
        const prikaz = this.container.querySelector(".PolicaDVDPrikaz");
        if (prikaz != null) {

            while (prikaz.childNodes[0] != null) {
                prikaz.removeChild(prikaz.childNodes[0]);
            }

            let el;
            for (let i = 0; i < this.curDVD; i++) {
                el = document.createElement("div");
                el.classList.add("DVD");
                el.style.width = (1 / this.maxDVD) * 100 + "%";
                prikaz.appendChild(el);
            }

            this.container.querySelector("label[for='broj']").innerHTML = `${ this.curDVD }/${ this.maxDVD }`;
        }
    }

    azuriraj()
    {
        fetch("https://localhost:5001/AzurirajPolicu", {
            method: 'Post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                oznaka: this.oznaka,
                max: this.maxDVD,
                current: this.curDVD,
                id: this.id,
                videoKlubID: this.videoKlubID
            })
        }).then(response =>
        {
            if (response.ok)
                console.log("Uspešno ažurirana polica!");
            else
                response.json()
                    .then(badRequest => console.log(badRequest.message))
                    .catch(error => console.log(error));
        }).catch(error => console.log(error));
    }
}