using System;
using System.Windows.Forms;

namespace HomeWork7
{
    public partial class GuessNumberStart : Form
    {
        public GuessNumberStart()
        {
            InitializeComponent();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            Hide();
            new GuessNumber().Show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Hide();
            new Start().Show();
        }

        private void GuessNumberStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Start().Show();
        }
    }
}