
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PetaAzdaja : AzdajaFactory {

	private PetaAzdajaFactory PetaAzdajaFactory;
	public PetaAzdaja(PetaAzdajaFactory PAF) {
        this.PetaAzdajaFactory = PAF;
    }
	public override Krila CreateKrila() {
        return this.PetaAzdajaFactory.CreateKrila();
    }
	public override  Rep CreateRep() {
        return new ZvecarkinRep();
    }
	public override Glava CreateGlava() {
        return new SpicastaGlava();
    }

}