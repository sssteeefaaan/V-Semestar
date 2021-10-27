export class MeteoPodatak
{
    constructor(naziv, temperatura, kolicinaPadavina, brojSuncanihDana)
    {
        this.naziv = naziv;
        this.temp = temperatura;
        this.pad = kolicinaPadavina;
        this.sun = brojSuncanihDana;

        this.container = null;
    }

    nacrtajPodatak(container, tip, max)
    {
        if (this.container == null) {
            this.container = document.createElement("div");
            this.container.classList.add("Podatak");
            container.appendChild(this.container);
        }

        this.osveziPrikaz(max, tip);
    }

    osveziPrikaz(max, tip)
    {
        while (this.container.childNodes[0] != null) {
            this.container.removeChild(this.container.childNodes[0]);
        }

        let el = document.createElement("div");
        el.classList.add("PodatakBar");
        this.container.appendChild(el);

        let elVal = document.createElement("label");

        switch (true) {
            case (tip == "T"):
                el.style.height = (this.temp / max * 80) + "%"; // Nije 100, jer treba mesta i labelama
                console.log(this.naziv, this.container.offsetHeight, el.offsetHeight);
                elVal.innerHTML = this.temp + " C";
                break;
            case (tip == "P"):
                el.style.height = (this.pad / max * 80) + "%";
                elVal.innerHTML = this.pad + " mm";
                break;
            case (tip == "B"):
                el.style.height = (this.sun / max * 80) + "%";
                elVal.innerHTML = this.sun + " dana";
                break;
        }

        el = document.createElement("label");
        el.innerHTML = this.naziv;
        this.container.appendChild(el);

        this.container.appendChild(elVal);
    }
}