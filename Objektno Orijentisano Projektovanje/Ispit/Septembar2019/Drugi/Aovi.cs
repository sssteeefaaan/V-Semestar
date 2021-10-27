
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drugi{
	public abstract class Aovi : KategorijaLika {

		public Aovi():base() {
            Energija *= 5;
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