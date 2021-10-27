
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Dekanat : Klijent {

	public Dekanat() {
	}

	public override void Prikazi() {
        Console.WriteLine($"Dekanat:\n{obsPodaci.VratiPodatke()}");
    }
}