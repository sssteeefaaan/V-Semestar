
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class UpisnaKomisija : Klijent {

	public UpisnaKomisija() {
	}

	public override void Prikazi() {
        Console.WriteLine($"Upisna komisija:\n{obsPodaci.VratiPodatke()}");
    }


}