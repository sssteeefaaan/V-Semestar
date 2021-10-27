export class Lokacija {
    constructor(i, j, tip, vrsta, Maxkapacitet) {
        this.x = i;
        this.y = j;
        this.kapacitet = 0;
        this.maxKapacitet = Maxkapacitet;
        this.tip = tip; //boja stanista
        this.vrsta = vrsta;// lav, labud...
        this.miniKontejner = null;

    }
    vratiBoju() {
        if (!this.tip)
            return "pink";
        else
            return this.tip;
    }
    crtajLokaciju(host) {
        this.miniKontejner = document.createElement("div");
        this.miniKontejner.className = "lok";
        this.miniKontejner.innerHTML = "Prazno, " + this.kapacitet + ", (" + this.maxKapacitet + ")";
        this.miniKontejner.style.backgroundColor = this.vratiBoju();
        host.appendChild(this.miniKontejner);

    }
    azurirajLokaciju(vrsta, kolicina, tip, x, y) {

        console.log("pozvano azuriranje");

        if (kolicina + this.kapacitet > this.maxKapacitet)
            alert("Kapacitet lokacije je popunjen");
        else {

            console.log(kolicina);
            this.vrsta = vrsta;
            this.tip = tip;
            this.kapacitet += kolicina;
            this.miniKontejner.innerHTML = this.vrsta + ", " + this.kapacitet + ", (" + this.maxKapacitet + ")";
            this.miniKontejner.style.backgroundColor = this.vratiBoju();
        }
    }
}