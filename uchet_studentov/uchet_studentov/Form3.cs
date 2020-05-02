﻿using System;
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
    public partial class Del_St : Form
    {
        string writePath = @"C:\Users\User\Documents\Students\List.txt";//Позже буду использовать локальную папку в которой находится .exe

        public Del_St()
        {
            InitializeComponent();

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
                int N = mystring.Length;
                //richTextBox2.Text = "" + N;
                string[] mass_of_students = new string[N];
                for (int i = 0; i < N; i++)
                {
                    mass_of_students[i] = "";
                }
                int z = 0;
                for (int i = 0; i < N; i++)
                {
                    string[] words = mystring[i].Split(' ');
                    mass_of_students[z] = words[0] + " " + words[1] + " " + words[2] + " " + words[3];
                    z++;
                    listBox1.Items.Add(mass_of_students[i]);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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
                int N = mystring.Length;
                int dolg = 0; ;
                string[] mass_of_students = new string[N];
                for (int i = 0; i < N; i++)
                {
                    mass_of_students[i] = "";
                }
                bool prov = false;
                string[] words = mystring[listBox1.SelectedIndex].Split(' ');
                dolg = Convert.ToInt32(words[4]);
                for (int i = 6; i < 6+Convert.ToInt32(words[4]); i++)
                {
                    MessageBox.Show("" + words[i]);
                    if (words[i] == "-1")
                    {
                        dolg--;
                        prov = true;
                    }
                    else if(Convert.ToInt32(words[i]) >= 0)
                    {
                        prov = false;
                    }
                }
                if (prov)
                {
                    MessageBox.Show("Вы хотите удалить студента " + words[0] + " " + words[1] + " " + words[2] + " из " + words[3] + " группы? Все задания ВЫПОЛНЕННЫ! Поздравляю студента!");
                }
                else
                {
                    MessageBox.Show("Вы хотите удалить студента " + words[0] + " " + words[1] + " " + words[2] + " из " + words[3] + " группы? Ещё не выполненны "+ dolg + "/"+ words[4] + " заданий!");
                }
            }
        }
    }
}