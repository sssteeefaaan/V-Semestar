using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOProjektovanje.Podaci
{
    public class Osoba : Object
    {
        #region Atributes

        String _ime;
        String _prezime;
        String _jmbg;

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

        public Osoba(String ime, String prezime, String jmbg)
        {
            _ime = ime;
            _prezime = prezime;
            _jmbg = jmbg;
        }

        #endregion
    }
}
