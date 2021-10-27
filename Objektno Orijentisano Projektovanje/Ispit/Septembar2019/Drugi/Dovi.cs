
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drugi{
	public abstract class Dovi : KategorijaLika {

		public Dovi() :base(){
            Energija *= 4;
        }
		public void Ugrizi(Bovi lik) {
			lik.UmanjiEnergiju(this.Energija);
            this.Energija *= 2;
		}

	}
}