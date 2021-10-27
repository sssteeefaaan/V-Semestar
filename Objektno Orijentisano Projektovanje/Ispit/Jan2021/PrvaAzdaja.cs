
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PrvaAzdaja : AzdajaFactory {

	public PrvaAzdaja() {
	}

	public override Krila CreateKrila() {
        return new GalebovaKrila();
    }
	public override Rep CreateRep() {
        return new DabrovRep();
    }
	public override Glava CreateGlava() {
        return new OkruglaGlava();
    }

}