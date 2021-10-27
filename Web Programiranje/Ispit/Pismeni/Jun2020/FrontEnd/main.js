import { Igrac } from "./igrač.js";
import { Mec } from "./meč.js";

let igraci = [new Igrac("Novak Đoković", 33, 1, new Array(6, 5), "https://thumbor.forbes.com/thumbor/fit-in/416x416/filters%3Aformat%28jpg%29/https%3A%2F%2Fspecials-images.forbesimg.com%2Fimageserve%2F5ece884dbdf23b00084e577b%2F0x0.jpg%3Fbackground%3D000000%26cropX1%3D460%26cropX2%3D1949%26cropY1%3D185%26cropY2%3D1672"), new Igrac("Rafael Nadal", 34, 2, new Array(4, 6), "https://www.aljazeera.com/wp-content/uploads/2019/03/55d4aba6a570417280c790d119c91ee7_18.jpeg?resize=770%2C513")];
let mec = new Mec("Roland Garros", new Date(), igraci);
mec.nacrtaj(document.body);