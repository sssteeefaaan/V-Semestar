import { Proizvod } from "./proizvod.js";
import { Prodavnica } from "./prodavnica.js";

const pr = new Prodavnica();

pr.dodajProizvod(new Proizvod("Sveska", 12435, 69, 20));
pr.dodajProizvod(new Proizvod("Knjiga", 87235, 199, 8));
pr.dodajProizvod(new Proizvod("Enciklopedija", 32543, 629, 3));
pr.dodajProizvod(new Proizvod("Blok", 75645, 98, 4));
pr.dodajProizvod(new Proizvod("Olovka", 65734, 9, 30));
pr.dodajProizvod(new Proizvod("Pernica", 28995, 541, 1));

pr.crtaj(document.body);

let btn = document.createElement("button");
btn.className = "DodajProizvod";
btn.innerHTML = "Dodaj novi proizvod!";
btn.onclick = (el) => { pr.dodajNoviProizvod(); };
document.body.appendChild(btn);