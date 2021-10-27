import { Polje } from "./polje.js";

export class Trougao
{
    constructor(naslov)
    {
        this.brojNivoa = 2;
        this.polja = [];
        this.container = null;
        this.naslov = naslov;
    }

    crtaj(host)
    {
        this.container = document.createElement("div");
        this.container.className = "glavni-div";
        host.appendChild(this.container);
        const divForma = document.createElement("div");
        divForma.className = "forma-div";
        this.container.appendChild(divForma);

        const divTrougao = document.createElement("div");
        divTrougao.className = "trougao-div";
        this.container.appendChild(divTrougao);

        this.crtajFormu(divForma, divTrougao);
        
    }

    crtajFormu(host, divTrougao)
    {   
        const pomocniDiv = document.createElement("div"); 
        const naslovh1 = document.createElement("h1");
        naslovh1.innerHTML = this.naslov;
        host.appendChild(naslovh1);
        host.appendChild(pomocniDiv);
        const label = document.createElement("label");
        label.innerHTML = "Unesite broj nivoa";
        pomocniDiv.appendChild(label);
        const numberOfLevels = document.createElement("input");
        numberOfLevels.type = "number";
        numberOfLevels.className = "numberOfLevels-input";
        pomocniDiv.appendChild(numberOfLevels);
        const dugmeSubmit = document.createElement("button");
        dugmeSubmit.innerHTML = "Submit";
        dugmeSubmit.onclick = (ev) => {
            this.crtajPrikaz(divTrougao);
        }
        pomocniDiv.appendChild(dugmeSubmit);
    }

    crtajPrikaz(host)
    {
        host.innerHTML = "";
        const brojNivoa = this.container.querySelector(".numberOfLevels-input").value;
        console.log(brojNivoa);
        let red = null;
        let kockica = null;
        for(let i = 0; i < brojNivoa; i++)
        {
            this.polja[i] = new Array();
            red = document.createElement("div");
            red.className = "red-div";
            host.appendChild(red);
            for(let j = 0; j <= i; j++)
            {
                if(i == j || j == 0)
                {
                    this.polja[i][j] = new Polje(1);
                }
                else
                {
                    let value = this.polja[i-1][j-1].vrednost + this.polja[i-1][j].vrednost;
                    this.polja[i][j] = new Polje(value);    

                }
                let kockica = this.polja[i][j].crtaj(red);
                kockica.onclick = (ev) =>
                {
                    this.oboji(ev.currentTarget);
                }
            }
            console.log(this.polja);
        }
    }
    oboji(el)
    {
        const obojeni = this.container.querySelectorAll(".obojeno");
        for(let i = 0; i < obojeni.length; i++)
        {
            obojeni[i].classList.remove("obojeno");
        }
        const value = el.innerHTML;
        const niz = this.container.querySelectorAll(".polje-div"+value);
        for(let i = 0; i < niz.length; i++)
        {
            niz[i].classList.add("obojeno");
        }
        console.log(niz);
    }

}