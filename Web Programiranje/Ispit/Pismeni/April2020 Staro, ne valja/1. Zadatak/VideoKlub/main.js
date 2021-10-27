import { Polica } from "./polica.js";
import { VideoKlub } from "./videoKlub.js";

let videoKlub;
fetch("https://localhost:5001/VideoKlub/PreuzmiVideoKlubove").then(p =>
{
    p.json().then(data =>
    {
        data.forEach(el =>
        {
            videoKlub = new VideoKlub(el.id, el.naziv);
            videoKlub.proslediContainer(document.body);
            el.police.forEach(pol =>
            {
                videoKlub.dodajPolicu(new Polica(pol.videoKlubID, pol.oznaka, pol.boja, pol.max, pol.curr));
            });
            videoKlub.nacrtajVideoKlub(document.body);
        });
    }).catch(er => { console.log("Error with JSON " + er) });
}).catch(er => { console.log("Error with fetch! " + er) });


// let videoKlub1 = new VideoKlub("Faraon");
// videoKlub1.proslediContainer(document.body);
// let zanr = ["Drama", "Komedija", "Horor", "Triler", "Romansa"];
// let boje = ["yellow", "orange", "purple", "red", "pink"];
// let polica;
// zanr.forEach((el, ind) =>
// {
//     polica = new Polica(el, boje[ind], (ind + 1) * (ind + 2), 0);
//     videoKlub1.dodajPolicu(polica);
//     for (var i = 0; i < 2 * (ind + 1); i++)
//         polica.dodajDVD(1);

// })
// videoKlub1.nacrtajVideoKlub(document.body);