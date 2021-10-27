class Person
{
    public name: string;
    public surname: string;
    private ID: string;
    public ig: string;
    private container: HTMLElement;

    public constructor(name: string, surname: string, ID: string, ig: string)
    {
        this.name = name;
        this.surname = surname;
        this.setID(ID);
        this.ig = ig;
        this.container = null;
    }
    private setID(id: string): void
    {
        this.ID = id;
    }
    public getID = (): string => this.ID;

    public getContainer(): HTMLElement { return this.container };

    public print(canvas: HTMLElement)
    {
        this.container = document.createElement("div");
        this.container.classList.add("Person");
        canvas.appendChild(this.container);

        [ [ "Name", this.name ], [ "Surname", this.surname ], [ "ID", this.ID ], [ "Instagram", this.ig ] ].forEach(el =>
        {
            const label = document.createElement("label");
            label.htmlFor = el[ 0 ];
            label.innerHTML = el[ 1 ];
            this.container.appendChild(label);
        });
    };
}

class Student extends Person
{
    private indexID: string;
    public year: number;

    public constructor(name: string, surname: string, ID: string, ig: string, indexID: string, year: number)
    {
        super(name, surname, ID, ig);
        this.setIndexID(indexID);
        this.year = year;
    }

    private setIndexID(indexID: string)
    {
        this.indexID = indexID;
    }
    public getIndexID = (): string => this.indexID;

    public print(canvas: HTMLElement)
    {
        super.print(canvas);
        const studentInfo = document.createElement("div");
        studentInfo.classList.add("Student");
        this.getContainer().appendChild(studentInfo);

        [ [ "Index", this.indexID ], [ "Year", this.year ] ].forEach(el =>
        {
            const label = document.createElement("label");
            label.htmlFor = el[ 0 ].toString();
            label.innerHTML = el[ 1 ].toString();
            studentInfo.appendChild(label);
        });
    }
}

class Community<T extends Person>
{
    private people: T[];
    private name: string;
    private container: HTMLElement;

    constructor(name: string)
    {
        this.setName(name);
        this.people = new Array<T>();
        this.container = null;
    }

    private setName = (name: string): void => { this.name = name };
    public getName = (): string => this.name;

    public addMember(person: T)
    { this.people.push(person); };

    public printCommunity = (canvas: HTMLElement): void =>
    {
        this.container = document.createElement("div");
        this.container.classList.add("Community");
        canvas.appendChild(this.container);

        const info = document.createElement("h1");
        info.innerHTML = this.name;
        this.container.appendChild(info);

        this.people.forEach(person =>
        { person.print(this.container) });
    };
}

let comm = new Community("Niš");

[ [ "Stefan", "Aleksić", "0203000750024", "sssteeefkkke", "16995", "2021" ],
[ "Petar", "Kocić", "0342343232", "petkoc", "18743", "2022" ],
[ "Milica", "Stević", "2304329423", "mici", "12312", "1999" ] ].forEach(el =>
{
    comm.addMember(new Student(el[ 0 ], el[ 1 ], el[ 2 ], el[ 3 ], el[ 4 ], parseInt(el[ 5 ])));
});
comm.printCommunity(document.body);