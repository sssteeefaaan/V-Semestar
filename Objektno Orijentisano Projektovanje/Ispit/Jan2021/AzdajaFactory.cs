
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public abstract class AzdajaFactory {

	public AzdajaFactory() {
	}

	public abstract Krila CreateKrila();

	public abstract Rep CreateRep();

	public abstract Glava CreateGlava();

}