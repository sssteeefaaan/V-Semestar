
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Prijemni : ISubject {

	public Prijemni() {
        subPodaci = new Podaci();
        kandidati = new List<Kandidat>();
        observers = new List<IObserver>();
    }
	private Podaci subPodaci;
	private List<Kandidat> kandidati;
	private List<IObserver> observers;
	public void Subscribe(IObserver Obs) {
		if(observers.Contains(Obs))
		return;

        observers.Add(Obs);
    }

	public void Unsubscribe(IObserver Obs) {
        observers.Remove(Obs);
    }

	public void NotifyAll() {
        observers.ForEach(o => o.Update(this));
    }

	public Podaci getData() {
        return this.subPodaci;
    }
    public void PrijaviSe(Kandidat kandidat)
    {
        if (kandidati.Contains(kandidat))
            return;

        kandidati.Add(kandidat);
        subPodaci.Prijavljeni++;

		if(kandidat.Oslobodjen)
            subPodaci.Oslobodjeni++;

        NotifyAll();
    }
    public void Polazi(Kandidat kandidat) {
		if(kandidat.Oslobodjen)
            return;
        subPodaci.Polozili++;
        NotifyAll();
    }

}