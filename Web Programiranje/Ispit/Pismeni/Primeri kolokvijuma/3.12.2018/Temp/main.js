import { Grad } from "./Grad.js";
import { MeteoPodatak } from "./MeteoPodatak.js";

let niz = new Array();
niz.push(new MeteoPodatak(28, 5, 25, "jun"));
niz.push(new MeteoPodatak(14, 14, 12, "mart"));
niz.push(new MeteoPodatak(7, 3, 28, "jul"));


const grad = new Grad("Nis", "2018", niz);
grad.crtaj(document.body);