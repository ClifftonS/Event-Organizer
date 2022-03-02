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
    public partial class FormInvoice : Form
    {
        public FormInvoice()
        {
            InitializeComponent();
        }
        MySqlConnection sqlConnect;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        string connectString = "server=localhost;uid=root;pwd=;database=loketdotcom;";
        string sqlQuery;
        DataTable dtinvoice = new DataTable();


        

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

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            lblNamaAtas.Text = FormLogin.simpanNama;
            sqlConnect = new MySqlConnection(connectString);
            sqlQuery = "select t.ID_TRANS as `Kode`, NAMA as `Nama`, NO_HP as `No HP`, concat(date(tgl_trans)) as `Tgl Trans`, METODE_BAYAR as `Metode bayar`, NAMA_P as `Penyelenggara`, d.KATEGORI_TIKET as `Nama Tiket`, BELI_QTY as `QTY`, HARGA_TIKET as `Harga Tiket`, JUMLAH_PEMBAYARAN as `Total` from pengguna p, transaksi_beli_tiket t, event_acara e, detail_trans_beli_tiket d, tiket tt where p.USERNAME=t.Username and e.JUDUL_EVENT=t.JUDUL_EVENT and d.ID_TRANS=t.ID_TRANS and tt.KATEGORI_TIKET=d.KATEGORI_TIKET and t.JUDUL_EVENT = '" + FormPesanan.SimpanInvoice.ToString() + "' and p.USERNAME = '"+FormLogin.simpanUser+"';";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtinvoice);

            labelKodePemesanan.Text = dtinvoice.Rows[0]["Kode"].ToString();
            labelNama.Text = dtinvoice.Rows[0]["Nama"].ToString();
            labelNoTelp.Text = dtinvoice.Rows[0]["No HP"].ToString();
            labelTanggal.Text = dtinvoice.Rows[0]["Tgl Trans"].ToString();
            labelMetodeBayar.Text = dtinvoice.Rows[0]["Metode bayar"].ToString();
            labelNamaCust.Text = dtinvoice.Rows[0]["Nama"].ToString();
            labelEvent.Text = dtinvoice.Rows[0]["Penyelenggara"].ToString();

            if (dtinvoice.Rows.Count == 1)
            {
                int total = 0;
                labelNamaTiket.Visible = true;
                labelNamaTiekt2.Visible = false;
                labelNamaTiekt3.Visible = false;
                labelQty.Visible = true;
                labelQty2.Visible = false;
                labelQty3.Visible = false;
                labelHarga.Visible = true;
                labelHarga2.Visible = false;
                labelHarga3.Visible = false;
                labelJumlah.Visible = true;
                labelJumlah2.Visible = false;
                labelJumlah3.Visible = false;

                labelNamaTiket.Text = dtinvoice.Rows[0]["Nama Tiket"].ToString();
                labelQty.Text = dtinvoice.Rows[0]["QTY"].ToString();
                labelHarga.Text = dtinvoice.Rows[0]["Harga Tiket"].ToString();
                labelJumlah.Text = dtinvoice.Rows[0]["Total"].ToString();

                int harga1 = Convert.ToInt32(this.labelJumlah.Text);
                total = harga1;
                labelTotal.Text = total.ToString();
            }
            else if (dtinvoice.Rows.Count == 2)
            {
                int total = 0;
                labelNamaTiket.Visible = true;
                labelNamaTiekt2.Visible = true;
                labelNamaTiekt3.Visible = false;
                labelQty.Visible = true;
                labelQty2.Visible = true;
                labelQty3.Visible = false;
                labelHarga.Visible = true;
                labelHarga2.Visible = true;
                labelHarga3.Visible = false;
                labelJumlah.Visible = true;
                labelJumlah2.Visible = true;
                labelJumlah3.Visible = false;

                labelNamaTiket.Text = dtinvoice.Rows[0]["Nama Tiket"].ToString();
                labelQty.Text = dtinvoice.Rows[0]["QTY"].ToString();
                labelHarga.Text = dtinvoice.Rows[0]["Harga Tiket"].ToString();
                labelJumlah.Text = dtinvoice.Rows[0]["Total"].ToString();
                labelNamaTiekt2.Text = dtinvoice.Rows[1]["Nama Tiket"].ToString();
                labelQty2.Text = dtinvoice.Rows[1]["QTY"].ToString();
                labelHarga2.Text = dtinvoice.Rows[1]["Harga Tiket"].ToString();
                labelJumlah2.Text = dtinvoice.Rows[1]["Total"].ToString();

                int harga1 = Convert.ToInt32(this.labelJumlah.Text);
                int harga2 = Convert.ToInt32(this.labelJumlah2.Text);
                total = harga1 + harga2;
                labelTotal.Text = total.ToString();
            }
            else if (dtinvoice.Rows.Count == 3)
            {
                int total = 0;
                labelNamaTiket.Visible = true;
                labelNamaTiekt2.Visible = true;
                labelNamaTiekt3.Visible = true;
                labelQty.Visible = true;
                labelQty2.Visible = true;
                labelQty3.Visible = true;
                labelHarga.Visible = true;
                labelHarga2.Visible = true;
                labelHarga3.Visible = true;
                labelJumlah.Visible = true;
                labelJumlah2.Visible = true;
                labelJumlah3.Visible = true;

                labelNamaTiket.Text = dtinvoice.Rows[0]["Nama Tiket"].ToString();
                labelQty.Text = dtinvoice.Rows[0]["QTY"].ToString();
                labelHarga.Text = dtinvoice.Rows[0]["Harga Tiket"].ToString();
                labelJumlah.Text = dtinvoice.Rows[0]["Total"].ToString();
                labelNamaTiekt2.Text = dtinvoice.Rows[1]["Nama Tiket"].ToString();
                labelQty2.Text = dtinvoice.Rows[1]["QTY"].ToString();
                labelHarga2.Text = dtinvoice.Rows[1]["Harga Tiket"].ToString();
                labelJumlah2.Text = dtinvoice.Rows[1]["Total"].ToString();
                labelNamaTiekt3.Text = dtinvoice.Rows[2]["Nama Tiket"].ToString();
                labelQty3.Text = dtinvoice.Rows[2]["QTY"].ToString();
                labelHarga3.Text = dtinvoice.Rows[2]["Harga Tiket"].ToString();
                labelJumlah3.Text = dtinvoice.Rows[2]["Total"].ToString();

                int harga1 = Convert.ToInt32(this.labelJumlah.Text);
                int harga2 = Convert.ToInt32(this.labelJumlah2.Text);
                int harga3 = Convert.ToInt32(this.labelJumlah3.Text);
                total = harga1 + harga2 + harga3;
                labelTotal.Text = total.ToString();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHome fh = new FormHome();
            fh.ShowDialog();
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
