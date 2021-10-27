using System;
using System.Collections.Generic;

namespace Drugi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<Azdaja> azdaje = new List<Azdaja>();

            azdaje.Add(new Azdaja(new PrvaAzdaja()));
            azdaje.Add(new Azdaja(new DrugaAzdaja()));
            azdaje.Add(new Azdaja(new TrecaAzdaja()));
            azdaje.Add(new Azdaja(new CetvrtaAzdaja()));
            azdaje.Add(new Azdaja(new PetaAzdaja(new PetaGalebovaAzdaja())));
            azdaje.Add(new Azdaja(new PetaAzdaja(new PetaOrlovaAzdaja())));
            azdaje.Add(new Azdaja(new PetaAzdaja(new PetaSismisovaAzdaja())));

            azdaje.ForEach(a =>
            {
                a.OglasiAzdaju();
                Console.WriteLine("------------------------------------------");
            });
            
            Console.ReadLine();
        }
    }
}
