export class Grad {
    constructor(naziv, god, meteo)
    {
        this.naziv= naziv;
        this.god = god;
        this.meteo = meteo;
        this.container = null;
    }

    crtaj(host) {
        if (!host)
        throw new Error("Nije prosledjen host");

        this.container = document.createElement("div");
        this.container.className = "glavniContainer";
        host.appendChild(this.container);

        const head = document.createElement("div");
        head.className = "zaglavlje";
        this.container.appendChild(head);

        const stubici = document.createElement("div");
        stubici.className = "stubici";
        this.container.appendChild(stubici);

        this.crtajZaglavlje(head, stubici);
        //this.crtajStubice(stubici);
        

    }

    crtajZaglavlje(host, stubici){
        const imeGrad = document.createElement("div");
        imeGrad.className = "imeGrad";
        host.appendChild(imeGrad);
        const naslov = document.createElement("h2");
        naslov.innerHTML = "Grad" + this.naziv + ", godina: " + this.god + ".";
        imeGrad.appendChild(naslov);

        const dugmici = document.createElement("div");
        dugmici.className = "dugmici";
        imeGrad.appendChild(dugmici);
        let niz = ["temperatura", "padavine", "suncani dani"];
        let rButton = null;
        let lab = null;
        niz.forEach(el => {
            rButton = document.createElement("input");
            rButton.type = "radio";
            rButton.value = el;
            rButton.name = "dugme";

            lab = document.createElement("label");
            lab.innerHTML = el;

            dugmici.appendChild(rButton);
            dugmici.appendChild(lab);
        })

        const dugme = document.createElement("button");
        dugme.innerHTML = "prikazi";
        imeGrad.appendChild(dugme);

        dugme.onclick = (ev) => {
           
            this.crtajStubice(stubici);
        }
    }

    crtajStubice(host){
        host.innerHTML = "";

        const buttons = this.container.querySelector("input:checked").value;
        var max = 0;

        if (buttons == "temperatura"){
        this.meteo.forEach(el => {
            if (el.temp > max)
            max = el.temp;
        })

        } else if (buttons == "padavine") {
            this.meteo.forEach(el => {
                if (el.kol > max)
                max = el.kol;
            })
        
        } else {
            this.meteo.forEach(el => {
                if (el.sun > max)
                max = el.sun;
            })
        }


    

        this.meteo.forEach(el => {
            el.crtajStub(host, max, buttons);
        })
    }
} 