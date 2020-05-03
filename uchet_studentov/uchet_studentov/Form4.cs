using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace uchet_studentov
{
    public partial class Add_plus : Form
    {
        string writePath = @"C:\Users\User\Documents\Students\List.txt";//Позже буду использовать локальную папку в которой находится .exe
        public Add_plus()
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
                char[] charsToTrim = { ' ', '\n' };
                textFromFile = textFromFile.Trim(charsToTrim);
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

        }
    }
}
