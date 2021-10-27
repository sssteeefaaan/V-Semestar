
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drugi{
	public abstract class Bovi : KategorijaLika {

		public Bovi():base() {
            Energija *= 2;
        }

	}
}