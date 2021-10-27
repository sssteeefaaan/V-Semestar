import { Student } from "./classes";
import { Person } from "./classes";

export class Community<T extends Person>
{
    private people: T[];
    private name: string;
    private container: HTMLElement;

    constructor(name: string)
    { this.setName(name); }

    private setName = (name: string): void => { this.name = name };
    public getName = (): string => this.name;

    public addMember(person: T)
    { this.people.push(person); };

    public printCommunity = (canvas: HTMLElement): void =>
    {
        this.container = document.createElement("div");
        this.container.classList.add("Community");
        canvas.appendChild(this.container);

        const info = document.createElement("label");
        info.htmlFor = "Name";
        info.innerHTML = this.name;
        this.container.appendChild(info);

        this.people.forEach(person =>
        { person.print(this.container) });
    };
}
