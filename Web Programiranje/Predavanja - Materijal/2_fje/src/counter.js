// IIFE

const counter = (function (pocetna) {
  let count = pocetna;

  function display() {
    console.log(`current count is ${count}`);
  }

  function reset() {
    count = 0;
  }

  function increaseCount() {
    count++;
    display();
  }

  return {
    // count,
    reset, // isto kao i "reset: reset"
    increase: increaseCount
  };
})(5);

counter.increase();

// const brojac1 = new counter(3);
// brojac1.increase(); // 1
// brojac1.increase(); // 2

// const brojac2 = new counter(5);
// brojac2.increase(); // 1


//const counter = (function (pocetna) { ...})(7);