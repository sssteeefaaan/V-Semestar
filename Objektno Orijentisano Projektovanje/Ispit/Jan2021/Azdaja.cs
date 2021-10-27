
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// @author Stefan Aleksić
/// </summary>
public class Azdaja {

public Azdaja(AzdajaFactory AF) {
        this.AzdajaFactory = AF;
        glava = AF.CreateGlava();
        krila = AF.CreateKrila();
        rep = AF.CreateRep();
    }
	private AzdajaFactory AzdajaFactory;

	private Krila krila;

	private Rep rep;

	private Glava glava;

	public void OglasiAzdaju() {
        Console.WriteLine("Ja sam Azdaja:");
        Console.WriteLine(glava.NabaviTip());
        Console.WriteLine(krila.NabaviTip());
        Console.WriteLine(rep.NabaviTip());
    }

}