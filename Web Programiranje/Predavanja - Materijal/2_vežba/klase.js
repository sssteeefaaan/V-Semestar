function Product(id, name)
{
    this.id = id;
    this.name = name;
    this.info = function ()
    {
        console.log(`${ this.id } ${ this.name }`);
    };
};

const prod = new Product(897, "Proizvod", 200);
prod.info();

function Laptop(id, name, price)
{
    this.__proto__ = Product.prototype;
    this.constructor(id, name);
    this.price = price;
};

function Laptop1(id, name, price)
{
    this.__proto__ = Object.create(Product.prototype);
    this.constructor(id, name);
    this.price = price;
};

function Laptop2(id, name, price)
{
    this.Product = Product;
    this.Product(id, name);
    this.price = price;
};


const laptop = new Laptop(543, "Lenovo", 1000);
laptop.info();

const laptop1 = new Laptop1(888, "Asus", 1000);
laptop1.info();

const laptop2 = new Laptop2(999, "Apple", 1000);
laptop2.info();