using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OOP.Podaci
{
    [Serializable]
    public class Imenik
    {
        private List<Osoba> _listaOsoba;

        [XmlArrayItem("Osoba", typeof(Osoba))]
        public List<Osoba> ListaOsoba
        {
            get { return _listaOsoba; }
            set { _listaOsoba = value; }
        }

        public Imenik()
        {
            _listaOsoba = new List<Osoba>();
        }

        public void AddOsoba(Osoba o)
        {
            _listaOsoba.Add(o);
        }
    }
}
