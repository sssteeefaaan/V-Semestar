var Community = /** @class */ (function () {
    function Community() {
        this.members = [];
    }
    Community.prototype.add = function (newMember) {
        this.members.push(newMember);
    };
    Community.prototype.getAverageAge = function () {
        var suma = this.members.reduce(function (acc, member) { return acc += member.age; }, 0);
        return suma / this.members.length;
    };
    return Community;
}());
var marko = {
    id: "235345",
    name: "Marko",
    age: 20,
    prosekOcena: 8.6
};
var milan = {
    id: "364365",
    name: "Milan",
    age: 30,
    prosecnaPlata: 60000
};
var community = new Community();
community.add(marko);
community.add(milan);
console.log(community.getAverageAge());
