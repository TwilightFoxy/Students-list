using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace uchet_studentov
{
    public partial class New_St : Form
    {
        public New_St()
        {
            InitializeComponent();
        }
        bool check_file = false;
        private void open_button_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK) 
            {
                // Обработка входного файла будет здесь.
                check_file = true;
                open_button.Text = "Файл добавлен";
            }
        }

        private void button_gen_Click(object sender, EventArgs e)
        {
            // Добавление студента
            bool check = true;
            if (textBoxName.Text == "")
            {
                check = false;
            }
            if (textBoxGroup.Text == "")
            {
                check = false;
            }
            if (check_file == false)
            {
                check = false;
            }
            if (textBoxKol.Text == "")
            {
                check = false;
            }
            if (textBoxVar.Text == "")
            {
                check = false;
            }
            if (!check)
            {
                MessageBox.Show("Ошибка! Заполните все поля и добавьте файл!");

            }
            else
            {
                /*Сохранение студента в файл*/
                string writePath = @"C:\Users\User\Documents\Students\List.txt";
                Directory.CreateDirectory("C:\\Users\\User\\Documents\\Students");
                //FileStream fs = File.Create(writePath);
                //fs.Close();
                string text = "Привет мир!\nПока мир...";
                using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                {
                    sw.WriteLine(text);
                }
            }
            Close();
        }
    }
}
