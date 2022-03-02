using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SAA_Project_Sem_2
{
    public partial class FormLogin : System.Windows.Forms.Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }
        MySqlConnection sqlConnect;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        string sqlQuery;
        string connectString = "server=localhost;uid=root;pwd=;database=loketdotcom;";
        bool Username = false;
        bool Password = false;
        public static string simpanUser = "";
        public static string simpanNama = "";

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            if (Username == true && Password == true)
            {
                DataTable User = new DataTable();
                sqlConnect = new MySqlConnection(connectString);
                sqlQuery = "SELECT * FROM pengguna WHERE USERNAME = '"+tboxUsername.Text+"'";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(User);
                simpanNama = User.Rows[0]["Nama"].ToString();
                simpanUser = tboxUsername.Text;
                this.Hide();
                FormHome fh = new FormHome();
                fh.Show();
            }
            else
            {
                MessageBox.Show("Username/Password Salah");
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSignUp fsu = new FormSignUp();
            fsu.Show();
        }

       

        private void tboxUsername_TextChanged(object sender, EventArgs e)
        {
            Username = false;
            DataTable Pengguna = new DataTable();
            sqlConnect = new MySqlConnection(connectString);
            sqlQuery = "SELECT * FROM pengguna";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(Pengguna);
            for (int i = 0; i <= Pengguna.Rows.Count - 1; i++)
            {
                if (tboxUsername.Text == Pengguna.Rows[i]["USERNAME"].ToString())
                {
                    Username = true;
                }
            }
            tboxPassword_TextChanged(sender, e);

        }

        private void tboxPassword_TextChanged(object sender, EventArgs e)
        {
            Password = false;
            if (Username == true)
            {
                DataTable Pengguna = new DataTable();
                sqlConnect = new MySqlConnection(connectString);
                sqlQuery = "SELECT * FROM pengguna WHERE USERNAME = '" + tboxUsername.Text + "'";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(Pengguna);

                if (tboxPassword.Text == Pengguna.Rows[0]["PASSWORD"].ToString())
                {
                    Password = true;
                }
            }
        }

        private void FormLogin_Load_1(object sender, EventArgs e)
        {
            
            tboxPassword.PasswordChar = '*';
        }

        private void panelTatakan_Paint(object sender, PaintEventArgs e)
        {
            panelTatakan.BackColor = Color.FromArgb(50, 0, 0, 0);
        }

        
    }
}
