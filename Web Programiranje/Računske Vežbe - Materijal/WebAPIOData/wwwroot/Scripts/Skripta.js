document.addEventListener("DOMContentLoaded", readData);

// var promenjiva;

function readData() {
    fetch("Airport/Airports").then(p => {
        p.json().then(q => writeDataToTable(q));

        // promenjiva = 10;
    });

    // let response = await fetch("Airport/Airports");
    // let prom = await response.json();
    // console.log(prom);
}

function writeDataToTable(data) {
    var tbody = document.querySelector("table>tbody");

    data.forEach(element => {
        var tr = document.createElement("tr");

        for (let key in element) {
            var td = document.createElement("td");
            td.innerText = element[key];

            tr.appendChild(td);
        }

        tbody.appendChild(tr);
    });
}