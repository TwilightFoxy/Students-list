using System;
using System.Text;
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
        void fix_st()
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
                new_text = textFromFile;
            }
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                string result = new_text.Trim('\r', '\n');
                sw.WriteLine(result);
            }
        }
        void check_st()
        {
            string new_str = "", new_str_not = "";
            bool main_prov = false;
            using (FileStream fstream = new FileStream(writePath, FileMode.OpenOrCreate))
            {
                byte[] output = new byte[4];
                fstream.Seek(0, SeekOrigin.Begin);
                output = new byte[fstream.Length];
                fstream.Read(output, 0, output.Length);
                // декодируем байты в строку
                string textFromFile = Encoding.Default.GetString(output);
                if (textFromFile != "") 
                {
                    char[] charsToTrim = { ' ', '\n' };
                    textFromFile = textFromFile.Trim(charsToTrim);
                    string[] mystring = textFromFile.Split('\n');
                    //Разделил файл на строки, теперь разделим строки на слова.
                    int N = mystring.Length;
                    //richTextBox2.Text = "" + N;
                    string[] mass_of_nums = new string[N + 10];
                    for (int i = 0; i < N; i++)
                    {
                        mass_of_nums[i] = "";
                    }
                    int z = 0;
                    int[] new_list = new int[N];
                    bool prov = false;
                    for (int i = 0; i < N && mystring[i] != "\r"; i++)
                    {
                        bool cheker = true;
                        string[] words = mystring[i].Split(' ');
                        for (int j = 5; j < 5 + Convert.ToInt32(words[4]); j++)
                        {
                            mass_of_nums[j - 5] = words[j];
                        }
                        for (int q = 0; q < N; q++)
                        {
                            if (mass_of_nums[q] != "-1")
                                cheker = false;
                        }
                        if (cheker)
                        {
                            new_list[i] = 1;
                            prov = true;
                        }
                        else
                        {
                            new_list[i] = 0;
                        }
                    }
                    new_str = "";
                    new_str_not = "";
                    for (int w = 0; w < N; w++)
                    {
                        if (new_list[w] == 1)
                        {
                            if (w != N - 1)
                            {
                                new_str += mystring[w] + "\n";
                            }
                            else
                            {
                                new_str += mystring[w];
                            }
                        }
                        else
                        {
                            if (w != N - 1)
                            {
                                new_str_not += mystring[w] + "\n";
                            }
                            else
                            {
                                new_str_not += mystring[w];
                            }
                        }
                    }
                    // new_str - Студенты, которые сдали всё.
                    // new_str_not - Студенты, которые ещё не сдали.
                    //MessageBox.Show(new_str);
                    //MessageBox.Show(new_str_not);
                    if (new_str != "")
                    {
                        string message = "Студенты:\n";
                        string[] win_st = new_str.Split('\n');
                        for (int i = 0; i < win_st.Length; i++)
                        {
                            string[] words = win_st[i].Split(' ');
                            message += words[0] + "\n";
                        }
                        message += "Успешно завершили все задания!\nХотитие удалить их из списка должников?";
                        const string caption = "Ура!";
                        var result = MessageBox.Show(message, caption,
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            main_prov = true;
                        }
                    }
                }
                
            }
            if (main_prov)
            {
                using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
                {
                    char[] charsToTrim = { '\r' };
                    string result = new_str_not.Trim(charsToTrim);
                    sw.WriteLine(result);
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
            reload_st();
            check_st();
            reload_st();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            fix_st();
            New_St student = new New_St();
            student.ShowDialog();
            fix_st();
            reload_st();
            check_st();
            reload_st();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            fix_st();
            reload_st();
            check_st();
            reload_st();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            fix_st();
            Del_Stu student = new Del_Stu();
            student.ShowDialog();
            fix_st();
            reload_st();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            fix_st();
            Add_plus student = new Add_plus();
            student.ShowDialog();
            fix_st();
            reload_st();
            check_st();
            reload_st();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fix_st();
            New_Doc st = new New_Doc();
            st.ShowDialog();
            fix_st();
            reload_st();
            check_st();
            reload_st();
        }
    }
}
