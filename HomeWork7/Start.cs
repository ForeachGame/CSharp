using System;
using System.Windows.Forms;

namespace HomeWork7
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void buttonDoublerStart_Click(object sender, EventArgs e)
        {
            Hide();
            new DoublerStart().Show();
        }

        private void buttonGuessStart_Click(object sender, EventArgs e)
        {
            Hide();
            new GuessNumberStart().Show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}