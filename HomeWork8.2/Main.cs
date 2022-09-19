using System;
using System.Windows.Forms;

namespace HomeWork8._2
{
    public partial class Main : Form
    {

        TrueFalseEngine engine;
        
        public Main()
        {
            InitializeComponent();
            // Отключаем возможность работы файла
            tbQuestion.Enabled = false; 
            nudNumber.Enabled = false;
            btnAdd.Enabled = false;
            btnDelete.Enabled = false;
            cbTrue.Enabled = false;
        }

        public void ToggleActive()
        {
            tbQuestion.Enabled = !tbQuestion.Enabled; 
            nudNumber.Enabled = !nudNumber.Enabled;
            btnAdd.Enabled = !btnAdd.Enabled;
            btnDelete.Enabled = !btnDelete.Enabled;
            cbTrue.Enabled = !cbTrue.Enabled;
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                engine = new TrueFalseEngine(dlg.FileName);
                engine.Add("Замля круглая?", true);
                engine.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
                if (engine.isFile()) ToggleActive();// Проверяем есть ли вопросы в файле
            }
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            tbQuestion.Text = engine[(int)nudNumber.Value - 1].Text;
            cbTrue.Checked = engine[(int)nudNumber.Value - 1].TrueFalse;
        }

        private void menuItemOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                engine = new TrueFalseEngine(dlg.FileName);
                engine.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = engine.Count;
                nudNumber.Value = 1;
                if (engine.isFile()) ToggleActive();// Проверяем есть ли вопросы в файле
            }
        }

        private void menuItemSave_Click(object sender, EventArgs e)
        {
            engine.Save();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            engine.Add($"#{engine.Count + 1}", true);
            nudNumber.Maximum = engine.Count;
            nudNumber.Value = engine.Count;
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (engine.Count > 1) // Нельзя удалить последний оставшийся вопрос
            {
                
                engine.Remove((int) nudNumber.Value - 1); 
                if(nudNumber.Value > 1) nudNumber.Value--; // Фикс ошибки при удалении первого элемента
                nudNumber.Maximum--;
                nudNumber_ValueChanged(sender, e);
            }
            else
            {
                MessageBox.Show("Нельзя удалить последний вопрос", "Ошибка", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            
        }

        private void tbQuestion_TextChanged(object sender, EventArgs e) // Сохранение вопроса при вводе в тектовое поле
        {
            engine[(int)nudNumber.Value - 1].Text = tbQuestion.Text;
        }

        private void toolAbout_Click(object sender, EventArgs e) // Информация о программе
        {
            MessageBox.Show("Автор: Станислав Байраковский\n" +
                            "Ред.: Александр Черемисинов\n" +
                            "Версия: 0.0.1\n" +
                            "Авторские права: Есть",
                "О программе", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
