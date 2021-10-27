using System;
using System.ComponentModel;

namespace OOProjektovanje.Podaci
{
    public class Osoba : Object
    {
        #region Atributes

        String _ime;
        String _prezime;
        String _jmbg;
        String _pol;

        #endregion

        #region Properties

        public String Ime
        {
            get { return _ime; }
            set { _ime = value; }
        }


        public String Prezime
        {
            get { return _prezime; }
            set { _prezime = value; }
        }

        public String Jmbg
        {
            get { return _jmbg; }
            set { _jmbg = value; }
        }

        public String Pol
        {
            get { return _pol; }
            set { _pol = value; }
        }

        //   [Browsable(true)]
        //  [DisplayName("Za prikaz")]
        public String ZaPrikaz
        {
            get
            {
                return _ime + " " + _prezime + " JMBG:" + _jmbg;
            }
        }

        #endregion

        #region Constructors

        public Osoba()
        {
        }

        public Osoba(String ime, String prezime, String jmbg, String pol)
        {
            _ime = ime;
            _prezime = prezime;
            _jmbg = jmbg;
            _pol = pol;
        }

        #endregion
    }
}
