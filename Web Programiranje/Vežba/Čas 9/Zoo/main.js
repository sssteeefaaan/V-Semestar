import { Vrt } from "./vrt.js";
import { Lokacija } from "./lokacija.js";

fetch("https://localhost:5001/Zoo/PreuzmiVrtove").then(p=>{
	p.json().then(data=>{
		data.forEach(vrt=>{
			const vrt1 = new Vrt(vrt.id, vrt.naziv, vrt.n, vrt.m, vrt.kapacitet);
			vrt1.crtajVrt(document.body);
			
			vrt.lokacije.forEach(lok=>{
				vrt1.lokacije[lok.y * vrt.n + lok.x].change(lok.vrsta, lok.kapacitet, lok.tip);
			});
		});
	});
});