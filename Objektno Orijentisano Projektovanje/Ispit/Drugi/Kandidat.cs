
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Kandidat {

	public Kandidat(bool oslobodjen = false) {
        prijemni = new List<Prijemni>();
        Oslobodjen = oslobodjen;
    }

	private bool oslobodjen;

	private List<Prijemni> prijemni;

	public bool Oslobodjen{get { return oslobodjen; }set { oslobodjen = value; } }

	public void PrijaviIspit(Prijemni p) {
        p.PrijaviSe(this);
        this.prijemni.Add(p);
    }
	public void PolaziIspit(Prijemni prijemni) {
        prijemni.Polazi(this);
    }

}