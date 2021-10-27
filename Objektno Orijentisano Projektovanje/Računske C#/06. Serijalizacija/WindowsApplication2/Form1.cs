using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Podrayumevani konstruktor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Objekat klase student koji cuva podatke koji se prikazuju u formi
        /// Ovde se moze videti inicijalizacija mimo konstruktora.
        /// Ove inicijalizacije se ponasaju kao da su deo podrazumevanog konstruktora
        /// </summary>
        Student student = new Student();

        /// <summary>
        /// Klik na dugme za dodavanje novog elementa u niz ispita
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            /// Pravimo instancu forme za definisanje imena ispita
            Form2 f2 = new Form2();
            if (f2.ShowDialog() == DialogResult.OK && f2.textBox1.Text.Trim() != "")
            {
                /// ako je u tekst boksu forme f2 definisano ime predmeta
                /// i ako je kliknuto na dugme OK, onda se novi predmet doda u listu
                student.Ispiti.Add(f2.textBox1.Text);                
            }
            
            f2.Close();

            /// Poziva se metoda koja u interfejsu prikazuje sadrzaj objekta this.student 
            ShowData();
        }

        /// <summary>
        /// Metoda za prikazivanje sadrzaja objekta this.student
        /// </summary>
        public void ShowData()
        {
            this.textBox1.Text = student.Ime;
            this.textBox2.Text = student.Prezime;
            this.textBox3.Text = student.BrojIndeksa.ToString();
            this.checkBox1.Checked = student.Redovan;
            this.listBox1.Items.Clear();
            this.listBox1.Items.AddRange(student.Ispiti.ToArray());

        }

        /// <summary>
        /// Metoda za obradu dogadjaja menjanje teksta u tekst boksu 
        /// i taj tekst dodeljuje u this.student.Ime
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.student.Ime = this.textBox1.Text;
        }

        /// <summary>
        /// Metoda za obradu dogadjaja menjanje teksta u tekst boksu 
        /// i taj tekst dodeljuje u this.student.Prezime
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.student.Prezime = this.textBox2.Text;
        }

        /// <summary>
        /// Metoda za obradu dogadjaja menjanje teksta u tekst boksu 
        /// i taj tekst dodeljuje u this.student.BrojIndeksa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.student.BrojIndeksa = Convert.ToInt32(this.textBox3.Text);
            }
            catch
            {
                this.student.BrojIndeksa = 0;
            }
        }

        /// <summary>
        /// Metoda za obradu dogadjaja menjanje stanja check boksa 
        /// i vrednost propertyja checked dodeljuje u this.student.BrojIndeksa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.student.Redovan = this.checkBox1.Checked;
        }

        /// <summary>
        /// Metoda koja izbacuje odabrani item iz list boksa iz niza ispita
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (this.listBox1.SelectedItems.Count > 0)
            {
                string odabranIspit = this.listBox1.SelectedItem.ToString();
                this.student.Ispiti.Remove(odabranIspit);
                ShowData();
            }
        }

        /// <summary>
        /// Klik na opciju "exit" u meniju
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// zatvara formu i gasi aplikaciju
            this.Close();
        }

        /// <summary>
        /// Klik na opciju "new" u meniju
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            /// kreira se novi, prazni objekat klase Student
            this.student = new Student();

            /// Poziva se metoda koja u interfejsu prikazuje sadrzaj objekta this.student
            ShowData();
        }

        /// <summary>
        /// Klik na opciju "open" iz menija
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// Kreiramo novi dijalog za otvaranje fajlova
            OpenFileDialog ofd = new OpenFileDialog();
            
            /// sa ShowDialog otvaramo novi dijalog i u njemu odaberemo fajl koji otvaramo
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                /// ako je odabran fajl i kliknuto na "OK", program ce probati
                /// da ucita objekat iz odabranog fajla
                this.student = Student.Load(ofd.FileName);

                /// ucitani objekat ce biti prikazan
                ShowData();
            }
        }

        /// <summary>
        /// Klik na opciju "save" u meniju
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// Kreiramo novi dijalog za snimanje fajlova
            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                /// ako je odabran fajl i kliknuto na "OK", program ce probati
                /// da snimi objekat u odabrani fajl
                this.student.Save(sfd.FileName);
            }
        }

        
    }
}