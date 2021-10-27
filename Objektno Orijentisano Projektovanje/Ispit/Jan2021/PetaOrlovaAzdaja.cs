
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class PetaOrlovaAzdaja : PetaAzdajaFactory {

	public PetaOrlovaAzdaja() {
	}
	public override Krila CreateKrila() {
        return new OrlovaKrila();
    }

}