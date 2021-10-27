
function spoljna() {
  let a = "pozdrav iz spoljne";

  return function unutrasnja() {
    console.log(a);
  }

}

const fja = spoljna();

fja();