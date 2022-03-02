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
    public partial class FormDetail : System.Windows.Forms.Form
    {
        public FormDetail()
        {
            InitializeComponent();
        }
        MySqlConnection sqlConnect;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        string connectString = "server=localhost;uid=root;pwd=;database=loketdotcom;";
        string sqlQuery;
        DataTable dtdetailevent = new DataTable();
        string imagelocation = "";
        public static int a = 0;
        public static int b = 0;
        public static int c = 0;
        public static int sub = 0;
        public static string aJudul = "";
        public static string bJudul = "";
        public static string cJudul = "";
        public static int d = 0;
        int sisatiket = 0;
        int sisatiket2 = 0;
        int sisatiket3 = 0;
        bool dobel = false;

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

        private void btnBeli_Click(object sender, EventArgs e)
        {
            
            sqlQuery = "SELECT * FROM transaksi_beli_tiket WHERE USERNAME = '"+FormLogin.simpanUser+"'";
            DataTable dtTrans = new DataTable();
            sqlConnect = new MySqlConnection(connectString);
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtTrans);
            for (int i = 0; i <= dtTrans.Rows.Count - 1; i++)
            {
                if (lblJudul.Text == dtTrans.Rows[i]["JUDUL_EVENT"].ToString())
                {
                    dobel = true;
                }
            }
            sqlQuery = "SELECT * FROM transaksi_beli_tiket t, EVENT_ACARA e WHERE t.JUDUL_EVENT = e.JUDUL_EVENT AND USERNAME = '"+FormLogin.simpanUser+"' AND TGL_EVENT >= now()";
            DataTable dtCount = new DataTable();
            sqlConnect = new MySqlConnection(connectString);
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtCount);
            if (dtCount.Rows.Count < 3)
            {
                if (dobel == false)
                {
                    if (a != 0 || b != 0 || c != 0)
                    {
                        if (a > 0)
                        {
                            d++;
                        }
                        if (b > 0)
                        {
                            d++;
                        }
                        if (c > 0)
                        {
                            d++;
                        }
                        this.Hide();
                        FormCheckout fc = new FormCheckout();
                        fc.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Pilih Tiket Terlebih Dahulu");
                    }
                }
                else
                {
                    MessageBox.Show("Anda Sudah Pernah Memesan Event Ini");
                }
            }
            else
            {
                MessageBox.Show("Maksimal 3 Event Berjalan");
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHome fh = new FormHome();
            fh.ShowDialog();
        }

        private void FormDetail_Load(object sender, EventArgs e)
        {
            try
            {
                lblNamaAtas.Text = FormLogin.simpanNama;
                dobel = false;
                a = 0;
                b = 0;
                c = 0;
                d = 0;
                lblSoldOut1.Visible = false;
                lblSaleEnded1.Visible = false;
                lblNotStarted1.Visible = false;
                lblSoldOut2.Visible = false;
                lblSaleEnded2.Visible = false;
                lblNotStarted2.Visible = false;
                lblSoldOut3.Visible = false;
                lblSaleEnded3.Visible = false;
                lblNotStarted3.Visible = false;
                sqlConnect = new MySqlConnection(connectString);
                sqlQuery = "select e.JUDUL_EVENT as `Judul`, KATEGORI_EVENT as `Kategori`, NAMA_P as `Penyelenggara`, WAKTU_EVENT as `Waktu`, concat(lokasi_event, ', ', alamat_event) as `Lokasi`, KATEGORI_TIKET as `Nama Tiket`, DESKRIPSI_TIKET as `Deskripsi Tiket`, HARGA_TIKET as `Harga`, DESKRIPSI_EVENT as `Deskripsi Event`, concat('Batas beli tiket: ', akhir_tiket) as `Akhir Tiket`, URL_EVENT as `URL`, AWAL_TIKET AS `Awal`, AKHIR_TIKET AS `Akhir`, TIKET_TERJUAL AS `Terjual`, KAPASITAS AS `Kapasitas` from event_acara e, tiket t where e.JUDUL_EVENT=t.JUDUL_EVENT and e.JUDUL_EVENT = '" + FormHome.simpanjudul.ToString() + "';";
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtdetailevent);

                lblJudul.Text = dtdetailevent.Rows[0]["Judul"].ToString();
                lblKategori.Text = dtdetailevent.Rows[0]["Kategori"].ToString();
                labelIsiPenyelenggara.Text = dtdetailevent.Rows[0]["Penyelenggara"].ToString();
                labelIsiWaktu.Text = dtdetailevent.Rows[0]["Waktu"].ToString();
                labelIsiLokasi.Text = dtdetailevent.Rows[0]["Lokasi"].ToString();
                

                if (dtdetailevent.Rows.Count == 1)
                {
                    panelTiket1.Visible = true;
                    panelTiket2.Visible = false;
                    panelTiket3.Visible = false;
                    panelpindah.Location = new Point(117, 330);
                    labelNamaTiket1.Text = dtdetailevent.Rows[0]["Nama Tiket"].ToString();
                    aJudul = dtdetailevent.Rows[0]["Nama Tiket"].ToString();
                    labelDeskripsi1.Text = dtdetailevent.Rows[0]["Deskripsi Tiket"].ToString();
                    labelExpTiket1.Text = dtdetailevent.Rows[0]["Akhir Tiket"].ToString();
                    lblHarga1.Text = dtdetailevent.Rows[0]["Harga"].ToString();
                    DateTime now = DateTime.Today;
                    sisatiket = Convert.ToInt32(dtdetailevent.Rows[0]["Kapasitas"].ToString()) - Convert.ToInt32(dtdetailevent.Rows[0]["Terjual"].ToString());
                    if (Convert.ToDateTime(dtdetailevent.Rows[0]["Awal"]).Date > now.Date)
                    {
                        lblNotStarted1.Visible = true;
                        btnPlus1.Enabled = false;
                        btnMin1.Enabled = false;
                    }
                    if(Convert.ToDateTime(dtdetailevent.Rows[0]["Akhir"]).Date < now.Date)
                    {
                        lblSaleEnded1.Visible = true;
                        btnPlus1.Enabled = false;
                        btnMin1.Enabled = false;
                    }
                    if(sisatiket == 0)
                    {
                        lblSoldOut1.Visible = true;
                        btnPlus1.Enabled = false;
                        btnMin1.Enabled = false;
                    }
                }
                else if (dtdetailevent.Rows.Count == 2)
                {
                    panelTiket1.Visible = true;
                    panelTiket2.Visible = true;
                    panelTiket3.Visible = false;
                    panelpindah.Location = new Point(117, 400);
                    labelNamaTiket1.Text = dtdetailevent.Rows[0]["Nama Tiket"].ToString();
                    aJudul = dtdetailevent.Rows[0]["Nama Tiket"].ToString();
                    labelDeskripsi1.Text = dtdetailevent.Rows[0]["Deskripsi Tiket"].ToString();
                    labelExpTiket1.Text = dtdetailevent.Rows[0]["Akhir Tiket"].ToString();
                    lblHarga1.Text = dtdetailevent.Rows[0]["Harga"].ToString();
                    labelNamaTiket2.Text = dtdetailevent.Rows[1]["Nama Tiket"].ToString();
                    bJudul = dtdetailevent.Rows[1]["Nama Tiket"].ToString();
                    labelDeskripsi2.Text = dtdetailevent.Rows[1]["Deskripsi Tiket"].ToString();
                    labelExpTiket2.Text = dtdetailevent.Rows[1]["Akhir Tiket"].ToString();
                    lblHarga2.Text = dtdetailevent.Rows[1]["Harga"].ToString();
                    DateTime now = DateTime.Today;
                    sisatiket = Convert.ToInt32(dtdetailevent.Rows[0]["Kapasitas"].ToString()) - Convert.ToInt32(dtdetailevent.Rows[0]["Terjual"].ToString());
                    if (Convert.ToDateTime(dtdetailevent.Rows[0]["Awal"]).Date > now.Date)
                    {
                        lblNotStarted1.Visible = true;
                        btnPlus1.Enabled = false;
                        btnMin1.Enabled = false;
                    }
                    if (Convert.ToDateTime(dtdetailevent.Rows[0]["Akhir"]).Date < now.Date)
                    {
                        lblSaleEnded1.Visible = true;
                        btnPlus1.Enabled = false;
                        btnMin1.Enabled = false;
                    }
                    if (sisatiket == 0)
                    {
                        lblSoldOut1.Visible = true;
                        btnPlus1.Enabled = false;
                        btnMin1.Enabled = false;
                    }
                    sisatiket2 = Convert.ToInt32(dtdetailevent.Rows[1]["Kapasitas"].ToString()) - Convert.ToInt32(dtdetailevent.Rows[1]["Terjual"].ToString());
                    if (Convert.ToDateTime(dtdetailevent.Rows[1]["Awal"]).Date > now.Date)
                    {
                        lblNotStarted2.Visible = true;
                        btnPlus2.Enabled = false;
                        btnMin2.Enabled = false;
                    }
                    if (Convert.ToDateTime(dtdetailevent.Rows[1]["Akhir"]).Date < now.Date)
                    {
                        lblSaleEnded2.Visible = true;
                        btnPlus2.Enabled = false;
                        btnMin2.Enabled = false;
                    }
                    if (sisatiket2 == 0)
                    {
                        lblSoldOut2.Visible = true;
                        btnPlus2.Enabled = false;
                        btnMin2.Enabled = false;
                    }
                }
                else if (dtdetailevent.Rows.Count == 3)
                {
                    panelTiket1.Visible = true;
                    panelTiket2.Visible = true;
                    panelTiket3.Visible = true;
                    panelpindah.Location = new Point(117, 520);
                    labelNamaTiket1.Text = dtdetailevent.Rows[0]["Nama Tiket"].ToString();
                    aJudul = dtdetailevent.Rows[0]["Nama Tiket"].ToString();
                    labelDeskripsi1.Text = dtdetailevent.Rows[0]["Deskripsi Tiket"].ToString();
                    labelExpTiket1.Text = dtdetailevent.Rows[0]["Akhir Tiket"].ToString();
                    lblHarga1.Text = dtdetailevent.Rows[0]["Harga"].ToString();
                    labelNamaTiket2.Text = dtdetailevent.Rows[1]["Nama Tiket"].ToString();
                    bJudul = dtdetailevent.Rows[1]["Nama Tiket"].ToString();
                    labelDeskripsi2.Text = dtdetailevent.Rows[1]["Deskripsi Tiket"].ToString();
                    labelExpTiket2.Text = dtdetailevent.Rows[1]["Akhir Tiket"].ToString();
                    lblHarga2.Text = dtdetailevent.Rows[1]["Harga"].ToString();
                    labelNamaTiket3.Text = dtdetailevent.Rows[2]["Nama Tiket"].ToString();
                    cJudul = dtdetailevent.Rows[2]["Nama Tiket"].ToString();
                    labelDeskripsi3.Text = dtdetailevent.Rows[2]["Deskripsi Tiket"].ToString();
                    labelExpTiket3.Text = dtdetailevent.Rows[2]["Akhir Tiket"].ToString();
                    lblHarga3.Text = dtdetailevent.Rows[2]["Harga"].ToString();
                    DateTime now = DateTime.Today;
                    sisatiket = Convert.ToInt32(dtdetailevent.Rows[0]["Kapasitas"].ToString()) - Convert.ToInt32(dtdetailevent.Rows[0]["Terjual"].ToString());
                    if (Convert.ToDateTime(dtdetailevent.Rows[0]["Awal"]).Date > now.Date)
                    {
                        lblNotStarted1.Visible = true;
                        btnPlus1.Enabled = false;
                        btnMin1.Enabled = false;
                    }
                    if (Convert.ToDateTime(dtdetailevent.Rows[0]["Akhir"]).Date < now.Date)
                    {
                        lblSaleEnded1.Visible = true;
                        btnPlus1.Enabled = false;
                        btnMin1.Enabled = false;
                    }
                    if (sisatiket == 0)
                    {
                        lblSoldOut1.Visible = true;
                        btnPlus1.Enabled = false;
                        btnMin1.Enabled = false;
                    }
                    sisatiket2 = Convert.ToInt32(dtdetailevent.Rows[1]["Kapasitas"].ToString()) - Convert.ToInt32(dtdetailevent.Rows[1]["Terjual"].ToString());
                    if (Convert.ToDateTime(dtdetailevent.Rows[1]["Awal"]).Date > now.Date)
                    {
                        lblNotStarted2.Visible = true;
                        btnPlus2.Enabled = false;
                        btnMin2.Enabled = false;
                    }
                    if (Convert.ToDateTime(dtdetailevent.Rows[1]["Akhir"]).Date < now.Date)
                    {
                        lblSaleEnded2.Visible = true;
                        btnPlus2.Enabled = false;
                        btnMin2.Enabled = false;
                    }
                    if (sisatiket2 == 0)
                    {
                        lblSoldOut2.Visible = true;
                        btnPlus2.Enabled = false;
                        btnMin2.Enabled = false;
                    }
                    sisatiket3 = Convert.ToInt32(dtdetailevent.Rows[2]["Kapasitas"].ToString()) - Convert.ToInt32(dtdetailevent.Rows[2]["Terjual"].ToString());
                    if (Convert.ToDateTime(dtdetailevent.Rows[2]["Awal"]).Date > now.Date)
                    {
                        lblNotStarted3.Visible = true;
                        btnPlus3.Enabled = false;
                        btnMin3.Enabled = false;
                    }
                    if (Convert.ToDateTime(dtdetailevent.Rows[2]["Akhir"]).Date < now.Date)
                    {
                        lblSaleEnded3.Visible = true;
                        btnPlus3.Enabled = false;
                        btnMin3.Enabled = false;
                    }
                    if (sisatiket3 == 0)
                    {
                        lblSoldOut3.Visible = true;
                        btnPlus3.Enabled = false;
                        btnMin3.Enabled = false;
                    }
                }

                textBoxDeskripsi.Text = dtdetailevent.Rows[0]["Deskripsi Event"].ToString();
                imagelocation = dtdetailevent.Rows[0]["URL"].ToString();
                pictureBoxDetailEvent.ImageLocation = imagelocation;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPlus1_Click(object sender, EventArgs e)
        {
            a++;
            btnMin1.Enabled = true;
            lblJumlah1.Text = a.ToString();
            sub = 0;
            if(a == sisatiket)
            {
                btnPlus1.Enabled = false;
            }
            if (dtdetailevent.Rows.Count == 1)
            {
                int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                sub = harga1 * a;
                label1.Text = sub.ToString();
            }
            if (dtdetailevent.Rows.Count == 2)
            {
                int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                int harga2 = Convert.ToInt32(this.lblHarga2.Text);
                sub = harga1 * a + harga2 * b;
                label1.Text = sub.ToString();
            }
            if (dtdetailevent.Rows.Count == 3)
            {
                int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                int harga2 = Convert.ToInt32(this.lblHarga2.Text);
                int harga3 = Convert.ToInt32(this.lblHarga3.Text);
                sub = harga1 * a + harga2 * b + harga3 * c;
                label1.Text = sub.ToString();
            }
        }

        private void btnMin1_Click(object sender, EventArgs e)
        {
            a--;
            btnPlus1.Enabled = true;
            if (a >= 0)
            {
                lblJumlah1.Text = a.ToString();
                sub = 0;

                if (dtdetailevent.Rows.Count == 1)
                {
                    int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                    sub = harga1 * a;
                    label1.Text = sub.ToString();
                }
                else if (dtdetailevent.Rows.Count == 2)
                {
                    int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                    int harga2 = Convert.ToInt32(this.lblHarga2.Text);
                    sub = harga1 * a + harga2 * b;
                    label1.Text = sub.ToString();
                }
                else if (dtdetailevent.Rows.Count == 3)
                {
                    int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                    int harga2 = Convert.ToInt32(this.lblHarga2.Text);
                    int harga3 = Convert.ToInt32(this.lblHarga3.Text);
                    sub = harga1 * a + harga2 * b + harga3 * c;
                    label1.Text = sub.ToString();
                }
            }
            else
            {
                btnMin1.Enabled = false;
            }
        }

        private void btnPlus2_Click(object sender, EventArgs e)
        {
            b++;
            btnMin2.Enabled = true;
            lblJumlah2.Text = b.ToString();
            sub = 0;
            if (b == sisatiket2)
            {
                btnPlus2.Enabled = false;
            }
            if (dtdetailevent.Rows.Count == 1)
            {
                int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                sub = harga1 * a;
                label1.Text = sub.ToString();
            }
            if (dtdetailevent.Rows.Count == 2)
            {
                int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                int harga2 = Convert.ToInt32(this.lblHarga2.Text);
                sub = harga1 * a + harga2 * b;
                label1.Text = sub.ToString();
            }
            if (dtdetailevent.Rows.Count == 3)
            {
                int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                int harga2 = Convert.ToInt32(this.lblHarga2.Text);
                int harga3 = Convert.ToInt32(this.lblHarga3.Text);
                sub = harga1 * a + harga2 * b + harga3 * c;
                label1.Text = sub.ToString();
            }
        }

        private void btnMin2_Click(object sender, EventArgs e)
        {
            b--;
            btnPlus2.Enabled = true;
            if (b >= 0)
            {
                lblJumlah2.Text = b.ToString();
                sub = 0;

                if (dtdetailevent.Rows.Count == 1)
                {
                    int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                    sub = harga1 * a;
                    label1.Text = sub.ToString();
                }
                else if (dtdetailevent.Rows.Count == 2)
                {
                    int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                    int harga2 = Convert.ToInt32(this.lblHarga2.Text);
                    sub = harga1 * a + harga2 * b;
                    label1.Text = sub.ToString();
                }
                else if (dtdetailevent.Rows.Count == 3)
                {
                    int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                    int harga2 = Convert.ToInt32(this.lblHarga2.Text);
                    int harga3 = Convert.ToInt32(this.lblHarga3.Text);
                    sub = harga1 * a + harga2 * b + harga3 * c;
                    label1.Text = sub.ToString();
                }
            }
            else
            {
                btnMin2.Enabled = false;
            }
        }

        private void btnPlus3_Click(object sender, EventArgs e)
        {
            c++;
            btnMin3.Enabled = true;
            lblJumlah3.Text = c.ToString();
            sub = 0;
            if (c == sisatiket3)
            {
                btnPlus3.Enabled = false;
            }
            if (dtdetailevent.Rows.Count == 1)
            {
                int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                sub = harga1 * a;
                label1.Text = sub.ToString();
            }
            if (dtdetailevent.Rows.Count == 2)
            {
                int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                int harga2 = Convert.ToInt32(this.lblHarga2.Text);
                sub = harga1 * a + harga2 * b;
                label1.Text = sub.ToString();
            }
            if (dtdetailevent.Rows.Count == 3)
            {
                int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                int harga2 = Convert.ToInt32(this.lblHarga2.Text);
                int harga3 = Convert.ToInt32(this.lblHarga3.Text);
                sub = harga1 * a + harga2 * b + harga3 * c;
                label1.Text = sub.ToString();
            }
        }

        private void btnMin3_Click(object sender, EventArgs e)
        {
            c--;
            btnPlus3.Enabled = true;
            if (c >= 0)
            {
                lblJumlah3.Text = c.ToString();
                sub = 0;

                if (dtdetailevent.Rows.Count == 1)
                {
                    int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                    sub = harga1 * a;
                    label1.Text = sub.ToString();
                }
                else if (dtdetailevent.Rows.Count == 2)
                {
                    int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                    int harga2 = Convert.ToInt32(this.lblHarga2.Text);
                    sub = harga1 * a + harga2 * b;
                    label1.Text = sub.ToString();
                }
                else if (dtdetailevent.Rows.Count == 3)
                {
                    int harga1 = Convert.ToInt32(this.lblHarga1.Text);
                    int harga2 = Convert.ToInt32(this.lblHarga2.Text);
                    int harga3 = Convert.ToInt32(this.lblHarga3.Text);
                    sub = harga1 * a + harga2 * b + harga3 * c;
                    label1.Text = sub.ToString();
                }
            }
            else
            {
                btnMin3.Enabled = false;
            }
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
