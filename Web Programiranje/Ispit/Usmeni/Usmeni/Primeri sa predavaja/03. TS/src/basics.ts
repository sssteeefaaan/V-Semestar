function max(a: number, b: number): number
{
    return a > b ? a : b;
}

interface Coords
{
    x: number,
    y: number,
    z: number
}

interface CoordsPredicate
{
    (x: Coords, y: Coords): number
}

class Coordinates
{
    x: number;
    public y: number;
    public z: number;

    constructor(x: number, y: number, z: number)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public getDistance: CoordsPredicate;

    getDotProduct(point: Coords)
    {
        return this.x * point.x + this.y * point.y + this.z * point.z;
    }
}

let PointA = new Coordinates(2.5, 1, -7);
let PointB = new Coordinates(7, -3.5, 2);

console.log(PointA.getDotProduct(PointB));
console.log(PointB.getDotProduct(PointA));

let calc = (point1: Coords, point2: Coords) =>
{
    return Math.sqrt(Math.pow(point1.x - point2.x, 2) + Math.pow(point1.y - point2.y, 2) + Math.pow(point1.z - point2.z, 2));
}

PointA.getDistance = calc;
PointB.getDistance = calc;
console.log(PointA.getDistance(PointA, PointB));
console.log(PointB.getDistance(PointB, PointA));


enum LoveTowardsYou
{
    High = 100,
    Great = 75,
    Alright = 50,
    Faint = 25,
    NonExistant = 0
}

const lOvE = LoveTowardsYou.High;
console.log(lOvE);