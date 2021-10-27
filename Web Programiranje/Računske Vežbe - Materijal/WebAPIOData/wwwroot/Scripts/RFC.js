function readData() {
    var sel = document.getElementById("aerodrom");
    var city = sel.options[sel.selectedIndex].value;
    fetch("Airport/GetRoute/" + city).then(p => p.json().then(q => writeDataToTable(q)));
}

function writeDataToTable(data) {
    var tbody = document.querySelector("table>tbody");

    clearChildren(tbody);

    data.forEach(element => {
        var tr = document.createElement("tr");

        addTd(tr, element["CallSign"]);
        addTd(tr, element["ToAirportRef"]["Name"]);
        addTd(tr, element["ToAirportRef"]["City"]);
        addTd(tr, element["ToAirportRef"]["State"]);
        addTd(tr, element["ToAirportRef"]["Country"]);
        addTd(tr, element["ToAirportRef"]["Elevation"]);
        addTd(tr, element["ToAirportRef"]["Latitude"]);
        addTd(tr, element["ToAirportRef"]["Longitude"]);
        addTd(tr, element["Passangers"]);

        tbody.appendChild(tr);
    });
}

function addTd(tr, element) {
    var td = document.createElement("td");
    td.innerText = element;
    tr.appendChild(td);
}

function clearChildren(element) {
    while (element.childNodes.length > 0) {
        element.childNodes[0].remove();
    }
}