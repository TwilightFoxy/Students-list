using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace uchet_studentov
{
    public partial class Add_plus : Form
    {
        Students students = new Students();
        string new_text = "";
        public Add_plus()
        {
            InitializeComponent();
            string textFromFile = students.read_file(students.writePath);
            string[] mystring = textFromFile.Split('\n');
            int N = mystring.Length;
            string[] mass_of_students = new string[N];
            for (int i = 0; i < N; i++)
            {
                mass_of_students[i] = "";
            }
            int z = 0;
            for (int i = 0; i < N-1 && mystring[i] != "\r"; i++)
            {
                string[] words = mystring[i].Split(' ');
                mass_of_students[z] = words[0] + " " + words[1] + " " + words[2] + " " + words[3];
                z++;
                listBox1.Items.Add(mass_of_students[i]);
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string text_after_del = students.read_file(students.writePath);
                students.write_file(students.writePath, text_after_del, false);
                string textFromFile = students.read_file(students.writePath);
                char[] charsToTrim = { '\r' };
                textFromFile = textFromFile.Trim(charsToTrim);
                text_after_del = textFromFile;
                string[] mystring = textFromFile.Split('\n');
                int N = mystring.Length - 1;
                int dolg = 0;
                string[] words = mystring[listBox1.SelectedIndex].Split(' ');
                dolg = Convert.ToInt32(words[4]);
                checkedListBox1.Items.Clear();
                for (int i = 5; i < 5 + Convert.ToInt32(words[4]); i++)
                    if (words[i] == "-1")
                        dolg--;
                    else if (Convert.ToInt32(words[i]) >= 0)
                        checkedListBox1.Items.Add(i - 4);

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
                string text_after_del = students.read_file(students.writePath);
                students.write_file(students.writePath, text_after_del, false);
                string textFromFile = students.read_file(students.writePath);
                char[] charsToTrim = { '\r' };
                textFromFile = textFromFile.Trim(charsToTrim);
                text_after_del = textFromFile;
                string[] mystring = textFromFile.Split('\n');
                int N = mystring.Length - 1;
                int dolg = 0;
                string[] words = mystring[listBox1.SelectedIndex].Split(' ');
                dolg = Convert.ToInt32(words[4]);
                foreach (object itemChecked in checkedListBox1.CheckedItems)
                    if (checkedListBox1.GetItemCheckState(checkedListBox1.Items.IndexOf(itemChecked)).ToString() == "Checked")
                        words[4 + Convert.ToInt32(itemChecked.ToString())] = "-1";
                new_text = "";
                for (int i = 0; i <= 4 + dolg; i++)
                    if (i != 4 + dolg)
                        new_text += words[i] + " ";
                    else
                        new_text += words[i];
                mystring[listBox1.SelectedIndex] = new_text;
                text_after_del = "";
                for (int i = 0; i < mystring.Length - 1; i++)
                {
                    text_after_del += mystring[i] + "\n";
                }
                students.write_file(students.writePath, text_after_del, false);
                Close();
            }
            catch (Exception z)
            {
                Add_plus student = new Add_plus();
                student.ShowDialog();
                Close();
            }
        }
    }
}
