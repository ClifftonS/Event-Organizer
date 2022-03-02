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
    public partial class FormProfil : Form
    {
        public FormProfil()
        {
            InitializeComponent();
        }
        MySqlConnection sqlConnect;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        string connectString = "server=localhost;uid=root;pwd=;database=loketdotcom;";
        string sqlQuery;
        string Nama = "";
        string No = "";
        string Pass = "";
        bool pass = false;
        

        DataTable dtprofile = new DataTable();
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHome fh = new FormHome();
            fh.ShowDialog();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCariEvent fce = new FormCariEvent();
            fce.ShowDialog();
        }

        private void btnCek_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPesanan fp = new FormPesanan();
            fp.ShowDialog();
        }

        private void FormProfil_Load(object sender, EventArgs e)
        {
            try
            {
                tboxPass.PasswordChar = '*';
                tboxNew.PasswordChar = '*';
                sqlConnect = new MySqlConnection(connectString);
                sqlQuery = "select USERNAME as `Username`, NAMA as `Nama`, NO_HP as `No Hp`, `PASSWORD` as `Password` from pengguna where username = '" + FormLogin.simpanUser + "';";
                dtprofile = new DataTable();
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtprofile);

                tboxName.Text = dtprofile.Rows[0]["Nama"].ToString();
                tboxUsername.Text = dtprofile.Rows[0]["Username"].ToString();
                
                tboxNo.Text = dtprofile.Rows[0]["No Hp"].ToString();
                Nama = dtprofile.Rows[0]["Nama"].ToString();
                No = dtprofile.Rows[0]["No Hp"].ToString();
                Pass = dtprofile.Rows[0]["Password"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(tboxName.Text != Nama || tboxNo.Text != No)
            {
                if(tboxName.Text != "" && tboxNo.Text != "")
                {
                    sqlConnect = new MySqlConnection(connectString);
                    sqlQuery = "update pengguna set NAMA = '" + tboxName.Text + "', NO_HP = '" +tboxNo.Text + "' where USERNAME = '" + FormLogin.simpanUser + "'";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlConnect.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnect.Close();
                    FormLogin.simpanNama = tboxName.Text;
                    this.Hide();
                    FormHome fh = new FormHome();
                    fh.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Data tidak boleh ada yang kosong");
                }
            }
            else
            {
                MessageBox.Show("Data tidak ada yang berubah");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(pass == true)
            {
                if(tboxNew.Text != "")
                {
                    sqlConnect = new MySqlConnection(connectString);
                    sqlQuery = "update pengguna set PASSWORD = '"+tboxNew.Text+"' where USERNAME = '" + FormLogin.simpanUser + "'";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlConnect.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnect.Close();
                    this.Hide();
                    FormHome fh = new FormHome();
                    fh.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Data tidak boleh ada yang kosong");
                }
            }
            else
            {
                MessageBox.Show("Current Password Salah");
            }
        }

        private void tboxPass_TextChanged(object sender, EventArgs e)
        {
            DataTable Pengguna = new DataTable();
            sqlConnect = new MySqlConnection(connectString);
            sqlQuery = "SELECT * FROM pengguna WHERE USERNAME = '" + tboxUsername.Text + "'";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(Pengguna);

            if (tboxPass.Text == Pengguna.Rows[0]["PASSWORD"].ToString())
            {
                pass = true;
            }
        }
    }
}
