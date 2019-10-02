using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Udvoitel
{
    public partial class Udvoitel : Form
    {

        public Udvoitel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Рестарт";
            Game.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            Game.Plus();
        }

        private void buttonMult_Click(object sender, EventArgs e)
        {
            Game.Mult();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Game.CancelTurn();
        }
    }
}
