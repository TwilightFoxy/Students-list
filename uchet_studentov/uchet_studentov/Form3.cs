using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace uchet_studentov
{
    public partial class Del_Stu : Form
    {
        string writePath = @"C:\Users\User\Documents\Students\List.txt";//Позже буду использовать локальную папку в которой находится .exe
        void save_zone()
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
                char[] charsToTrim = { '\r','\n' };
                string result = text_after_del.Trim(charsToTrim);
                result += '\n';
                sw.WriteLine(result);
            }
        }
        public Del_Stu()
        {
            InitializeComponent();
            save_zone();
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
                    if (mystring[i] != "\r")
                    {
                        string[] words = mystring[i].Split(' ');
                        mass_of_students[z] = words[0] + " " + words[1] + " " + words[2] + " " + words[3];
                        z++;
                        listBox1.Items.Add(mass_of_students[i]);
                    }
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
                    int N = mystring.Length-1;
                    int dolg = 0; ;
                    string[] mass_of_students = new string[N];
                    for (int i = 0; i < N; i++)
                    {
                        mass_of_students[i] = "";
                    }
                    bool prov = false;
                    string[] words = mystring[listBox1.SelectedIndex].Split(' ');
                    dolg = Convert.ToInt32(words[4]);
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
                            prov = false;
                        }
                    }
                    if (prov)
                    {
                        string message = "Вы хотите удалить студента " + words[0] + " " + words[1] + " " + words[2] + " из " + words[3] + " группы? Все задания ВЫПОЛНЕННЫ! Поздравляю студента!";
                        const string caption = "Form Closing";
                        var result = MessageBox.Show(message, caption,
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            //Удаление студента 
                            string substr = mystring[listBox1.SelectedIndex] + "\n";
                            text_after_del = textFromFile.Replace(substr, "");
                        }
                    }
                    else
                    {
                        string message = "Вы хотите удалить студента " + words[0] + " " + words[1] + " " + words[2] + " из " + words[3] + " группы? Ещё не выполненны " + dolg + "/" + words[4] + " заданий!";
                        const string caption = "Form Closing";
                        var result = MessageBox.Show(message, caption,
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string substr = mystring[listBox1.SelectedIndex] + "\n";
                            text_after_del = textFromFile.Replace(substr, "");
                        }
                    }
                }
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    char[] charsToTrim = { '\r' };
                    string result = text_after_del.Trim(charsToTrim);
                    sw.WriteLine(result);
                    Close();
                }
            }
            catch (Exception z)
            {
                Del_Stu student = new Del_Stu();
                student.ShowDialog();
            }
        }
    }
}
