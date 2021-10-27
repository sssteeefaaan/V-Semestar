import { Polica } from "./polica.js";
import { VideoKlub } from "./videoKlub.js";

let vk1 = new Array();

fetch("https://localhost:5001/PreuzmiVideoKlubove").then(response =>
{
    if (response.ok) {
        response.json().then(data =>
        {
            data.forEach(videoKlub =>
            {
                vk1.push(new VideoKlub(videoKlub.naziv, videoKlub.id));
                vk1[vk1.length - 1].nacrtaj(document.body);
                videoKlub.police.forEach(polica =>
                {
                    vk1[vk1.length - 1].dodajPolicu(new Polica(polica.oznaka, polica.max, polica.current, polica.id, videoKlub.id));
                });
            });
        })
            .catch(error => console.log(error));
    }
}).catch(error => console.log(error));