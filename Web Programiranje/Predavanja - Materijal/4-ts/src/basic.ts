// tsc -w basic.ts --outFile ../dist/main.js

function max(a: number, b: number): number {
  return a > b ? a : b;
}

console.log(max(5, 10));

const niz: number[] = [2, 6,7, 8, 9];
const suma = niz.reduce((acc:number, broj: number) => acc += broj, 0);
console.log(suma);

enum Status {
  OK = 1, 
  Warning = 2,
  Error = 4
}

const networkStatus: Status = Status.Error;
console.log(`Status = ${networkStatus}`);