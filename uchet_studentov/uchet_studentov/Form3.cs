using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace uchet_studentov
{
    public partial class Del_Stu : Form
    {
        Students students = new Students();
        public Del_Stu()
        {
            InitializeComponent();
            string connStr = "server=localhost;user=root;database=Students;password=0000;";
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string sql = "SELECT `FIO`, `Group` FROM `students`";
            MySqlCommand command = new MySqlCommand(sql, conn);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString() + " " + reader[1].ToString());
            }
            reader.Close();
            conn.Close();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string connStr = "server=localhost;user=root;database=Students;password=0000;";
                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string sql = "SELECT `ID`, `FIO`, `Group` FROM `students`";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (Convert.ToInt32(reader[0].ToString()) == listBox1.SelectedIndex + 1)
                    {
                        string message = "Вы хотите удалить студента " + reader[1] + " из " + reader[2] + " группы?";
                        var result = MessageBox.Show(message, "Удаление",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string delet = "DELETE FROM `students` WHERE ID = "+ reader[0];
                            command = new MySqlCommand(delet, conn);
                        }
                    }
                }
                reader.Close();
                command.ExecuteNonQuery();
                conn.Close();
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
