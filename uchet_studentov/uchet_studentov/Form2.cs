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
        bool check_file = true;//Изменить на false когда закончу модуль чтения из документа.
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
            bool FIO = true;
            string name = textBoxName.Text;
            string[] mystring = name.Split(' ');
            if (mystring.Length!=3)
            {
                FIO = false;
            }
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
            else if (!FIO)
            {
                MessageBox.Show("Ошибка! Неправильно заполненно поле ФИО!");
            }
            else
            {
                /*Сохранение студента в файл*/
                string writePath = @"C:\Users\User\Documents\Students\List.txt";//Позже буду использовать локальную папку в которой находится .exe
                Directory.CreateDirectory("C:\\Users\\User\\Documents\\Students");
                /*Собираем данные с textBox-ов и записываем в файл.*/

                string kolz = textBoxKol.Text;
                int kolzad = Convert.ToInt32(kolz);
                string varz = textBoxVar.Text;
                int varzad = Convert.ToInt32(varz);
                if (kolzad < 1)
                {
                    MessageBox.Show("Ошибка! Неккоректное колличество заданий!");

                }
                else if (varzad < 1)
                {
                    MessageBox.Show("Ошибка! Неккоректное колличество вариантов!");
                }
                else
                {
                    name = textBoxName.Text;
                    string group = textBoxGroup.Text;
                    int[] zad = new int[kolzad];
                    for (int i = 0; i < kolzad; i++)
                    {
                        zad[i] = 0;
                    }
                    string text = name + " " + group + " " + kolz + " " + varz;
                    for (int i = 0; i < kolzad; i++)
                    {
                        text += " " + zad[i];
                    }
                    using (StreamWriter sw = new StreamWriter(writePath, true, System.Text.Encoding.Default))
                    {
                        sw.WriteLine(text);
                    }
                }

            }
            Close();
        }
    }
}
