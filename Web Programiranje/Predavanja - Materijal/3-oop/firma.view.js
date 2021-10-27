
export class FirmaView {

  constructor(firma) {
    if (!Array.isArray(firma.radnici)){
      throw new Error("Invalid firma object");
    }
    this.firma = firma;
  }

  crtaj() {
    const nazivFirme = document.createElement("h2");
    nazivFirme.innerHTML = this.firma.naziv;
    document.body.appendChild(nazivFirme);

    const tabelaRadnika = document.createElement("table");
    document.body.appendChild(tabelaRadnika);

    this.firma.radnici.forEach((radnik, index) => {
      const red = document.createElement("tr");
      tabelaRadnika.appendChild(red);

      const tdId = document.createElement("td");
      tdId.innerHTML = radnik.id;
      red.appendChild(tdId);

      const tdIme = document.createElement("td");
      tdIme.innerHTML = radnik.ime;
      red.appendChild(tdIme);

      const tdPlata = document.createElement("td");
      const lblPlata = document.createElement("label");
      tdPlata.appendChild(lblPlata);

      lblPlata.innerHTML = radnik.plata;
      red.appendChild(tdPlata);

      const smanjiPlatu = document.createElement("button");
      smanjiPlatu.innerHTML = "-";
      smanjiPlatu.onclick = (ev) => {
        radnik.plata -= 10;
        lblPlata.innerHTML = radnik.plata;
        tdZbir.innerHTML = this.firma.vratiZbirPlata();
      }

      tdPlata.appendChild(smanjiPlatu);
      const povecajPlatu = document.createElement("button");
      povecajPlatu.innerHTML = "+";
      povecajPlatu.onclick = (ev) => {
        radnik.plata += 10;
        lblPlata.innerHTML = radnik.plata;
        tdZbir.innerHTML = this.firma.vratiZbirPlata();
      }
      tdPlata.appendChild(povecajPlatu);

      const tdGodine = document.createElement("td");
      tdGodine.innerHTML = radnik.godineRadnogStaza;
      red.appendChild(tdGodine);
    });

    const red = document.createElement("tr");
    tabelaRadnika.appendChild(red);
    const tdZbir = document.createElement("td");
    tdZbir.colSpan = 4;
    tdZbir.innerHTML = this.firma.vratiZbirPlata();
    red.appendChild(tdZbir);
  }
}