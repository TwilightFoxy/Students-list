using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace uchet_studentov
{
    public partial class Add_plus : Form
    {
        string writePath = @"C:\Users\User\Documents\Students\List.txt";//Позже буду использовать локальную папку в которой находится .exe
        string new_text = "";
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
                for (int i = 0; i < N && mystring[i]!="\r"; i++)
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
            try
            {
                string text_after_del = "";
                using (FileStream fstream = new FileStream(writePath, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[4];
                    fstream.Seek(0, SeekOrigin.Begin);
                    output = new byte[fstream.Length];
                    fstream.Read(output, 0, output.Length);
                    // декодируем байты в строку
                    string textFromFile = Encoding.Default.GetString(output);
                    text_after_del = textFromFile;
                }
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    char[] charsToTrim = { '\r' };
                    string result = text_after_del.Trim(charsToTrim);
                    sw.WriteLine(result);
                }
                //Стандартная прочистка файла, на всякий случай.
                using (FileStream fstream = new FileStream(writePath, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[4];
                    fstream.Seek(0, SeekOrigin.Begin);
                    output = new byte[fstream.Length];
                    fstream.Read(output, 0, output.Length);
                    // декодируем байты в строку
                    string textFromFile = Encoding.Default.GetString(output);
                    char[] charsToTrim = { '\r' };
                    textFromFile = textFromFile.Trim(charsToTrim);
                    text_after_del = textFromFile;
                    string[] mystring = textFromFile.Split('\n');
                    //Разделил файл на строки, теперь разделим строки на слова.
                    int N = mystring.Length - 1;
                    int dolg = 0;
                    bool prov = false;
                    string[] words = mystring[listBox1.SelectedIndex].Split(' ');
                    dolg = Convert.ToInt32(words[4]);
                    checkedListBox1.Items.Clear();
                    for (int i = 5; i < 5 + Convert.ToInt32(words[4]); i++)
                    {
                        //MessageBox.Show("" + words[i]);
                        if (words[i] == "-1")
                        {
                            dolg--;
                            prov = true;
                        }
                        else if (Convert.ToInt32(words[i]) >= 0)
                        {
                            checkedListBox1.Items.Add(i-5);
                            prov = false;
                        }
                    }
                }
            }
            catch (Exception z)
            {
                Add_plus student = new Add_plus();
                student.ShowDialog();
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string text_after_del = "";
                using (FileStream fstream = new FileStream(writePath, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[4];
                    fstream.Seek(0, SeekOrigin.Begin);
                    output = new byte[fstream.Length];
                    fstream.Read(output, 0, output.Length);
                    // декодируем байты в строку
                    string textFromFile = Encoding.Default.GetString(output);
                    text_after_del = textFromFile;
                }
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    char[] charsToTrim = { '\r' };
                    string result = text_after_del.Trim(charsToTrim);
                    sw.WriteLine(result);
                }
                //Стандартная прочистка файла, на всякий случай.
                using (FileStream fstream = new FileStream(writePath, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[4];
                    fstream.Seek(0, SeekOrigin.Begin);
                    output = new byte[fstream.Length];
                    fstream.Read(output, 0, output.Length);
                    // декодируем байты в строку
                    string textFromFile = Encoding.Default.GetString(output);
                    char[] charsToTrim = { '\r' };
                    textFromFile = textFromFile.Trim(charsToTrim);
                    text_after_del = textFromFile;
                    string[] mystring = textFromFile.Split('\n');
                    //Разделил файл на строки, теперь разделим строки на слова.
                    int N = mystring.Length - 1;
                    int dolg = 0;
                    bool prov = false;
                    string[] words = mystring[listBox1.SelectedIndex].Split(' ');
                    dolg = Convert.ToInt32(words[4]);
                    foreach (object itemChecked in checkedListBox1.CheckedItems)
                    {
                        if (checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(itemChecked)).ToString() == "Checked")
                            words[5 + Convert.ToInt32(itemChecked.ToString())] = "-1";
                        //MessageBox.Show(words[6 + Convert.ToInt32(itemChecked.ToString())]);
                    }
                    new_text = "";
                    for (int i = 0; i <= 4 + dolg; i++)
                    {
                        if (i != 4 + dolg)
                        {
                            new_text += words[i] + " ";
                        }
                        else
                        {
                            new_text += words[i];
                        }
                    }
                }
                using (FileStream fstream = new FileStream(writePath, FileMode.OpenOrCreate))
                {
                    byte[] output = new byte[4];
                    fstream.Seek(0, SeekOrigin.Begin);
                    output = new byte[fstream.Length];
                    fstream.Read(output, 0, output.Length);
                    // декодируем байты в строку
                    string textFromFile = Encoding.Default.GetString(output);
                    char[] charsToTrim = { '\r' };
                    textFromFile = textFromFile.Trim(charsToTrim);
                    text_after_del = "";
                    string[] mystring = textFromFile.Split('\n');
                    mystring[listBox1.SelectedIndex] = new_text;
                    for (int i = 0; i < mystring.Length - 1; i++)
                    {
                        text_after_del += mystring[i]+"\n";
                    }
                    //MessageBox.Show(new_text);
                }
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    char[] charsToTrim = { '\r' };
                    string result = text_after_del.Trim(charsToTrim);
                    sw.WriteLine(result);
                }
                Close();
            }
            catch (Exception z)
            {
                Add_plus student = new Add_plus();
                student.ShowDialog();
            }
        }
    }
}
