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

namespace Form_Input
{
    public partial class FormLogin : Form
    {
        public MySqlConnection conn;
        public FormLogin()
        {
            InitializeComponent();
        }

        private void openDBConn()
        {
            conn = new MySqlConnection();
            conn.ConnectionString = "server=" + txtHost.Text + "; uid=" + txtUser.Text + "; pwd=" + txtPass.Text + "; database=KMMI7;";

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                MessageBox.Show("Sukses Terkoneksi ke Database!");
                FormMenu fMenu = new FormMenu();
                fMenu.init(this);
                fMenu.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUser.Clear();
            txtPass.Clear();
            txtHost.Clear();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            openDBConn();
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
