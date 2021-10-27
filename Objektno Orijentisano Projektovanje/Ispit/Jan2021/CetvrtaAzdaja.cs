
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CetvrtaAzdaja : AzdajaFactory {

	public CetvrtaAzdaja() {
	}
	public override Krila CreateKrila() {
        return new OrlovaKrila();
    }
	public override Rep CreateRep() {
        return new DabrovRep();
    }
	public override Glava CreateGlava() {
        return new CoskastaGlava();
    }

}