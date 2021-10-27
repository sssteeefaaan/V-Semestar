
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public abstract class Klijent :IObserver {

	public Klijent() {
        obsPodaci = new Podaci();
    }

	protected Podaci obsPodaci;

	public void Update(ISubject s) {
        obsPodaci = s.getData();
        Prikazi();
    }

	public abstract void Prikazi();

}