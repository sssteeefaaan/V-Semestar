interface Person {
  id: string;
  name: string;
  age: number;
}

interface Student extends Person {
  prosekOcena: number;
}

interface Radnik extends Person {
  prosecnaPlata: number;
}

class Community<T extends Person> {
  private members: T[];

  constructor() {
    this.members = [];
  }

  add(newMember: T) {
    this.members.push(newMember);
  }

  getAverageAge() {
    const suma = this.members.reduce((acc, member) => acc += member.age, 0);
    return suma / this.members.length;
  }
}

const marko: Student = {
  id: "235345",
  name: "Marko",
  age: 20,
  prosekOcena: 8.6
};

const milan: Radnik = {
  id: "364365",
  name: "Milan",
  age: 30,
  prosecnaPlata: 60000
};

const community = new Community<Person>();
community.add(marko);
community.add(milan);
console.log(community.getAverageAge());