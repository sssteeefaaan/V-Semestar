
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class PetaSismisovaAzdaja : PetaAzdajaFactory {

	public PetaSismisovaAzdaja() {
	}
	public override Krila CreateKrila() {
        return new SismisovaKrila();
    }

}