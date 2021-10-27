
class Animal {

  constructor(name, age) {
      this.name = name;
      this.age = age;
      this.speed = 0;
  }

  run() {
      this.speed = 20;
  }
}

class Dog extends Animal {

  constructor(name, age, color) {
    super(name, age);
    this.color;
  }

  run() {
    this.speed = 40;
  }
}

const an1 = new Animal("Dzeki", 3);
const pas1 = new Dog("MMM", 2, "crna");