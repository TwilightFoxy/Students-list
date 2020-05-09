using System;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace uchet_studentov
{
    public partial class Form1 : Form
    {
        Students students = new Students();
        public Form1()
        {
            InitializeComponent();
            students.reload_st(listBox1);
            //students.check_st(students.writePath); 
            //students.reload_st(listBox1);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            New_St new_student = new New_St();
            new_student.ShowDialog();
            students.standart_obr(students.writePath, listBox1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            students.standart_obr(students.writePath, listBox1);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Del_Stu del_student = new Del_Stu();
            del_student.ShowDialog();
            students.standart_obr(students.writePath, listBox1);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Add_plus add_pl = new Add_plus();
            add_pl.ShowDialog();
            students.standart_obr(students.writePath, listBox1);
        }
        private void button5_Click(object sender, EventArgs e)
        {
            New_Doc st = new New_Doc();
            st.ShowDialog();
            students.standart_obr(students.writePath, listBox1);
        }
    }
}
