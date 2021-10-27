function max(a, b) {
    return a > b ? a : b;
}
var Coordinates = /** @class */ (function () {
    function Coordinates(x, y, z) {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    Coordinates.prototype.getDotProduct = function (point) {
        return this.x * point.x + this.y * point.y + this.z * point.z;
    };
    return Coordinates;
}());
var PointA = new Coordinates(2.5, 1, -7);
var PointB = new Coordinates(7, -3.5, 2);
console.log(PointA.getDotProduct(PointB));
console.log(PointB.getDotProduct(PointA));
var calc = function (point1, point2) {
    return Math.sqrt(Math.pow(point1.x - point2.x, 2) + Math.pow(point1.y - point2.y, 2) + Math.pow(point1.z - point2.z, 2));
};
PointA.getDistance = calc;
PointB.getDistance = calc;
console.log(PointA.getDistance(PointA, PointB));
console.log(PointB.getDistance(PointB, PointA));
var LoveTowardsYou;
(function (LoveTowardsYou) {
    LoveTowardsYou[LoveTowardsYou["High"] = 100] = "High";
    LoveTowardsYou[LoveTowardsYou["Great"] = 75] = "Great";
    LoveTowardsYou[LoveTowardsYou["Alright"] = 50] = "Alright";
    LoveTowardsYou[LoveTowardsYou["Faint"] = 25] = "Faint";
    LoveTowardsYou[LoveTowardsYou["NonExistant"] = 0] = "NonExistant";
})(LoveTowardsYou || (LoveTowardsYou = {}));
var lOvE = LoveTowardsYou.High;
console.log(lOvE);
