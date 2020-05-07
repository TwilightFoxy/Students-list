using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace uchet_studentov
{
    public class Students
    {
        public string writePath = @"C:\Users\User\Documents\Students\List.txt";//Позже буду использовать локальную папку в которой находится .exe
        public string dir = "C:\\Users\\User\\Documents\\Students";
        public string read_file(string writePath)
        {
            string textFromFile = "";
            using (FileStream fstream = new FileStream(writePath, FileMode.OpenOrCreate))
            {
                byte[] output = new byte[4];
                fstream.Seek(0, SeekOrigin.Begin);
                output = new byte[fstream.Length];
                fstream.Read(output, 0, output.Length);
                textFromFile = Encoding.Default.GetString(output);
            }
            return textFromFile;
        }
        public void write_file(string writePath, string text, bool save)
        {
            using (StreamWriter sw = new StreamWriter(writePath, save, System.Text.Encoding.Default))
            {
                string result = text.Trim('\r', '\n');
                sw.WriteLine(result);
            }
        }
        //Чтение файла по пути, возвращает строкой.
        public void reload_st(RichTextBox richTextBox1)
        {
            richTextBox1.Clear();
            Directory.CreateDirectory(dir);
            richTextBox1.Text = read_file(writePath);
        }
        //Отчистить и перезаписать данные с файла
        public void fix_st(string writePath)
        {
            string new_text = read_file(writePath);
            write_file(writePath, new_text, false);
        }
        //Удаление лишних пробелов и пустых строк
        public void check_st(string writePath)
        {
            string new_str = "", new_str_not = "";
            bool main_prov = false;
            string textFromFile = read_file(writePath);
            if (textFromFile != "")
            {
                char[] charsToTrim = { ' ', '\n' };
                textFromFile = textFromFile.Trim(charsToTrim);
                string[] mystring = textFromFile.Split('\n');
                //Разделил файл на строки, теперь разделим строки на слова.
                int N = mystring.Length;
                string[] mass_of_nums = new string[N + 10];
                for (int i = 0; i < N; i++)
                    mass_of_nums[i] = "";
                int[] new_list = new int[N];
                for (int i = 0; i < N && mystring[i] != "\r"; i++)
                {
                    bool cheker = true;
                    string[] words = mystring[i].Split(' ');
                    for (int j = 5; j < 6 + Convert.ToInt32(words[5]); j++)
                        if (words[j] != "-1")
                            cheker = false;
                    if (cheker)
                        new_list[i] = 1;
                    else
                        new_list[i] = 0;
                }
                new_str = "";
                new_str_not = "";
                for (int w = 0; w < N; w++)
                    if (new_list[w] == 1)
                        if (w != N - 1)
                            new_str += mystring[w] + "\n";
                        else
                            new_str += mystring[w];
                    else
                        if (w != N - 1)
                        new_str_not += mystring[w] + "\n";
                    else
                        new_str_not += mystring[w];
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
                        main_prov = true;
                }
            }
            if (main_prov)
                write_file(writePath, new_str_not, false);
        }
        //Проверка на наличие студентов, выполнивших все задания
        public void standart_obr(string writePath, RichTextBox richTextBox1)
        {
            fix_st(writePath);
            reload_st(richTextBox1);
            check_st(writePath);
            reload_st(richTextBox1);
        }
        //Обновление, проверка и перезапись с файла в RichTextBox
    }
}
