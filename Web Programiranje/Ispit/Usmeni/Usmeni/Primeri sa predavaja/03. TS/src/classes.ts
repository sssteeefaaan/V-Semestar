export class Person
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
    }
    private setID(id: string): void
    {
        this.ID = id;
    }
    public getID = (): string => this.ID;

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

export class Student extends Person
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

        [ [ "Index", this.indexID ], [ "Year", this.year ] ].forEach(el =>
        {
            const label = document.createElement("label");
            label.htmlFor = el[ 0 ].toString();
            label.innerHTML = el[ 1 ].toString();
            studentInfo.appendChild(label);
        });
    }
}