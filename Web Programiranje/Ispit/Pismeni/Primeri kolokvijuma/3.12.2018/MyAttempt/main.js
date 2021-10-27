import { MeteoPodatak } from "./MeteoPodatak.js";
import { Grad } from "./Grad.js";

let grad = new Grad("Knjaževac", 2020);

["Jan", "Feb", "Mar",
    "Apr", "May", "Jun",
    "Jul", "Aug", "Sep",
    "Okt", "Nov", "Dec"].forEach(el =>
    {
        grad.dodajMesec(new MeteoPodatak(el, (Math.floor(Math.random() * 10) + 1) * 3, (Math.floor(Math.random() * 10) + 1) * 80, (Math.floor(Math.random() * 10) + 1) * 10));
    });


grad.nacrtajPrikaz(document.body);