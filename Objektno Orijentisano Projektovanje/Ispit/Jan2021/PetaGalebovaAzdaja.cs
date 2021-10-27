
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PetaGalebovaAzdaja : PetaAzdajaFactory {

	public PetaGalebovaAzdaja() {
	}

	public override Krila CreateKrila() {
        return new GalebovaKrila();
    }

}