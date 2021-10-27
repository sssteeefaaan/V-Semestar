using System;
using System.Drawing;
using System.Windows.Forms;

namespace XOX
{
    public partial class FormXOX : Form
    {

        Button[,] _matrica = new Button[3, 3];
        bool igraX = true;

        int pobedeX = 0, pobedeOX = 0;

        void PostaviBrojPobeda(String s)
        {
            if (s == "X")
                pobedeX++;
            else if (s == "O")
                pobedeOX++;

            lblX.Text ="X: " + pobedeX.ToString();
            lblOX.Text = "OX: " + pobedeOX.ToString();
        }

        public FormXOX()
        {
            InitializeComponent();
            Init();
        }

        void Init()
        {
            _matrica[0, 0] = btn00;
            _matrica[0, 1] = btn01;
            _matrica[0, 2] = btn02;
            _matrica[1, 0] = btn10;
            _matrica[1, 1] = btn11;
            _matrica[1, 2] = btn12;
            _matrica[2, 0] = btn20;
            _matrica[2, 1] = btn21;
            _matrica[2, 2] = btn22;

            foreach (var b in _matrica)
            {
                b.Text = "";
                b.Click += KadSeKlikneNaPolje;
                b.BackColor = Color.White;
            }

            lblIgrac.Text = "Igra igrac: " + (igraX == true ? "X" : "O");
            lblIgrac.Focus();

        }

        void KadSeKlikneNaPolje(object sender, EventArgs e)
        {
            lblIgrac.Focus();

            Button b = (Button)sender;

            if (igraX)
                b.Text = "X";
            else
                b.Text = "O";

            b.Enabled = false;

            ProveraPobede();

            igraX = !igraX;
            lblIgrac.Text = "Igra igrac: " + (igraX == true ? "X" : "O");
        }


        void Reset()
        {
            foreach (var b in _matrica)
            {
                b.Text = "";
                b.Enabled = true;
                b.BackColor = Color.White;
            }

            igraX = true;
            lblIgrac.Text = "Igra igrac: " + (igraX == true ? "X" : "O");
        }


        void ProveraPobede()
        {
            if (btn00.Text != "" && btn00.Text == btn11.Text && btn00.Text == btn22.Text)
            {
                btn00.BackColor = btn11.BackColor = btn22.BackColor = Color.Red;

                foreach (var b in _matrica)
                    b.Enabled = false;

                MessageBox.Show("Pobedio je igrac: " + btn00.Text);
                PostaviBrojPobeda(btn00.Text);
            }

            if (btn02.Text != "" && btn02.Text == btn11.Text && btn02.Text == btn20.Text)
            {
                btn02.BackColor = btn11.BackColor = btn20.BackColor = Color.Red;

                foreach (var b in _matrica)
                    b.Enabled = false;

                MessageBox.Show("Pobedio je igrac: " + btn02.Text);

                PostaviBrojPobeda(btn02.Text);
            }

            for (int i = 0; i < 3; i++)
            {
                if (_matrica[i, 0].Text != "" && _matrica[i, 0].Text == _matrica[i, 1].Text && _matrica[i, 0].Text == _matrica[i, 2].Text)
                {
                    _matrica[i, 0].BackColor = _matrica[i, 1].BackColor = _matrica[i, 2].BackColor = Color.Red;

                    foreach (var b in _matrica)
                        b.Enabled = false;

                    MessageBox.Show("Pobedio je igrac: " + _matrica[i, 0].Text);

                    PostaviBrojPobeda(_matrica[i, 0].Text);

                    return;
                }

                if (_matrica[0, i].Text != "" && _matrica[0, i].Text == _matrica[1, i].Text && _matrica[0, i].Text == _matrica[2, i].Text)
                {
                    _matrica[0, i].BackColor = _matrica[1, i].BackColor = _matrica[2, i].BackColor = Color.Red;

                    foreach (var b in _matrica)
                        b.Enabled = false;

                    MessageBox.Show("Pobedio je igrac: " + _matrica[0, i].Text);


                    PostaviBrojPobeda(_matrica[0, i].Text);

                    return;
                }
            }
        }

        private void btnPokreniPonovo_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void FormXOX_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }      
    }
}
