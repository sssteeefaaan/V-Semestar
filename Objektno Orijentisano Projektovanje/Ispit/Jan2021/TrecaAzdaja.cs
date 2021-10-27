
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TrecaAzdaja : AzdajaFactory {

	public TrecaAzdaja() {
	}
	public override Krila CreateKrila() {
        return new SismisovaKrila();
    }
	public override Rep CreateRep() {
        return new ZvecarkinRep();
    }
	public override Glava CreateGlava() {
        return new CoskastaGlava();
    }

}