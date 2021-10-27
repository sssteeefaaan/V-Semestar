export class MeteoPodatak{
    constructor(temp, kol, sun, naziv) {
        this.temp = temp;
        this.kol = kol;
        this.sun = sun;
        this.naziv = naziv;

        if (!this.naziv)
         this.naziv = "jan";
         if(!this.kol)
         this.kol = 0;
    }

    crtajStub(host, max, tip) {
        const grafik = document.createElement("div");
        grafik.className = "grafik";
        host.appendChild(grafik);

        const stub = document.createElement("div");
        stub.className = "stub";
        
        console.log((this.temp*100)/max);
        console.log(max);
       

        const lab = document.createElement("div");
        lab.className = "labela";
        grafik.appendChild(lab);
        grafik.appendChild(stub);

        if (tip == "temperatura") {
        stub.style.height = (this.temp*100)/max + "%";
        lab.innerHTML = this.naziv + " " + this.temp;
        } else if (tip == "padavine") {
        stub.style.height = (this.kol*100)/max + "%";
        lab.innerHTML = this.naziv + " " + this.kol;
        } else {
        stub.style.height = (this.sun*100)/max + "%";
        lab.innerHTML = this.naziv + " " + this.sun;
        }

    }


}