using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork7
{
    public partial class Doubler : Form
    {
        private Random random = new Random();
        private int computerNumber;
        private int userNumber;
        private int userClickCount;
        
        private Stack<int> stack = new Stack<int>();

        public Doubler()
        {
            InitializeComponent();
            
            UpdateGameState(userNumber, userClickCount, GetRandomNumber());
        }

        private int GetRandomNumber()
        {
            int rand = random.Next(50);
            labelTitle.Text = $"Получите число {rand} за минимальное количество попыток!";
            return rand;
        }

        private void UpdateGameState(int userNumber, int userClickCount)
        {
            labelUserNumber.Text = $"Текущее число: {userNumber}";
            labelClickCount.Text = $"Количество кликов: {userClickCount}";
        }

        private void UpdateGameState(int userNumber, int userClickCount, int computerNumber)
        {
            UpdateGameState(userNumber, userClickCount);
            this.computerNumber = computerNumber;
            labelComputerNumber.Text = $"Получите число: {computerNumber}";
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            //userNumber = 0;
            UpdateGameState(userNumber *= 0, userClickCount *= 0, GetRandomNumber());
            stack.Clear();
        }

        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            stack.Push(userNumber);
            UpdateGameState(userNumber *= 2, userClickCount += 1);
            
            CheckWin();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            stack.Push(userNumber);
            UpdateGameState(userNumber += 1, userClickCount += 1);
            
            CheckWin();
        }

        private void CheckWin()
        {
            if (userNumber == computerNumber)
            {
                MessageBox.Show("Вы успешно завершили игру!", "Удвоитель", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                StartNewGame();
            }
            else if (userNumber > computerNumber)
            {
                MessageBox.Show("Вы проиграли!", "Удвоитель", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
                StartNewGame();
            }
        }

        private void StartNewGame()
        {
            if(MessageBox.Show("Желаете сыграть еще раз?", "Удвоитель", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.Yes)
            {
                UpdateGameState(userNumber *= 0, userClickCount *= 0, GetRandomNumber());
            }
            else
            {
                Close();
            }
        }

        private void Doubler_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Start().Show();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            if (userNumber > 0)
            {
                userNumber = stack.Pop();
                UpdateGameState(userNumber, userClickCount -= 1);
            }
        }
    }
}