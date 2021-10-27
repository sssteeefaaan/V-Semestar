import {FirmaView} from "./firma.view.js";
import {Firma} from "./firma.js";
import {Radnik} from "./radnik.js"

const radnici = [];
radnici.push(new Radnik(1, "Milan", 200, 2));
radnici.push(new Radnik(2, "Ana", 500, 3));
radnici.push(new Radnik(3, "Lazar", 700, 10));
radnici.push(new Radnik(4, "Ivana", 240, 6));

const firma = new Firma("EF", radnici);
const view = new FirmaView(firma);

view.crtaj();