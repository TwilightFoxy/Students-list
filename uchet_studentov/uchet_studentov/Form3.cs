using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace uchet_studentov
{
    public partial class Del_Stu : Form
    {
        Students students = new Students();
        public Del_Stu()
        {
            InitializeComponent();

            string text_after_del = "";
            text_after_del = students.read_file(students.writePath);
            students.write_file(students.writePath, text_after_del, false);
            string textFromFile = students.read_file(students.writePath);
            char[] charsToTrim = { ' ', '\n' };
            textFromFile = textFromFile.Trim(charsToTrim);
            string[] mystring = textFromFile.Split('\n');
            int N = mystring.Length;
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
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string text_after_del = students.read_file(students.writePath);
                students.write_file(students.writePath, text_after_del, false);
                string textFromFile = students.read_file(students.writePath);
                text_after_del = textFromFile;
                string[] mystring = textFromFile.Split('\n');
                int N = mystring.Length - 1;
                int dolg = 0; ;
                string[] mass_of_students = new string[N];
                for (int i = 0; i < N; i++)
                    mass_of_students[i] = "";
                bool prov = false;
                string[] words = mystring[listBox1.SelectedIndex].Split(' ');
                dolg = Convert.ToInt32(words[4]);
                for (int i = 5; i < 5 + Convert.ToInt32(words[4]); i++)
                    if (words[i] == "-1")
                    {
                        dolg--;
                        prov = true;
                    }
                    else if (Convert.ToInt32(words[i]) >= 0)
                        prov = false;
                bool lastprov = false;
                string message = "";
                const string caption = "Удаление";
                if (prov)
                {
                    message = "Вы хотите удалить студента " + words[0] + " " + words[1] + " " + words[2] + " из " + words[3] + " группы? Все задания ВЫПОЛНЕННЫ! Поздравляю студента!";
                    lastprov = true;
                }
                else 
                {
                    message = "Вы хотите удалить студента " + words[0] + " " + words[1] + " " + words[2] + " из " + words[3] + " группы? Ещё не выполненны " + dolg + "/" + words[4] + " заданий!";
                    lastprov = true;
                }
                if (lastprov)
                {
                    var result = MessageBox.Show(message, caption,
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string substr = mystring[listBox1.SelectedIndex] + "\n";
                        text_after_del = textFromFile.Replace(substr, "");
                    }
                }
                students.write_file(students.writePath, text_after_del, false);
                Close();
            }
            catch (Exception z)
            {
                Del_Stu student = new Del_Stu();
                student.ShowDialog();
            }
        }
    }
}
