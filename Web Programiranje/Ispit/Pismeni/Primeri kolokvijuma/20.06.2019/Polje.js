export class Polje
{
    constructor(nivo, element)
    {
        this.nivo = nivo;
        this.element = element;
        this.container = null;
    }

    nacrtajPolje(div)
    {
        this.container = div;

        const el = document.createElement("div");
        el.className = "Polje";
        if (this.element == 0 || this.nivo == this.element)
            el.innerHTML = 1;
        else {
            const levi = this.container.parentNode.childNodes[this.nivo - 1].childNodes[this.element - 1];
            const desni = this.container.parentNode.childNodes[this.nivo - 1].childNodes[this.element];
            el.innerHTML = parseInt(levi.innerHTML) + parseInt(desni.innerHTML);
        }
        this.container.appendChild(el);

        el.addEventListener('click', () =>
        {
            this.container.parentNode.childNodes.forEach(nivo =>
            {
                nivo.childNodes.forEach(polje =>
                {
                    if (polje.innerHTML === el.innerHTML)
                        polje.style.backgroundColor = "pink";
                    else
                        polje.style.backgroundColor = "white";
                });
            });
        });
    }
}