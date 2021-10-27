
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Univerzitet : Klijent {

	public Univerzitet() {
	}

	public override void Prikazi() {
        Console.WriteLine($"Univerzitet:\n{obsPodaci.VratiPodatke()}");
    }

}