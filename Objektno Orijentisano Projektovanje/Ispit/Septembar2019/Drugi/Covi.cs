
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drugi{
	public abstract class Covi : KategorijaLika {

		public Covi():base() {
            Energija *= 3;
        }
		public void Ugrizi(Bovi lik) {
			lik.UmanjiEnergiju(this.Energija);
            this.Energija *= 2;
		}
		public void Ugrizi(Covi lik) {
			lik.UmanjiEnergiju(this.Energija);
            this.Energija *= 2;
		}

	}
}