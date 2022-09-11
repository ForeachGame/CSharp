using System;
using System.Windows.Forms;

namespace HomeWork7
{
    public partial class DoublerStart : Form
    {
        public DoublerStart()
        {
            InitializeComponent();
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            Hide();
            new Doubler().Show();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Hide();
            new Start().Show();
        }

        private void DoublerStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Start().Show();
        }
    }
}