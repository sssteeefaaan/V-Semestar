import {Prodavnica} from "./prodavnica.js";
import { Proizvod } from "./proizvod.js";

const pr = new Prodavnica();

pr.dodajProizvod(new Proizvod("sveska",123, 56, 20));
pr.dodajProizvod(new Proizvod("olovka",235, 15, 100));
pr.dodajProizvod(new Proizvod("knjiga",365, 150, 5));

pr.crtaj(document.body);