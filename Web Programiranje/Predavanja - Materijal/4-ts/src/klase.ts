class Shape {

  getArea(): number {
    throw new Error("Not implemented");
  }
}

class Circle extends Shape{
  private r: number;
  constructor(r: number) {
    super();
    this.r = r;
  }
  getArea(): number {
    return Math.PI * Math.pow(this.r, 2);
  }
}

class Kvadrat extends Shape {
  private a: number;
  constructor(a: number) {
    super();
    this.a = a;
  }

  getArea(): number {
    return Math.pow(this.a, 2);
  }
}
const krug = new Circle(5);
console.log(`Pkruga=${krug.getArea()}`);

const kvadrat = new Kvadrat(10);
console.log(`Pkvadrata=${kvadrat.getArea()}`);