using System;
using System.Collections.Generic;

namespace Drugi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Klijent> klijenti = new List<Klijent>();
            klijenti.Add(new Univerzitet());
            klijenti.Add(new UpisnaKomisija());
            klijenti.Add(new Dekanat());

            Prijemni p = new Prijemni();
            klijenti.ForEach(k => p.Subscribe(k));

            List<Kandidat> kandidati = new List<Kandidat>();
            for (int i = 0; i < 10; i++)
                kandidati.Add(new Kandidat((i % 5) == 0));

            kandidati.ForEach(k =>
            {
                k.PrijaviIspit(p);
                k.PolaziIspit(p);
            });

            Console.ReadLine();
        }
    }
}
