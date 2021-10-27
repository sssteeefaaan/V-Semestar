function Animal(ime, godine)
{
    this.ime = ime;
    let starost = godine;

    this.getAge = () => starost;
    this.setName = function (ime) { this.ime = ime; };

    this.ostari = function () { starost++; };
    this.podmladi = function () { starost--; };
};

// function Dog(ime, godine, zvuk)
// {
//     this.__proto__ = Animal.prototype;
//     this.__proto__.constructor(ime, godine);
//     let sound = zvuk;

//     this.pustiZvuk = function () { console.log(sound) };
// };

function Dog(ime, godine, zvuk)
{
    this.Animal = Animal;
    this.Animal(ime, godine);
    let sound = zvuk;

    this.pustiZvuk = function () { console.log(sound) };
};
let psi = new Dog("fifi", 2, "av");
console.log(psi);