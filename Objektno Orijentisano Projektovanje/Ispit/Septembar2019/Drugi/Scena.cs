
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drugi{
	public abstract class Scena {

		public Scena() {
		}
		public Robot CreateRobot() {
            return new Robot();
        }

		public void RunFoodChain() {
			// TODO implement here
		}

	}
}