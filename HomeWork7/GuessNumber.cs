using System;
using System.Windows.Forms;

/*
 * 2. Используя Windows Forms, разработать игру «Угадай число».
 * Компьютер загадывает число от 1 до 100, а человек пытается его угадать за минимальное число попыток.
 * Компьютер говорит, больше или меньше загаданное число введенного.
 * a) Для ввода данных от человека используется элемент TextBox;
 * б)**Реализовать отдельную форму c TextBox для ввода числа.
 *
 * 
 */
namespace HomeWork7
{
    public partial class GuessNumber : Form
    {
        private readonly Random _random = new Random();
        private int _computerNumber;
        private int _userNumber;
        private int _userCheckCount;
        
        public GuessNumber()
        {
            InitializeComponent();
            ChangeComputerNumber();
        }

        private void ChangeComputerNumber()
        {
            _computerNumber = _random.Next(100);
        }

        private void ChangeUserNumber(int userNumber)
        {
            _userNumber = userNumber;
        }

        private void ChangeUserCheckCount(int number)
        {
            _userCheckCount = number;
            labelCount.Text = $"Количество попыток: {_userCheckCount}";
        }


        private void buttonCheckNumber_Click(object sender, EventArgs e)
        {
            CheckValue();
        }

        private void CheckValue()
        {
            if (int.TryParse(textBoxNumber.Text, out int number))
            {
                ChangeUserNumber(number);
                ChangeUserCheckCount(_userCheckCount += 1);
                Check();
            }
            else
            {
                MessageBox.Show("Вы ввели некорректное число!", "Угадай число",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Check()
        {
            if (_computerNumber < _userNumber)
            {
                labelResult.Text = $"Меньше";
                textBoxNumber.Text = "";
            } else if (_computerNumber > _userNumber)
            {
                labelResult.Text = $"Больше";
                textBoxNumber.Text = "";
            }
            else
            {
                MessageBox.Show("Вы отгадали число!!!", "Угадай число",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                StartNewGame();
            }
        }
        
        private void StartNewGame()
        {
            if(MessageBox.Show("Желаете сыграть еще раз?", "Угадай число", MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ChangeComputerNumber();
                ChangeUserNumber(0);
                ChangeUserCheckCount(0);
                labelResult.Text = "";
                textBoxNumber.Text = "";
            }
            else
            {
                Close();
            }
        }

        private void GuessNumber_FormClosing(object sender, FormClosingEventArgs e)
        {
            new Start().Show();
        }

        private void textBoxNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CheckValue();
            }
        }
    }
}