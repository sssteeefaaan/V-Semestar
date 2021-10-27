function random7()
{
    /*Nije dovoljno jednom pozvati random5(), jer tu garantujemo brojeve 1, 2, 3, 4, 5
    Ako pozovemo dva puta, suma će biti:
    P(1) = 0,
    P(2) = 1/5 * 1/5,
    P(3) = 1/5 * 1/5 * 2,
    P(4) = 1/5 * 1/5 * 3,
    P(5) = 1/5 * 1/5 * 4,
    P(6) = 1/5 * 1/5 * 5,
    P(7) = 1/5 * 1/5 * 4,
    P(8) = 1/5 * 1/5 * 3, 
    P(9) = 1/5 * 1/5 * 2, 
    P(10) = 1/5 * 1/5

    Potrebno je ravnomerno rasporediti vrednosti i pozive
    
    */
    /*          Stablo odlučivanja       
                        |
        ---------------------------------
        |1/5    |1/5    |1/5    |1/5    |1/5
        1       2       3       4       5
        |       |       |       |       |
      12345   12345   12345   12345   12345
      |||||   |||||   |||||   |||||   |||||     za svaki po 1/5%
      12345   67123   45671   23456   7xxxx

    P(n) = 1/5 * 1/5 * 3 + 1/5 * 4/5 * (1/5 * 1/5 * 3 + 1/5 * 4/5 (...))
    Verovatnoća da se u beskonačnost poziva rekurzija -> 0
    n = {1, 2, 3, 4, 5, 6, 7}
    */
    let number = (random5() - 1) + (random5() - 1) * 5;
    return number >= (7 * 3) ? random7() : number % 7 + 1;
}

function random5()
{
    return Math.floor(Math.random() * 5) + 1;
}

let count = [0, 0, 0, 0, 0, 0, 0];
for (let i = 0; i < 100000; i++) {
    count[random7() - 1]++;
}

let num = 1;
count.forEach(el =>
{
    console.log(`${ num++ }: ${ el / 1000 * 100 }`);
});

console.log(count);