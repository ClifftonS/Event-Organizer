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
    public partial class FormRiwayat : Form
    {
        public FormRiwayat()
        {
            InitializeComponent();
        }
        MySqlConnection sqlConnect;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        string connectString = "server=localhost;uid=root;pwd=;database=loketdotcom;";
        string sqlQuery;

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

        private void pboxProfil_Click(object sender, EventArgs e)
        {
            if (panelProfil.Visible == true)
            {
                panelProfil.Visible = false;
            }
            else
            {
                panelProfil.Visible = true;
            }
        }

        private void lblEvent_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPesanan fp = new FormPesanan();
            fp.ShowDialog();
        }

        private void FormRiwayat_Load(object sender, EventArgs e)
        {
            DataTable dtRiwayat = new DataTable();
            lblNamaAtas.Text = FormLogin.simpanNama;
            sqlConnect = new MySqlConnection(connectString);
            sqlQuery = "SELECT ID_TRANS AS `ID Transaksi`, e.JUDUL_EVENT AS `Judul Event`, TGL_EVENT AS `Tanggal Event`, JUMLAH_PEMBAYARAN AS `Jumlah Bayar`, TGL_TRANS AS `Tanggal Bayar` FROM event_acara e, transaksi_beli_tiket t WHERE e.JUDUL_EVENT = t.JUDUL_EVENT AND USERNAME = '" + FormLogin.simpanUser+"'";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtRiwayat);
            dgvRiwayat.DataSource = dtRiwayat;

        }

        private void btnEditAtas_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProfil fpr = new FormProfil();
            fpr.ShowDialog();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin fl = new FormLogin();
            fl.ShowDialog();
        }
    }
}
