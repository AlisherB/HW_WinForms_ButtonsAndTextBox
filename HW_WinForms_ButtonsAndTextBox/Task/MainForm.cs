using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task
{
    public partial class MainForm : Form
    {
        private Point padding = new Point();
        private Point formSize = new Point();
        private bool ctrlPressed = false;

        public MainForm()
        {
            InitializeComponent();
            padding.X = 10;
            padding.Y = 10;
            formSize.X = 0;
            formSize.Y = 0;
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (ctrlPressed)
                    Close();
                else
                    Position(e);
            }
            else
            {
                formSize.X = ClientSize.Width;
                formSize.Y = ClientSize.Height;
            }
        }

        private void Position(MouseEventArgs e)
        {
            if ((e.X < padding.X) || (e.X > ClientSize.Width - padding.X) ||
                (e.Y < padding.Y) || (e.Y > ClientSize.Height - padding.Y))
                MessageBox.Show("Вы вне прямоугольника");
            else if ((e.X < padding.X + padding.X) || (e.X > ((ClientSize.Width - padding.X) - padding.X)) ||
                    (e.Y < padding.Y + padding.Y) || (e.Y > ((ClientSize.Height - padding.Y) - padding.Y)))
                MessageBox.Show("Вы на границе прямоугольника");
            else
                MessageBox.Show("Вы внутри прямоугольника");
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            ctrlPressed = e.Control;
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            Text = "Ширина = " + formSize.X + ";" + " Высота = " + formSize.Y + ";" + " Текущие координаты = " + e.X.ToString() + "; " + e.Y.ToString();
        }
    }
}
