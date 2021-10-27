document.body.onload            // Poziva se pri učitavanju body-ja
{

    let panel=document.querySelector("#panel");

    let nizLabela=["Ime", "Prezime", "Indeks", "Password", "Datum"];
    let nizPolja=["text", "text", "number", "password", "date"];

    let intf=document.createElement("div");
    intf.className="intf";
    panel.appendChild(intf);
    
    let secL=document.createElement("div");
    setLabSecColors(secL,"slateblue","white");
    secL.className="secL";
    intf.appendChild(secL);

    let secS=document.createElement("div");
    secS.className="secS";
    intf.appendChild(secS);

    let lab, polje;
    nizLabela.forEach((el,i) =>{

        lab = document.createElement("label");  // Kreiramo element HTML-a
        lab.innerHTML=el + ": ";                // 
        lab.className="labela";                 // Označili smo da labela pripada klasi labela
        //lab.classList.add("imeLab");          // Dodali smo da labela pripada još jednoj klasi, pored klase labela
        secL.appendChild(lab);                 // Roditeljskom elementu panel dodajemo člana(dete) lab

        polje=document.createElement("input");
        polje.type=nizPolja[i];
        polje.className="unos";
        polje.name=lab.innerHTML;
        polje.pera="wow " + i;
        secS.appendChild(polje);
    })

    let dugme=document.createElement("button");
    dugme.innerHTML="Klikni";
    dugme.className="dugme";
    panel.appendChild(dugme);

    dugme.addEventListener("click",kliknuto);

    function kliknuto(){
        
        let sadrzaj = document.querySelectorAll(".unos");
        let labele = document.querySelectorAll(".labela");
        let t="", flag=true;

        sadrzaj.forEach((el,i)=>{

            if(el.value=="") flag=false;
            t+=`${el.name} ${el.value}\n`;
        })

        if(flag){

            setLabSecColors(secL,"orange","black");
            alert(t);
            setLabSecColors(secL,"slateblue","white");
            console.log(labele);
        }
        else alert("Popunite sva polja!");
    }

    function setLabSecColors(sec, back, font){
        sec.style.backgroundColor=back;
        sec.style.color=font;
    }
    
}