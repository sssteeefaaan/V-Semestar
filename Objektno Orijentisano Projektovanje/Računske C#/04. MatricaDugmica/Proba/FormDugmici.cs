using System;
using System.Drawing;
using System.Windows.Forms;

namespace Proba
{
    public partial class FormDugmici : Form
    {
        public FormDugmici()
        {
            InitializeComponent();

            this.Text = "Dugmici ;)";
        }

        private void InitButtons(int n = 3, int m = 3)
        {
            Button[,] mat = new Button[n, m];

            int X = 10;
            int Y = 10;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mat[i, j] = new Button();
                    mat[i, j].Size = new Size(100, 100);
                    mat[i, j].Name = mat[i, j].Text = $"btn {i}, {j}";
                    mat[i, j].ForeColor = Color.Red;
                    mat[i, j].BackColor = Color.White;

                    mat[i, j].MouseDown += btnXY_MouseDown;

                    mat[i, j].Location = new Point(X, Y);
                    X += 110;
                }
                Y += 110;
                X = 10;
            }

            foreach (var v in mat)
                this.Controls.Add(v);
        }

        private void btnXY_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (e.Button == MouseButtons.Right)
            {
                // btn.Enabled = true;
                btn.Text = btn.Name;
                btn.ForeColor = Color.Red;
            }
            else if (e.Button == MouseButtons.Left)
            {
                //MessageBox.Show($"Kliknuto je na dugme {btn.Name}",
                //              "Obavestenje",
                //              MessageBoxButtons.OK,
                //              MessageBoxIcon.Information);

                //  btn.Enabled = false;
                btn.Text = ":)";
                btn.ForeColor = Color.DarkBlue;
            }

            ActiveControl = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitButtons(5, 6);
            this.Focus();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ActiveControl = null;
        }
    }
}
