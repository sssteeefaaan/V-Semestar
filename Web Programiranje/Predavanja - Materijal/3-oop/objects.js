function Product(id, name, price) {
    this.id = id; 
    this.name = name;
    this.price = price;

    // this.increasePrice = x => {
    //     this.price += x;
    // }
}

const proizvod1 = new Product(2, "Laptop", 1000);
const proizvod2 = new Product(3, "Telefon", 300);

debugger;

Product.prototype.increasePrice = function(x) {
        this.price += x;
        console.log(this.price);
    }
