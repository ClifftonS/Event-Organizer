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
    public partial class FormHome : Form
    {
        public FormHome()
        {
            InitializeComponent();
        }
        public static string simpanjudul = "";
        public static string simpansearch = "";
        MySqlConnection sqlConnect;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        string connectString = "server=localhost;uid=root;pwd=;database=loketdotcom;";
        string sqlQuery;

        private void Form3_Load(object sender, EventArgs e)
        {
            lblNamaAtas.Text = FormLogin.simpanNama;
            DataTable dtEvent = new DataTable();
            sqlConnect = new MySqlConnection(connectString);
            sqlQuery = "SELECT e.JUDUL_EVENT AS `Judul`, WAKTU_EVENT AS `Waktu`, LOKASI_EVENT AS `Lokasi`, URL_EVENT AS `Gambar`, NAMA_P AS `Penyelenggara`, SUM(TIKET_TERJUAL) AS `Terjual` FROM event_acara e, tiket t WHERE e.JUDUL_EVENT = t.JUDUL_EVENT GROUP BY `Judul` ORDER BY `Terjual` desc LIMIT 6;";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtEvent);
            pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
            lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
            lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
            lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
            lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
            pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
            lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
            lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
            lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
            lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
            pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
            lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
            lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
            lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
            lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
            pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
            lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
            lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
            lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
            lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
            pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
            lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
            lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
            lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
            lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
            pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
            lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
            lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
            lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
            lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
        }

        private void tboxSearch_TextChanged(object sender, EventArgs e)
        {
            if (tboxSearch.Text != "")
            {
                lblSearch.Visible = false;
            }
            else
            {
                lblSearch.Visible = true;
            }
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHome fh = new FormHome();
            fh.ShowDialog();
        }

        private void pboxSearch_Click(object sender, EventArgs e)
        {
            simpansearch = tboxSearch.Text;
            this.Hide();
            FormCariEvent fce = new FormCariEvent();
            fce.ShowDialog();
        }

        private void btnBeli1_Click(object sender, EventArgs e)
        {
            simpanjudul = lblJudul1.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
        }

        private void btnBeli2_Click(object sender, EventArgs e)
        {
            simpanjudul = lblJudul2.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
        }

        private void btnBeli3_Click(object sender, EventArgs e)
        {
            simpanjudul = lblJudul3.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
        }

        private void btnBeli4_Click(object sender, EventArgs e)
        {
            simpanjudul = lblJudul4.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
        }

        private void btnBeli5_Click(object sender, EventArgs e)
        {
            simpanjudul = lblJudul5.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
        }

        private void btnBeli6_Click(object sender, EventArgs e)
        {
            simpanjudul = lblJudul6.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
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

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin fl = new FormLogin();
            fl.ShowDialog();

        }

        private void btnEditAtas_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormProfil fpr = new FormProfil();
            fpr.ShowDialog();

        }
    }
}
