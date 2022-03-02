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
    public partial class FormPesanan : System.Windows.Forms.Form
    {
        public FormPesanan()
        {
            InitializeComponent();
        }
        MySqlConnection sqlConnect;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        string connectString = "server=localhost;uid=root;pwd=;database=loketdotcom;";
        string sqlQuery;

        DataTable dtCekPesanan = new DataTable();
        string imagelocation = "";
        public static string SimpanInvoice = "";

        private void FormPesanan_Load(object sender, EventArgs e)
        {
            try
            {
                lblNamaAtas.Text = FormLogin.simpanNama;
                sqlConnect = new MySqlConnection(connectString);
                sqlQuery = "select e.JUDUL_EVENT as `Judul`, concat(dayname(tgl_event), ', ',day(tgl_event), '-', month(tgl_event), '-', year(tgl_event), '   ', waktu_event) as `TanggalWaktu`, URL_EVENT as `URL` from event_acara e, transaksi_beli_tiket t where e.JUDUL_EVENT= t.JUDUL_EVENT and t.username = '"+FormLogin.simpanUser+"' AND TGL_EVENT >= now();";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtCekPesanan);

                if (dtCekPesanan.Rows.Count == 1)
                {
                    int itung = dtCekPesanan.Rows.Count;
                    labelIsiTotalEvent.Text = itung.ToString();
                    panelCek1.Visible = true;
                    panelCek2.Visible = false;
                    panelCek3.Visible = false;
                    labelNamaWebinar.Text = dtCekPesanan.Rows[0]["Judul"].ToString();
                    labelTanggal.Text = dtCekPesanan.Rows[0]["TanggalWaktu"].ToString();
                    imagelocation = dtCekPesanan.Rows[0]["URL"].ToString();
                    pictureBoxCekP1.ImageLocation = imagelocation;
                }
                else if (dtCekPesanan.Rows.Count == 2)
                {
                    int itung = dtCekPesanan.Rows.Count;
                    labelIsiTotalEvent.Text = itung.ToString();
                    panelCek1.Visible = true;
                    panelCek2.Visible = true;
                    panelCek3.Visible = false;
                    labelNamaWebinar.Text = dtCekPesanan.Rows[0]["Judul"].ToString();
                    labelTanggal.Text = dtCekPesanan.Rows[0]["TanggalWaktu"].ToString();
                    imagelocation = dtCekPesanan.Rows[0]["URL"].ToString();
                    pictureBoxCekP1.ImageLocation = imagelocation;
                    labelNamaWebinar2.Text = dtCekPesanan.Rows[1]["Judul"].ToString();
                    labelTanggal2.Text = dtCekPesanan.Rows[1]["TanggalWaktu"].ToString();
                    imagelocation = dtCekPesanan.Rows[1]["URL"].ToString();
                    pictureBoxCekP2.ImageLocation = imagelocation;
                }
                else if (dtCekPesanan.Rows.Count == 3)
                {
                    int itung = dtCekPesanan.Rows.Count;
                    labelIsiTotalEvent.Text = itung.ToString();
                    panelCek1.Visible = true;
                    panelCek2.Visible = true;
                    panelCek3.Visible = true;
                    labelNamaWebinar.Text = dtCekPesanan.Rows[0]["Judul"].ToString();
                    labelTanggal.Text = dtCekPesanan.Rows[0]["TanggalWaktu"].ToString();
                    imagelocation = dtCekPesanan.Rows[0]["URL"].ToString();
                    pictureBoxCekP1.ImageLocation = imagelocation;
                    labelNamaWebinar2.Text = dtCekPesanan.Rows[1]["Judul"].ToString();
                    labelTanggal2.Text = dtCekPesanan.Rows[1]["TanggalWaktu"].ToString();
                    imagelocation = dtCekPesanan.Rows[1]["URL"].ToString();
                    pictureBoxCekP2.ImageLocation = imagelocation;
                    labelNamaWebinar3.Text = dtCekPesanan.Rows[2]["Judul"].ToString();
                    labelTanggal3.Text = dtCekPesanan.Rows[2]["TanggalWaktu"].ToString();
                    imagelocation = dtCekPesanan.Rows[2]["URL"].ToString();
                    pictureBoxCekP3.ImageLocation = imagelocation;
                }
                labelIsiTotalEvent.Text = (dtCekPesanan.Rows.Count).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void btnInvoice1_Click(object sender, EventArgs e)
        {
            SimpanInvoice = labelNamaWebinar.Text;
            this.Hide();
            FormInvoice fi = new FormInvoice();
            fi.ShowDialog();
        }

        private void btnInvoice2_Click(object sender, EventArgs e)
        {
            SimpanInvoice = labelNamaWebinar2.Text;
            this.Hide();
            FormInvoice fi = new FormInvoice();
            fi.ShowDialog();
        }

        private void btnInvoice3_Click(object sender, EventArgs e)
        {
            SimpanInvoice = labelNamaWebinar3.Text;
            this.Hide();
            FormInvoice fi = new FormInvoice();
            fi.ShowDialog();
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

        private void lblRiwayat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRiwayat fr = new FormRiwayat();
            fr.ShowDialog();
        }
    }
}
