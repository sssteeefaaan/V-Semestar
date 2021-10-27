export class Prodavnica{
    constructor(){
        this.proizvodi=[];
        this.container=null;
    }

    dodajProizvod(pro){
        this.proizvodi.push(pro);
    }

    crtaj(host){
        if(!host)
        throw new Error("Host nije definisan");

        const tabela = document.createElement("table");
        this.container=tabela;
        host.appendChild(tabela);

        this.crtajZaglavlje(tabela);
        this.proizvodi.forEach(el=>{
            el.prodavnica=this;
            el.crtajProizvod(tabela);
        })
    }

    crtajZaglavlje(host){

        const red=  document.createElement("tr");
        host.appendChild(red);

        let e= document.createElement("th");
        e.innerHTML="Sifra";
        red.appendChild(e);

        
        e= document.createElement("th");
        e.innerHTML="Naziv";
        red.appendChild(e);

        e= document.createElement("th");
        e.innerHTML="Cena";
        red.appendChild(e);

        e= document.createElement("th");
        e.innerHTML="Kolicina";
        red.appendChild(e);

        e= document.createElement("th");
        red.appendChild(e);

        e= document.createElement("th");
        e.innerHTML="Cena*Kolicina";
        red.appendChild(e);

    }

}