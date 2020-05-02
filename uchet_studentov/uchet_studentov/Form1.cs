using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace uchet_studentov
{
    public partial class Form1 : Form
    {
        string writePath = @"C:\Users\User\Documents\Students\List.txt";//Позже буду использовать локальную папку в которой находится .exe
        void reload_st()
        {
            richTextBox1.Clear();
            Directory.CreateDirectory("C:\\Users\\User\\Documents\\Students");
            using (FileStream fstream = new FileStream(writePath, FileMode.OpenOrCreate))
            {
                byte[] output = new byte[4];
                fstream.Seek(0, SeekOrigin.Begin);
                output = new byte[fstream.Length];
                fstream.Read(output, 0, output.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(output);
                richTextBox1.Text = textFromFile;
            }
        }
        void sort_st()
        {
            string new_text = "";
            using (FileStream fstream = new FileStream(writePath, FileMode.OpenOrCreate))
            {
                byte[] output = new byte[4];
                fstream.Seek(0, SeekOrigin.Begin);
                output = new byte[fstream.Length];
                fstream.Read(output, 0, output.Length);
                // декодируем байты в строку

                string textFromFile = Encoding.Default.GetString(output);
                string[] mystring = textFromFile.Split('\n');
                //Разделил файл на строки, теперь разделим строки на слова.
                int N = mystring.Length - 1;
                //richTextBox2.Text = "" + N;
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
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                string result = new_text.Trim('\r');
                sw.WriteLine(result);
            }
        }
        public Form1()
        {
            InitializeComponent();
            reload_st();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            New_St student = new New_St();
            student.ShowDialog();
            sort_st();
            reload_st();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sort_st();
            reload_st();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Del_St del_student = new Del_St();
            del_student.ShowDialog();
            reload_st();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Add_plus student = new Add_plus();
            student.ShowDialog();
            reload_st();
        }
    }
}
