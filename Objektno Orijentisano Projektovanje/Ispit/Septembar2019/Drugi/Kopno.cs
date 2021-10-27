
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drugi{
	public class Kopno : Scena {

		public Kopno() {
		}
		public Vuk CreateVuk() {
            return new Vuk();
        }
		public Medved CreateMedved() {
            return new Medved();
        }
		public Ovca CreateOvca() {
            return new Ovca();
        }
		public Koza CreateKoza() {
            return new Koza();
        }
		public Vampir CreateVampir() {
            return new Vampir();
        }

	}
}