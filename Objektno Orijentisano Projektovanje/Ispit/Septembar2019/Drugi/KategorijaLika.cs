
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drugi{
	public abstract class KategorijaLika {

		public KategorijaLika() {
            Energija = 100;
        }
		protected int Energija;
		public void UmanjiEnergiju(int s) {
            Energija -= s;	
        }
		public void PovecajEnergiju(int s) {
            Energija += s;
        }

	}
}