export class Lokacija
{
    constructor(x, y, tip, vrsta, maxKapacitet)
    {
        this.x = x;
        this.y = y;
        this.tip = tip;     // boja stanista
        this.vrsta = vrsta;
        this.kapacitet = 0;
        this.maxKapacitet = maxKapacitet;
        this.miniKontejner = null;
    }

    vratiBoju()
    {
        if (!this.tip)
            return "lightgray";
        else
            return this.tip;
    }
    crtajLokaciju(host)
    {
        this.miniKontejner = document.createElement("div");
        this.miniKontejner.className = "lokacija";
        this.miniKontejner.innerHTML = "Prazno (" + this.kapacitet + "/" + this.maxKapacitet + ")";
        this.miniKontejner.style.backgroundColor = this.vratiBoju();
        host.appendChild(this.miniKontejner);
    }

    change(vrsta, kapacitet, tip)
    {
        if (this.vrsta != null && this.vrsta != vrsta)
            alert("Kavez već sadrži životinje!");
        else {
            if (this.kapacitet + kapacitet > this.maxKapacitet)
                alert("Kavez prevazilazi kapacitet!");
            else {
                this.vrsta = vrsta;
                this.kapacitet += kapacitet;
                this.tip = tip;

                this.miniKontejner.innerHTML = this.vrsta + " (" + this.kapacitet + "/" + this.maxKapacitet + ")";
                this.miniKontejner.style.backgroundColor = this.vratiBoju();
            }
        }
    }
}