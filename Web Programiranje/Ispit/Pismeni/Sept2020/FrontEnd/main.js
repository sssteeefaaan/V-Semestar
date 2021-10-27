import { ZooVrt } from "./zoovrt.js";
import { Staniste } from "./stanište.js";

let zoovrtovi = [];
fetch("https://localhost:5001/PreuzmiZooVrtove")
    .then(response =>
    {
        if (response.ok)
            response.json()
                .then(data =>
                {
                    data.forEach(zv =>
                    {
                        zoovrtovi.push(new ZooVrt(zv.naziv, zv.n, zv.m, zv.max, zv.tipoviStanista, zv.bojeStanista, zv.id));
                        zv.stanista.forEach(staniste =>
                        {
                            zoovrtovi[zoovrtovi.length - 1].stanista.push(new Staniste(staniste.vrsta, staniste.boja, staniste.max, staniste.trenutno, staniste.id, staniste.zoovrtid));
                        });
                        zoovrtovi[zoovrtovi.length - 1].nacrtaj(document.body);
                    });
                }).catch(error => console.log(error));
    }).catch(error => console.log(error));


// let zv1 = new ZooVrt('Zoo vrtić', 4, 3, 10, ["Savana", "Šuma", "Okean", "Pustinja"], ["orange", "lightgreen", "lightblue", "lightyellow"]);
// zv1.nacrtaj(document.body);