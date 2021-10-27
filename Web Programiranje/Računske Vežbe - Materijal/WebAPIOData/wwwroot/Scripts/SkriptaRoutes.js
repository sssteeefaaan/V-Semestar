document.addEventListener("DOMContentLoaded", readData);

function readData() {
    fetch("Airport/Routes").then(p => p.json().then(q => writeDataToTable(q)));
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