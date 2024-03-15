using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zoomir
{
    public partial class avtotiz : Form
    {
        public avtotiz()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;
            string connectionString = "Host=localhost;Username=postgres;Password=1111;Database=зоо";

            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT COUNT(*) FROM пользователи WHERE логин = @логин AND пароль = @пароль";

                    using (NpgsqlCommand command = new NpgsqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@логин", login);
                        command.Parameters.AddWithValue("@пароль", password);

                        int userCount = Convert.ToInt32(command.ExecuteScalar());

                        if (userCount > 0)
                        {
                            // Успешная авторизация
                            MessageBox.Show("Авторизация успешна!");

                            // Здесь вы можете выполнить дополнительные действия после успешной авторизации

                            // Пример: Открыть главное окно вашего приложения
                            Form1 form1 = new Form1();
                            form1.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Неверные логин или пароль
                            MessageBox.Show("Неверные логин или пароль!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void auth_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
