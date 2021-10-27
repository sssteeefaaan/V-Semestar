export class Help
{
    static napraviElement(type, parent, className)
    {
        let el = document.createElement(type);
        el.classList.add(className);
        parent.appendChild(el);
        return el;
    }
}