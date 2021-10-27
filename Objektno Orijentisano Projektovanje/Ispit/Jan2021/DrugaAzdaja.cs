
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DrugaAzdaja : AzdajaFactory {

	public DrugaAzdaja() {
	}

	public override Krila CreateKrila() {
        return new SismisovaKrila();
    }
	public override Rep CreateRep() {
        return new LavljiRep();
    }

	public override Glava CreateGlava() {
        return new OkruglaGlava();
    }

}