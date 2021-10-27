import { Help } from "./help.js";
import { Ucesnik } from "./ucesnik.js";
import { Disciplina } from "./disciplina.js";
import { Turnir } from "./turnir.js";


const turniri = [];
const discipline = [];
const ucesnici = [];

// Nabavljanje svih turnira iz baze
fetch("https://0c0bfc1858a2.ngrok.io/Evidencija/ReadTurnire").then(str =>
{
    str.json().then(data =>
    {
        data.forEach(el =>
        {
            turniri.push(new Turnir(el.id, el.naziv));
            turniri[turniri.length - 1].nacrtajTurnir(document.body);
        });
    }).catch(error =>
    {
        console.log("Error occurred: " + error)
    });
}
).catch(error =>
{
    console.log("Error occurred: " + error)
});

// Nabavljanje svih disciplina iz baze
fetch("https://0c0bfc1858a2.ngrok.io/Evidencija/ReadDiscipline").then(str =>
{
    str.json().then(data =>
    {
        data.forEach(el =>
        {
            discipline.push(new Disciplina(el.id, el.turnirID, el.naziv, el.lokacija, el.maxUcesnici, el.pobednikID));
            turniri.forEach(t =>
            {
                if (t.id == discipline[discipline.length - 1].turnirID) {
                    t.dodajDisciplinu(discipline[discipline.length - 1]);
                }
            });
        });
    }).catch(er =>
    {
        console.log("Error occurred: " + er);
    });
}).catch(er =>
{
    console.log("Error occurred: " + er);
});

// Nabavljanje svih učesnika iz baze
fetch("https://0c0bfc1858a2.ngrok.io/Evidencija/ReadUcesnike").then(str =>
{
    str.json().then(data =>
    {
        data.forEach(el =>
        {
            ucesnici.push(new Ucesnik(el.id, el.disciplinaID, el.turnirID, el.ime, el.prezime, el.brzina, 0/*el.pozicija*/, 0/*el.rang*/, el.compete, el.selected));
            discipline.forEach(dsc =>
            {
                if (dsc.id == el.disciplinaID && dsc.turnirID == el.turnirID) {
                    dsc.dodajUcesnika(ucesnici[ucesnici.length - 1]);
                }
            });
        });
    }).catch(er =>
    {
        console.log("Error occurred: " + er);
    });
}).catch(er =>
{
    console.log("Error occurred: " + er);
});