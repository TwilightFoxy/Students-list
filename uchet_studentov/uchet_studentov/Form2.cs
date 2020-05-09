using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace uchet_studentov
{
    public partial class New_St : Form
    {
        public New_St()
        {
            InitializeComponent();
        }
        Students students = new Students();
        private void button_gen_Click(object sender, EventArgs e)
        {
            // Добавление студента
            bool check = true;
            bool FIO = true;
            string name = textBoxName.Text;
            string[] mystring1 = name.Split(' ');
            if (mystring1.Length!=3)
            {
                FIO = false;
            }
            if (textBoxName.Text == "")
            {
                FIO = false;
            }
            if (textBoxGroup.Text == "")
            {
                check = false;
            }
            if (!check)
            {
                MessageBox.Show("Ошибка! Неправильно заполненно поле группы!");
            }
            else if (!FIO)
            {
                MessageBox.Show("Ошибка! Неправильно заполненно поле ФИО!");
            }
            else
            {
                string connectionString = "server=localhost;user=root;database=Students;password=0000;";
                MySqlConnection connection = new MySqlConnection(connectionString); 
                connection.Open();
                string newID = "SELECT MAX(`ID`) FROM `students`"; 
                MySqlCommand cmd = new MySqlCommand(newID, connection);
                int lastID = Convert.ToInt32(cmd.ExecuteScalar());
                string query = "INSERT INTO `students` (`ID`, `FIO`, `Group`) VALUES ('"+ (lastID+1) + "', '"+name+"', '"+ textBoxGroup.Text + "')";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
            Close();
        }
    }
}
