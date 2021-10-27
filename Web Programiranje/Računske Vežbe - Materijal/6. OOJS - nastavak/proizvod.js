export class Proizvod{

    constructor(ime,sifraProizvoda, cena, kolicina){
        this.ime = ime;
        this.sifra=sifraProizvoda;
        this.cena=cena;
        this.kolicina=kolicina;
        this.prozivodContainer =null;
    }

    cenaKolicina(){
        return this.cena*this.kolicina;
    }

    crtajProizvod(host){
        const red= document.createElement("tr");
        host.appendChild(red);

        this.prozivodContainer = red;
        let el=document.createElement("td");
        el.innerHTML=this.sifra;
        red.appendChild(el);

        el = document.createElement("td");
        el.innerHTML=this.ime;
        red.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.cena;
        red.appendChild(el);

        el = document.createElement("td");
        el.innerHTML = this.kolicina;
        el.className="kolicina";
        red.appendChild(el);

        //dugme za povecanja kolicine
        el = document.createElement("td");
        red.appendChild(el);

        let dugme = document.createElement("button");
        dugme.innerHTML="+";
        dugme.onclick = (ev)=>{
            this.povecajKolicinu("+");
        }
        el.appendChild(dugme);


        dugme = document.createElement("button");
        dugme.innerHTML="-";
        dugme.onclick = (ev)=>{
            this.povecajKolicinu("-");
        }
        el.appendChild(dugme);

        dugme = document.createElement("button");
        dugme.innerHTML="Obrisi";
        dugme.onclick = (ev)=>{
            this.obrisi();
        }
        el.appendChild(dugme);




        el = document.createElement("td");
        el.innerHTML = this.cenaKolicina();
        el.className ="cenaKolicina";
        red.appendChild(el);
    }

    obrisi(){
        console.log(this.prozivodContainer);

        var parent = this.prozivodContainer.parentNode;
        parent.removeChild(this.prozivodContainer);
        this.prodavnica.proizvodi =this.prodavnica.proizvodi.filter(el=>el.ime!==this.ime
            && el.sifra!==this.sifra);
        console.log(this.prodavnica);


    }

    povecajKolicinu(znak){

        console.log(znak);
        if(znak==="+")
            this.kolicina++;
        else
            this.kolicina--;

        let polje = this.prozivodContainer.querySelector(".kolicina");
        polje.innerHTML=this.kolicina;

        polje = this.prozivodContainer.querySelector(".cenaKolicina");
        polje.innerHTML=this.cenaKolicina();

    }

}