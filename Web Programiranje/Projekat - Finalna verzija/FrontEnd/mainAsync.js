import { Help } from "./help.js";
import { Ucesnik } from "./ucesnik.js";
import { Disciplina } from "./disciplina.js";
import { Turnir } from "./turnir.js";

// Asinhrona funkcija za pribavljanje objekata iz baze
async function load()
{
    const turniri = [];
    const discipline = [];
    const ucesnici = [];
    let data, response;

    // Nabavljanje svih turnira iz baze
    response = await fetch("https://0c0bfc1858a2.ngrok.io/Evidencija/ReadTurnire");
    if (response.ok) {
        data = await response.json();
        data.forEach(el =>
        {
            turniri.push(new Turnir(el.id, el.naziv));
            turniri[turniri.length - 1].nacrtajTurnir(document.body);
        })
    }
    else
        response.json()
            .then(er => console.log(er.message))
            .catch(er => console.log(er));

    // Nabavljanje svih disciplina iz baze
    response = await fetch("https://0c0bfc1858a2.ngrok.io/Evidencija/ReadDiscipline");
    if (response.ok) {
        data = await response.json();
        for await (var el of data) {
            discipline.push(new Disciplina(el.id, el.turnirID, el.naziv, el.lokacija, el.maxUcesnici, el.pobednikID));

            if (el.pobednikID != null)
                await discipline[discipline.length - 1].nabaviPobednika(el.pobednikID);

            turniri.forEach(t =>
            {
                if (t.id == discipline[discipline.length - 1].turnirID) {
                    t.dodajDisciplinu(discipline[discipline.length - 1]);
                }
            });
        }
    }
    else
        response.json()
            .then(er => console.log(er.message))
            .catch(er => console.log(er));

    // Nabavljanje svih učesnika iz baze
    response = await fetch("https://0c0bfc1858a2.ngrok.io/Evidencija/ReadUcesnike");
    if (response.ok) {
        data = await response.json();
        data.forEach(el =>
        {
            ucesnici.push(new Ucesnik(el.id, el.disciplinaID, el.turnirID, el.ime, el.prezime, el.brzina, 0/*el.pozicija*/, 0/*el.rang*/, el.compete, el.selected));
            discipline.forEach(dsc =>
            {
                if (dsc.id == el.disciplinaID && dsc.turnirID == el.turnirID) {
                    dsc.dodajUcesnika(ucesnici[ucesnici.length - 1]);
                }
            });
        })
    }
    else
        response.json()
            .then(er => console.log(er.message))
            .catch(er => console.log(er));
}

load();