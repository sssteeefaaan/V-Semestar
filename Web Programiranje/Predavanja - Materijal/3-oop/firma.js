export class Firma {

  constructor(naziv, radnici) {
    this.radnici = radnici;
    this.naziv = naziv;
  }

  vratiZbirPlata() {
    return this.radnici
      .map(radnik => radnik.plata)
      .reduce((acc, plata) => {
        acc += plata;
        return acc;
      }, 0);
  }
}