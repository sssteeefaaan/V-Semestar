interface Coordinate
{
  x: number;
  y: number;
}

const point = {
  x: 10,
  y: 20,
  name: "sta znam"
};

function getDistance(coords: Coordinate): number
{
  return Math.sqrt(Math.pow(coords.x, 2) + Math.pow(coords.y, 2));
}

console.log(`Distanca je =${getDistance(point)}`);

// definise se potpis fje
interface CoordinatesPredicate
{
  (coords: Coordinate): number
}

const calculateY: CoordinatesPredicate =
  function (coords: Coordinate): number
  {
    return coords.y;
  }

const getDistance2: CoordinatesPredicate =
  function (coords: Coordinate): number
  {
    return Math.sqrt(Math.pow(coords.x, 2) + Math.pow(coords.y, 2));
  }