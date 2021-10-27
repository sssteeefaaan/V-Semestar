
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Podaci {

	public Podaci() {
        prijavljeni = polozili = oslobodjeni = 0;
    }

	private int prijavljeni;
	private int polozili;
	private int oslobodjeni;

	public int Prijavljeni{ get { return prijavljeni; } set { prijavljeni = value; } }
    public int Polozili{ get { return polozili; } set { polozili = value; } }

    public int Oslobodjeni{ get { return oslobodjeni; } set { oslobodjeni = value; } }
    public String VratiPodatke() {
        return $"Prijavilo se: {Prijavljeni}\nPolozilo je: {Polozili}\nOslobodjeno je: {Oslobodjeni}";
    }

}