var array = [
    {
        name: "Leonid",
        lastname: "Petrovic",
        personalID: "0112985730043"
    },
    {
        name: "Milan",
        lastname: "Jankovic",
        personalID: "1210997730012"
    },
    {
        name: "Lola",
        lastname: "Medvedev",
        personalID: "1112997910023"
    },
    {
        name: "Aleksandra",
        lastname: "Rajevski",
        personalID: "0503999882912"
    },
    {
        name: "Ahmed",
        lastname: "Nurudin",
        personalID: "1705992901231"
    },
    {
        name: "Svetlana",
        lastname: "Raznatovic",
        personalID: "1406973891321"
    }
];

// 3. Vraca listu spojenih imena i prezimena (kao jedan string, sa razmakom), svih korisnika koji su rodjeni pre 1996.

function getYear(client) {
    var myID = parseInt(client.personalID);
    var myYear = (myID / Math.pow(10, 6)) % 1000;
    return myYear;
}

// III nacin

console.log("Rodjeni pre 1996:")
console.log(array.reduce((acc, curr) => (getYear(curr) < 996) ? [...acc, curr.name + " " + curr.lastname] : acc, []));