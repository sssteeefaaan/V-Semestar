function permute(array)
{
    let answers = new Array()
    permuteRec(array, null, answers);
    return answers;
}

function permuteRec(possibilities, answer, answers)
{
    if (!possibilities.length) {
        answers.push(answer);
    }

    possibilities.forEach((possibility, ind) =>
    {
        const newAnswer = new Array();
        answer?.forEach(el => newAnswer.push(el));
        newAnswer.push(possibility);

        permuteRec(possibilities.filter((el, ind1) => ind !== ind1), newAnswer, answers);
    });
}

function variate(array)
{
    let answers = new Array();
    variateRec(array, null, answers);
    return answers;
}

function variateRec(possibilities, answer, answers)
{
    if (!possibilities.length) {
        answers.push(answer);
    }

    for (let i = 0; i < possibilities.length; i++) {
        const newPossibilities = new Array();
        const newAnswer = new Array();

        let count = 0;
        answer?.forEach(el => newAnswer.push(el));
        for (let j = 0; j < possibilities.length; j++) {
            if (i != j)
                newPossibilities.push(possibilities[j]);
            else
                newAnswer.push(possibilities[j]);

            if (j >= i && possibilities[i] === possibilities[j])
                count++;
        }

        if (count == 1)
            variateRec(newPossibilities, newAnswer, answers);
    }
}


console.log("Permutations:", permute([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]));
console.log("Variations: ", variate([1, 2, 2, 4, 5, 1, 7, 8, 4, 10]));