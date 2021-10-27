using System;
using System.Collections.Generic;

namespace OOProjektovanje.Podaci
{
    public class ListaOsoba
    {
        public delegate void SortDelegate(List<Osoba> o);
        public SortDelegate SortListDelegate { get; set; }

        #region Atributes

        private List<Osoba> _listaOsoba;

        #endregion

        #region Properties
        public List<Osoba> ListaOsobaValues
        {
            get
            {
                return _listaOsoba;
            }
        }
        #endregion

        #region Constructors

        private ListaOsoba()
        {
            _listaOsoba = new List<Osoba>();
        }

        #endregion

        #region Methodes

        public bool DodajOsobu(Osoba o)
        {
            if (PostojiOsobaUListi(o))
                return false;

            _listaOsoba.Add(o);
            return true;
        }

        public bool ObrisiOsobu(Osoba o)
        {
            if (!PostojiOsobaUListi(o))
                return false;

            _listaOsoba.Remove(o);
            return true;
        }

        public bool ObrisiOsobu(String jmbg)
        {
            Osoba tmpOsoba = null;

            foreach (var v in _listaOsoba)
            {
                if (v.Jmbg == jmbg)
                {
                    tmpOsoba = v;
                    break;
                }
            }

            if (tmpOsoba != null)
            {
                _listaOsoba.Remove(tmpOsoba);
                return true;
            }

            return false;
        }

        public bool PostojiOsobaUListi(Osoba o)
        {
            foreach (var v in _listaOsoba)
            {
                if (v.Jmbg == o.Jmbg)
                    return true;
            }

            return false;
        }

        public bool PostojiOsobaUListi(String jmbg)
        {
            foreach (var v in _listaOsoba)
            {
                if (v.Jmbg == jmbg)
                    return true;
            }

            return false;
        }

        public Osoba GetOsoba(String jmbg)
        {
            foreach (var v in _listaOsoba)
            {
                if (v.Jmbg == jmbg)
                    return v;
            }

            return null;
        }

        public void SortListValue()
        {
            if (SortListDelegate != null)
                SortListDelegate(_listaOsoba);
        }

        #endregion


        private static ListaOsoba _instance = null;
        public static ListaOsoba Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ListaOsoba();

                return _instance;
            }
        }
    }
}

