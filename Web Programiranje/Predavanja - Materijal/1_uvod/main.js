let ime = "Milan";
ime = "Jovan";

console.log(ime);

const element = document.querySelector(".vest-dana button");
element.onclick = function(ev) {
  // element.style.backgroundColor = "red";
  document.querySelector(".vest-dana").style.display = "none";
}