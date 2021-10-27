let a = {
  ime: "Milan",
  prezime: "Milovanovic"
};

a = {
  ime: "Ivan",
  prezime: "Milovanovic"
};

console.log(a);

console.log(max(5, 8)); // hoisting

// deklaracija fje
function max(a, b)
{
  return a > b ? a : b;
}

// ne radi
// console.log("5^2=", square(5));

// funkcijski izraz (FE - function expression)
const square = function (a)
{
  return a * a;
};

console.log("5^2=", square(5));

// arrow fja
// this unutar tela predstavlja objekat koji je definisao arrow funkciju
// kod regularnih funkcija, this predstavlja objekat koji je pozvao funkciju
const square2 = a => a * a;

const niz = [2, 4, 6, "7", 9, 4];
const pomocna = 2;
// index je opcioni parametar
niz.forEach((el, index) => console.log(index + ", " + el));

// const niz2 = [];
// for (let i = 0; i < niz.length; i++) {
//   niz2.push(niz[i]*2);
// }

// lambda fje ( funkcije koje su argument ili povratna vrednost drugih funckija )
// map - projekcija N -> N
let niz2 = niz.map(el => el * 2);
// filter - N -> M, (M<N)
// za filter, lambda fja vraca boolean

const veciOd10 = el => el > 10;
niz2 = niz2.filter(veciOd10);

// reduce - N -> 1
const suma = niz2.reduce((acc, el) =>
{
  acc += el;
  return acc;
}, 0);

// chaining
const suma2 = niz
  .map(el => el * 2)
  .filter(el => el > 10)
  .reduce((acc, el) =>
  {
    acc += el;
    return acc;
  }, 0);

// let suma = 0;
// for(let i = 0; i < niz2.length; i++ ) {
//   suma += niz2[i];
// }
console.log("novi niz je ", niz2);
console.log("suma je ", suma2);
// 2+2+""+2

//prosecna ocena svih studenata 3. god
const studenti = []; //....
const trecaGodina = studenti.filter(student => student.godina === 3);
const prosek = trecaGodina.reduce((acc, student) =>
{
  acc += student.prosek;
  return acc;
}, 0) / trecaGodina.length;


function uporediReci(prvaRec, drugaRec)
{
  const prvaRecBezBlanka = izbaciBlanko(prvaRec);
  const drugaRecBezBlanka = izbaciBlanko(drugaRec);
  return prvaRecBezBlanka == drugaRecBezBlanka;
}

function izbaciBlanko(rec)
{
  return rec.split("").filter(x => x !== " ").join("");
  // let novaRec = "";
  // for (let i = 0; i < rec.length; i++) {
  //   if (rec[i] !== " ") {
  //     novaRec += rec[i];
  //   }
  // }
  // return novaRec;
}

console.log(uporediReci("Mar ko Markovic", "Marko Mar ko vic"));
