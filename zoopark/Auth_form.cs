using Microsoft.VisualBasic.Logging;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using zoopark;

namespace document_oborot
{
    public partial class Auth_form : Form
    {
        public Auth_form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string login = textBox1.Text;
            string password = textBox2.Text;
            if (string.IsNullOrEmpty(login))
            {
                MessageBox.Show("Поле логина пустое!");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Поле пароля пустое!");
                return;
            }
            DB dB = new DB();
            using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter($"SELECT * from users WHERE login = @login", dB.GetConn()))
            {
                dataAdapter.SelectCommand.Parameters.AddWithValue("@login", login);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    if (check_password(password) == true)
                    {


                        Check_role(login, password);
                       
                    }
                    else
                    {
                        
                        
                        MessageBox.Show("Неправильный пароль!");
                    }

                }
                else
                {
                    MessageBox.Show("Пользователя не существует!");
                }




            }
        }
        private bool check_password(string password)
        {
            DB db = new DB();

            using (NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter($"SELECT * from users WHERE password = @pass", db.GetConn() ))
            {
                dataAdapter.SelectCommand.Parameters.AddWithValue("@pass", password);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
        private void Check_role(string login, string password)
        {
            DB db = new DB();
            db.GetConn().Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT id FROM users WHERE login = @login and password = @pass", db.GetConn()))
                {
                    cmd.Parameters.Add("@login", NpgsqlDbType.Text).Value = login;
                    cmd.Parameters.Add("@pass", NpgsqlDbType.Text).Value = password;
                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int u_id = reader.GetInt32(reader.GetOrdinal("id"));

                        Catalog_form form = new Catalog_form(u_id);
                        this.Hide();
                        form.Show();
                            
                        }
                    }

                

            }


        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }


        private void Auth_form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}