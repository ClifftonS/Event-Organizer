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
    public partial class FormSignUp : System.Windows.Forms.Form
    {
        public FormSignUp()
        {
            InitializeComponent();
        }
        MySqlConnection sqlConnect;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        string sqlQuery;
        string connectString = "server=localhost;uid=root;pwd=;database=loketdotcom;";

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (tboxUser.Text != "" && tboxPass.Text != "" && tboxName.Text != "" && tboxNo.Text != "")
            {
                try
                {
                    sqlConnect = new MySqlConnection(connectString);
                    sqlQuery = "INSERT INTO pengguna VALUES ('" + tboxUser.Text + "', '" + tboxPass.Text + "', '" + tboxName.Text + "', '" + tboxNo.Text + "')";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlConnect.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnect.Close();
                    FormLogin.simpanUser = tboxUser.Text;
                    FormLogin.simpanNama = tboxName.Text;
                    this.Hide();
                    FormHome fh = new FormHome();
                    fh.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Data masih ada yang kosong");
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            FormLogin fl = new FormLogin();
            fl.Show();
        }

        private void FormSignUp_Load(object sender, EventArgs e)
        {

        }

        private void panelTatakan_Paint(object sender, PaintEventArgs e)
        {
            panelTatakan.BackColor = Color.FromArgb(50, 0, 0, 0);
        }

        private void tboxNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
