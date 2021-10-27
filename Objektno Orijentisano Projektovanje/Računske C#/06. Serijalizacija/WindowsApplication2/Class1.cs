using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace WindowsApplication1
{
    /// <summary>
    /// Atribut Serializable omogucuje serijalizaciju klase Student u XML fajl
    /// </summary>
    [Serializable]
    public class Student
    {
        string ime;

        /// <summary>
        /// Svi propertyji koji imaju postavljen i get i set deo ce biti serijalizovani
        /// </summary>
        public string Ime
        {
            get
            {
                return this.ime;
            }
            set
            {
                this.ime = value;
            }
        }

        string prezime;

        public string Prezime
        {
            get
            {
                return this.prezime;
            }
            set
            {
                this.prezime = value;
            }
        }

        int brojIndeksa;

        public int BrojIndeksa
        {
            get
            {
                return this.brojIndeksa;
            }
            set
            {
                this.brojIndeksa = value;
            }
        }

        ArrayList slusaniIspiti = new ArrayList();

        public ArrayList Ispiti
        {
            get
            {
                return this.slusaniIspiti;
            }
            set
            {
                this.slusaniIspiti = value;
            }
        }

        bool redovan;

        public bool Redovan
        {
            get
            {
                return this.redovan;
            }
            set
            {
                this.redovan = value;
            }
        }

        /// <summary>
        /// Metoda koja snima aktivni objekat u specifikovani fajl
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            XmlTextWriter wr = null;
            try
            {
                /// napravi se objekat koji je u stanju da upisuje u fajl
                wr = new XmlTextWriter(fileName, Encoding.Unicode);

                /// kreira se objekat serijalizatora koji moze da serijalizuje 
                /// objekte klase student
                XmlSerializer sr = new XmlSerializer(typeof(Student));
                
                ///poziva se serijalizacija
                sr.Serialize(wr, this);
            }
            catch
            {
            }
            finally
            {
                /// na kraju se writer objekat zatvara
                wr.Close();
            }
        }

        public static Student Load(string fileName)
        {
            StreamReader rd = null;
            try
            {
                /// napravi se objekat koji je u stanju da cita podatke iz fajla
                rd = new StreamReader(fileName, Encoding.Unicode);

                /// kreira se objekat serijalizatora koji moze da deserijalizuje 
                /// objekte klase student
                XmlSerializer sr = new XmlSerializer(typeof(Student));

                ///poziva se deserijalizacija
                Student loadedData = (Student)sr.Deserialize(rd);
                
                /// vraca se restaurirani objekat
                return loadedData;
            }
            catch
            {
                return null;
            }
            finally
            {
                rd.Close();
            }
            
        }
    }
}
