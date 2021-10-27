import { Fabrika } from "./fabrika.js";
import { Silos } from "./silos.js";

let fabrike = new Array();

fetch("https://localhost:5001/PreuzmiFabrike")
    .then(response =>
    {
        response.json().
            then(data =>
            {
                data.forEach(el =>
                {
                    fabrike.push(new Fabrika(el.naziv, el.id));
                    fabrike[fabrike.length - 1].nacrtajFabriku(document.body);

                    el.silosi.forEach(silos =>
                    {
                        fabrike[fabrike.length - 1].dodajSilos(new Silos(silos.oznaka, silos.kapacitet, silos.trenutnaKolicina, silos.id, el.id));
                    })
                });
            })
            .catch(error => console.log(error));
    })
    .catch(error => console.log(error));