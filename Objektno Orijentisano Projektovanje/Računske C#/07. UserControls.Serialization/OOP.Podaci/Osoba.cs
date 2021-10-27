using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace OOP.Podaci
{
    [Serializable]
    public class Osoba
    {
        #region Atributes

        private String _ime;
        private String _prezime;
        private List<String> _listaTelefona;

        #endregion

        #region Constructors

        public Osoba()
        {
            _listaTelefona = new List<String>();
        }

        public Osoba(String ime, String prezime, List<String> listaTelefona)
        {
            _ime = ime;
            _prezime = prezime;
            _listaTelefona = new List<String>();
            _listaTelefona = listaTelefona;
        }

        #endregion


        #region Properties

        [XmlElementAttribute("Ime")]
        public String Ime
        {
            get { return _ime; }
            set { _ime = value; }
        }


        [XmlElementAttribute("Prezime")]
        public String Prezime
        {
            get { return _prezime; }
            set { _prezime = value; }
        }


        [XmlArrayItem("Telefon", typeof(String))]
        public List<String> ListaTelefona
        {
            get { return _listaTelefona; }
            set { _listaTelefona = value; }
        }

        [XmlIgnore]
        public String ZaPrikaz
        {
            get
            {
                return _ime + " " + _prezime;
            }
        }

        #endregion
    }
}
