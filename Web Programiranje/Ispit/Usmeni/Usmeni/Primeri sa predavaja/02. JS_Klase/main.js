class Animal
{
    constructor(ime, godine)
    {
        this.ime = ime;
        this.godine = godine;
    }

    ostari()
    { this.godine++; }
    podmladi()
    { this.godine--; }
}

class Dog extends Animal
{
    constructor(ime, godine, zvuk)
    {
        super(ime, godine);
        this.zvuk = zvuk;
    }

    laj()
    { console.log(`${ this.ime }: ${ this.zvuk }!`); }
}

class Bichon extends Dog
{
    constructor(ime, godine, zvuk, boja)
    {
        super(ime, godine, zvuk);
        this.boja = boja;
    }

    ofarbaj(boja)
    { this.boja = boja; }
}

class Foo extends Bichon
{
    constructor(ime, godine, zvuk, boja, brzina)
    {
        super(ime, godine, zvuk, boja);
        this.brzina = brzina;
    }

    treniraj(brzina)
    { this.brzina = brzina; }
}

const proba = new Object({
    name: "Stefan",
    surname: "Aleksic",
    class: "RII 20/21"
});
console.log(proba);

const foo1 = new Foo("Kiki", 2, "AV", "olive", 20);
Foo.prototype.sviraj = "Okej";
console.log("Prvi log:", foo1);
console.log(foo1.__proto__ === Foo.prototype);

const foo2 = new Foo("Kiki", 2, "AV", "olive", 21);
console.log(foo2);

const bichon1 = new Bichon("Kiki", 2, "AV", "olive");
console.log(bichon1);