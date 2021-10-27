function permute(array: Array<number>): Array<Array<number>>
{
    let answers = new Array<Array<number>>()
    permuteRec(array, null, answers);
    return answers;
}

function permuteRec(possibilities: Array<number>, answer: Array<number>, answers: Array<Array<number>>)
{
    if (!possibilities.length) {
        answers.push(answer);
    }

    possibilities.forEach((possibility, ind) =>
    {
        const newAnswer = new Array<number>();
        answer?.forEach(el => newAnswer.push(el));
        newAnswer.push(possibility);

        permuteRec(possibilities.filter((el, ind1) => ind !== ind1), newAnswer, answers);
    });
}

function variate(array: Array<number>): Array<Array<number>>
{
    let answers = new Array<Array<number>>()
    variateRec(array, null, answers);
    return answers;
}

function variateRec(possibilities: Array<number>, answer: Array<number>, answers: Array<Array<number>>)
{
    if (!possibilities.length) {
        answers.push(answer);
    }

    for (let i = 0; i < possibilities.length; i++) {
        const newPossibilities = new Array<number>();
        const newAnswer = new Array<number>();

        let count = 0;
        answer?.forEach(el => newAnswer.push(el));
        for (let j = 0; j < possibilities.length; j++) {
            if (i != j)
                newPossibilities.push(possibilities[ j ]);
            else
                newAnswer.push(possibilities[ j ]);

            if (j >= i && possibilities[ i ] === possibilities[ j ])
                count++;
        }

        if (count == 1)
            variateRec(newPossibilities, newAnswer, answers);
    }
}
console.log("HEY");
let permutations = variate([ 1, 1, 3 ]);
console.log(permutations);