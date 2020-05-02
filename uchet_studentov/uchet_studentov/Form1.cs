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

        public Form1()
        {
            InitializeComponent();
           // string writePath = @"C:\Users\User\Documents\Students\List.txt";//Позже буду использовать локальную папку в которой находится .exe
            Directory.CreateDirectory("C:\\Users\\User\\Documents\\Students");

            richTextBox1.Clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            New_St student = new New_St();
            student.ShowDialog();
            richTextBox1.Clear();

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

        private void button2_Click(object sender, EventArgs e)
        {
            string writePath = @"C:\Users\User\Documents\Students\List.txt";//Позже буду использовать локальную папку в которой находится .exe
            Directory.CreateDirectory("C:\\Users\\User\\Documents\\Students");

            richTextBox1.Clear();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Del_St del_student = new Del_St();
            del_student.ShowDialog();
            richTextBox1.Clear();
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
    }
}
