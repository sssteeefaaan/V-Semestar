import { Lokacija } from "./lokacija.js";
import { Vrt } from "./vrt.js"

// Pre početka rada aplikacije ne postoji ni jedan zoološki vrt u bazi podataka
// Kao vežbu, kreirati 2 zoološka vrta sa podacima po želji iz JS-a putem fetch metode.

fetch("https://localhost:5001/Zoo/PreuzmiVrtove").then(p => {
    p.json().then(data => {
        data.forEach(vrt => {
            const vrt1 = new Vrt(vrt.id, vrt.naziv, vrt.n, vrt.m, vrt.kapacitet);
            vrt1.crtajVrt(document.body);

            vrt.lokacije.forEach(l => {
                vrt1.lokacije[l.x * vrt.n + l.y].azurirajLokaciju(l.vrsta, l.kapacitet, l.tip, l.x, l.y);
            });
        });
    });
});

//const vrt1 = new Vrt("Zoo vrt", 5,4,6);
//vrt1.crtajVrt(document.body);


//const vrt2 = new Vrt("Drugi vrt", 10,10,20);
//vrt2.crtajVrt(document.body);