// Regularna definicija funkcije

function add(a, b)
{
    return a + b;
}

console.log("Add(5, 6) = ", add(5, 6));

// FE - Function Expression 
// Funkcijski izraz

const ovoJeFunckija = function sub(c, d) { return c - d; };

console.log("OvoJeFunkcija(5, 6) = ", ovoJeFunckija(5, 6));

// Anonimne funkcije (nemaju ime)
const ovoJeFunckijaDefinisanaAnonimnomFunkcijom = function (e, f) { return e * f; };

console.log("ovoJeFunckijaDefinisanaAnonimnomFunkcijom(5, 6) = ", ovoJeFunckijaDefinisanaAnonimnomFunkcijom(5, 6));

// Arrow funckije
// this ne menja značenje, uvek označava "vlasnika" funkcije (this is scope-a u kome je definisana)
const jedanArgument = g => g * 2;

console.log("jedanArgument(5) = ", jedanArgument(5));

const viseArgumenata = (h, i) => h % i;

console.log("viseArgumenata(5, 6) = ", viseArgumenata(5, 6));

const nijeSamoPovratnaVrednost = (j, k) =>
{
    if (k == 0)
        throw Error("Imenilac ne sme biti 0!");
    return j / k;
}

console.log("nijeSamoPovratnaVrednost(5, 6) = ", nijeSamoPovratnaVrednost(5, 6));

// Lambda funkcije
// Funkcija koja je povratna vrednost, ili argument neke nebitne funkcije

function nebitna(x)
{
    return /* Lambda function */function (y) { return x + y; };
}

const niz = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
const nizVeciOd5 = niz.filter(/* Lambda function */function (x) { return x > 5; });

console.log(niz);
console.log(nizVeciOd5);

//IIFE - Immediately Invoked Functional Expression

const proba = function (p, q, r) { return p > q ? p : r; }(7, 8, 9);
console.log(proba);

// Definicija klasa i privatni atributi
function klasa(argumenti, konstruktora)
{
    let arg = argumenti;
    let cnstrctr = konstruktora;

    function ponasanje()
    {
        return argumenti;
    };

    return {
        aliasArg: arg,
        aliasConstructor: cnstrctr,
        aliasPonasanje: ponasanje
    };
};

const objekat = new klasa(5, 6);
console.log(objekat);
console.log(objekat.aliasPonasanje());
console.log(objekat.aliasArg);
console.log(objekat.aliasConstructor);

const objekat2 = klasa(8, 9);
console.log(objekat2);
console.log(objekat2.aliasPonasanje());
console.log(objekat2.aliasArg);
console.log(objekat2.aliasConstructor);
