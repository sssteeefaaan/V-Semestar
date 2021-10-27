export class Staniste
{
    constructor(vrsta = "Prazno", boja = "lightblue", max = 0, trenutno = 0, id = 0, zoovrtid = 0)
    {
        this.vrsta = vrsta;
        this.boja = boja;
        this.max = max;
        this.trenutno = trenutno;
        this.id = id;
        this.zoovrtid = zoovrtid;

        this.cotainer = null;
    }

    nacrtaj(parent)
    {
        this.container = document.createElement("div");
        this.container.classList.add("Staniste");
        this.container.style.backgroundColor = this.boja;
        parent.appendChild(this.container);

        let el = document.createElement("label");
        el.innerHTML = `${ this.vrsta }, ${ this.trenutno }/${ this.max }`;
        el.htmlFor = "Opis";
        this.container.appendChild(el);
    }

    osvezi(vrsta, kolicina, boja)
    {
        if (this.trenutno + kolicina <= this.max) {
            this.vrsta = vrsta;
            this.boja = boja;
            this.trenutno += kolicina;
            const el = this.container.querySelector("label[for='Opis']");
            this.container.style.backgroundColor = this.boja;
            el.innerHTML = `${ this.vrsta }, ${ this.trenutno }/${ this.max }`;
            this.azuriraj();
        }
        else { alert("Stanište je puno!"); }
    }

    azuriraj()
    {
        fetch(`https://localhost:5001/AzurirajStaniste`,
            {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    id: this.id,
                    zoovrtid: this.zoovrtid,
                    boja: this.boja,
                    trenutno: this.trenutno,
                    vrsta: this.vrsta
                })
            }).then(response =>
            {
                if (response.ok)
                    console.log("Uspešno ažurirana lokacija!");
                else
                    response.json()
                        .then(badRequest => alert(badRequest.message))
                        .catch(error => console.log(error));
            })
            .catch(error => console.log(error));
    }
}