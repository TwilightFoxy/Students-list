using System;
using System.Text;
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
        Students students = new Students();
        private void button_gen_Click(object sender, EventArgs e)
        {
            // Добавление студента
            bool check = true;
            bool FIO = true;
            string name = textBoxName.Text;
            string[] mystring1 = name.Split(' ');
            if (mystring1.Length!=3)
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
            if (textBoxKol.Text == "")
            {
                check = false;
            }
            if (!check)
            {
                MessageBox.Show("Ошибка! Заполните все поля!");
            }
            else if (!FIO)
            {
                MessageBox.Show("Ошибка! Неправильно заполненно поле ФИО!");
            }
            else
            {
                Directory.CreateDirectory(students.dir);

                string kolz = textBoxKol.Text;
                int kolzad = Convert.ToInt32(kolz);
                if (kolzad < 1)
                    MessageBox.Show("Ошибка! Неккоректное колличество заданий!");
                else
                {
                    name = textBoxName.Text;
                    string group = textBoxGroup.Text;
                    int[] zad = new int[kolzad];
                    for (int i = 0; i < kolzad; i++)
                    {
                        zad[i] = 0;
                    }
                    string text = name + " " + group + " " + kolz;
                    for (int i = 0; i < kolzad; i++)
                    {
                        text += " " + zad[i];
                    }
                    students.write_file(students.writePath, text, true);
                    string new_text = text;
                    string textFromFile = students.read_file(students.writePath);
                    textFromFile = textFromFile.Trim('\r');
                    textFromFile = textFromFile.Trim('\n');
                    textFromFile += "\n";
                    string[] mystring = textFromFile.Split('\n');

                    if (text + "\r\n" != textFromFile)
                    {
                        new_text = "";
                        int N = mystring.Length - 1;
                        int[,] mass_of_students = new int[N, N];
                        for (int i = 0; i < N; i++)
                        {
                            mass_of_students[0, i] = 0;
                            mass_of_students[1, i] = i;
                        }
                        int z = 0;
                        for (int i = 0; i < N; i++)
                        {
                            string[] words = mystring[i].Split(' ');
                            mass_of_students[0, z] = Convert.ToInt32(words[3]);
                            z++;
                        }
                        /*Сортировка*/
                        int temp;
                        for (int i = 0; i < N; i++)
                        {
                            for (int j = i + 1; j < N; j++)
                            {
                                if (mass_of_students[0, i] > mass_of_students[0, j])
                                {
                                    temp = mass_of_students[0, i];
                                    mass_of_students[0, i] = mass_of_students[0, j];
                                    mass_of_students[0, j] = temp;
                                    temp = mass_of_students[1, i];
                                    mass_of_students[1, i] = mass_of_students[1, j];
                                    mass_of_students[1, j] = temp;
                                }
                            }
                        }
                        for (int i = 0; i < N; i++)
                        {
                            if (i != N - 1)
                            {
                                new_text += mystring[mass_of_students[1, i]] + '\n';
                            }
                            else
                            {
                                new_text += mystring[mass_of_students[1, i]];
                            }
                        }
                    }
                    students.write_file(students.writePath, new_text, false);
                }
            }
            Close();
        }
    }
}
