export class Deo
{
    constructor(w, h, name)
    {
        this.w = w;
        this.h = h;
        this.name = name;
        this.container = null;
    }

    nacrtajDeo(host)
    {
        this.container = Deo.napraviElement("div", host, "Deo");
        this.container.style.width = this.w + "px";
        this.container.style.height = this.h + "px";
        this.container.innerHTML = this.name;
    }

    static napraviElement(type, parent, className)
    {
        let element = document.createElement(type);
        element.className = className;
        parent.appendChild(element);
        return element;
    }
}