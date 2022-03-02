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
    public partial class FormCariEvent : System.Windows.Forms.Form
    {
        public FormCariEvent()
        {
            InitializeComponent();
        }
        MySqlConnection sqlConnect;
        MySqlCommand sqlCommand;
        MySqlDataAdapter sqlAdapter;
        string sqlQuery;
        string sqlQueryCoba;
        string connectString = "server=localhost;uid=root;pwd=;database=loketdotcom;";
        int TotalPage = 0;
        int PageSize = 8;
        int CurrentPageIndex = 1;
        int PageOffSet = 0;
        bool kurangdarilima = false;

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
            Querry();
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

        

        private void FormCariEvent_Load(object sender, EventArgs e)
        {
            lblNamaAtas.Text = FormLogin.simpanNama;
            cboxLokasi.Items.Add("Semua Lokasi");
            cboxLokasi.Items.Add("Event Online");
            cboxLokasi.Items.Add("Jakarta");
            cboxLokasi.Items.Add("Semarang");
            cboxLokasi.Items.Add("Surabaya");
            cboxLokasi.Items.Add("Bandung");
            cboxLokasi.Items.Add("Yogyakarta");
            cboxLokasi.Text = "Semua Lokasi";
            tboxSearch.Text = FormHome.simpansearch;
            dtpWaktu.MinDate = DateTime.Today;
            dtpWaktu.Value = DateTime.Today;
        }
        private void Querry()
        {
            panelEvent1.Visible = false;
            panelEvent2.Visible = false;
            panelEvent3.Visible = false;
            panelEvent4.Visible = false;
            panelEvent5.Visible = false;
            panelEvent6.Visible = false;
            panelEvent7.Visible = false;
            panelEvent8.Visible = false;
            sqlQueryCoba = "SELECT JUDUL_EVENT AS `Judul`, WAKTU_EVENT AS `Waktu`, LOKASI_EVENT AS `Lokasi`, URL_EVENT AS `Gambar`, NAMA_P AS `Penyelenggara` FROM event_acara WHERE JUDUL_EVENT LIKE '%" + tboxSearch.Text + "%' AND TGL_EVENT >= NOW()";
            if(rbutConcert.Checked == true)
            {
                sqlQueryCoba += " AND KATEGORI_EVENT = '" + rbutConcert.Text + "'";
            }
            if (rbutExhibition.Checked == true)
            {
                sqlQueryCoba += " AND KATEGORI_EVENT = '" + rbutExhibition.Text + "'";
            }
            if (rbutConference.Checked == true)
            {
                sqlQueryCoba += " AND KATEGORI_EVENT = '" + rbutConference.Text + "'";
            }
            if (rbutWorkshop.Checked == true)
            {
                sqlQueryCoba += " AND KATEGORI_EVENT = '" + rbutWorkshop.Text + "'";
            }
            if (rbutAttraction.Checked == true)
            {
                sqlQueryCoba += " AND KATEGORI_EVENT = '" + rbutAttraction.Text + "'";
            }
            if (rbutSports.Checked == true)
            {
                sqlQueryCoba += " AND KATEGORI_EVENT = '" + rbutSports.Text + "'";
            }
            if(cboxAll.Checked == false)
            {
                sqlQueryCoba += " AND TGL_EVENT = '" + dtpWaktu.Value.ToString("yyyy-MM-dd") + "'";
            }
            if(cboxLokasi.Text != "Semua Lokasi")
            {
                sqlQueryCoba += " AND LOKASI_EVENT = '" + cboxLokasi.Text + "'";
            }
            DataTable Event = new DataTable();
            sqlConnect = new MySqlConnection(connectString);
            sqlCommand = new MySqlCommand(sqlQueryCoba, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(Event);
            lblTotal.Text = Event.Rows.Count.ToString();
            TotalPage = Event.Rows.Count / 8;
            if (Event.Rows.Count % 8 > 0)
            {
                TotalPage += 1;
                
            }
            CurrentPageIndex = 1;
            PageOffSet = (CurrentPageIndex - 1) * PageSize;
            sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
            DataTable dtEvent = new DataTable();
            sqlConnect = new MySqlConnection(connectString);
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtEvent);
            if (dtEvent.Rows.Count >= 1)
            {
                panelEvent1.Visible = true;
                pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
            }
            if (dtEvent.Rows.Count >= 2)
            {
                panelEvent2.Visible = true;
                pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
            }
            if (dtEvent.Rows.Count >= 3)
            {
                panelEvent3.Visible = true;
                pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
            }
            if (dtEvent.Rows.Count >= 4)
            {
                panelEvent4.Visible = true;
                pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
            }
            if (dtEvent.Rows.Count >= 5)
            {
                panelEvent5.Visible = true;
                pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
            }
            if (dtEvent.Rows.Count >= 6)
            {
                panelEvent6.Visible = true;
                pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
            }
            if (dtEvent.Rows.Count >= 7)
            {
                panelEvent7.Visible = true;
                pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
            }
            if (dtEvent.Rows.Count >= 8)
            {
                panelEvent8.Visible = true;
                pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
            }
            if (TotalPage == 1)
            {
                
                kurangdarilima = true;
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnFirst.Visible = false;
                btnPrev.Visible = false;
                btnNow.Visible = true;
                btnNext.Visible = false;
                btnLast.Visible = false;
                btnNow.Text = "1";
                btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            }
            if (TotalPage == 2)
            {
                
                kurangdarilima = true;
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnFirst.Visible = false;
                btnPrev.Visible = true;
                btnNow.Visible = true;
                btnNext.Visible = false;
                btnLast.Visible = false;
                btnPrev.Text = "1";
                btnNow.Text = "2";
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            }
            if (TotalPage == 3)
            {
                
                kurangdarilima = true;
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnFirst.Visible = false;
                btnPrev.Visible = true;
                btnNow.Visible = true;
                btnNext.Visible = true;
                btnLast.Visible = false;
                btnPrev.Text = "1";
                btnNow.Text = "2";
                btnNext.Text = "3";
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            }
            if (TotalPage == 4)
            {
                
                kurangdarilima = true;
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnFirst.Visible = true;
                btnPrev.Visible = true;
                btnNow.Visible = true;
                btnNext.Visible = true;
                btnLast.Visible = false;
                btnFirst.Text = "1";
                btnPrev.Text = "2";
                btnNow.Text = "3";
                btnNext.Text = "4";
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            }
            if (TotalPage == 5)
            {
                
                kurangdarilima = true;
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnFirst.Visible = true;
                btnPrev.Visible = true;
                btnNow.Visible = true;
                btnNext.Visible = true;
                btnLast.Visible = true;
                btnFirst.Text = "1";
                btnPrev.Text = "2";
                btnNow.Text = "3";
                btnNext.Text = "4";
                btnLast.Text = "5";
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
            }
            if (TotalPage > 5)
            {
                
                kurangdarilima = false;
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnFirst.Visible = true;
                btnPrev.Visible = true;
                btnNow.Visible = true;
                btnNext.Visible = true;
                btnLast.Visible = true;
                btnFirst.Text = "1";
                btnPrev.Text = "2";
                btnNow.Text = "3";
                btnNext.Text = "4";
                btnLast.Text = ">>";
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);

            }
        }

        private void rbutConcert_CheckedChanged(object sender, EventArgs e)
        {
            Querry();
        }

        private void rbutSemua_CheckedChanged(object sender, EventArgs e)
        {
            Querry();
        }

        private void rbutExhibition_CheckedChanged(object sender, EventArgs e)
        {
            Querry();
        }

        private void rbutConference_CheckedChanged(object sender, EventArgs e)
        {
            Querry();
        }

        private void btnWorkshop_CheckedChanged(object sender, EventArgs e)
        {
            Querry();
        }

        private void btnAttraction_CheckedChanged(object sender, EventArgs e)
        {
            Querry();
        }

        private void rbutSports_CheckedChanged(object sender, EventArgs e)
        {
            Querry();
        }

        private void dtpWaktu_ValueChanged(object sender, EventArgs e)
        {
            Querry();
        }

        private void cboxLokasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Querry();
        }

        private void btnHapusFIlter_Click(object sender, EventArgs e)
        {
            rbutSemua.Checked = true;
            cboxAll.Checked = true;
            dtpWaktu.Value = DateTime.Today;
            cboxLokasi.Text = "Semua Lokasi";
            Querry();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = 1;
            if (kurangdarilima == false)
            {
                panelEvent1.Visible = false;
                panelEvent2.Visible = false;
                panelEvent3.Visible = false;
                panelEvent4.Visible = false;
                panelEvent5.Visible = false;
                panelEvent6.Visible = false;
                panelEvent7.Visible = false;
                panelEvent8.Visible = false;
                btnFirst.Text = "1";
                btnPrev.Text = "2";
                btnNow.Text = "3";
                btnNext.Text = "4";
                btnLast.Text = ">>";
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                PageOffSet = (CurrentPageIndex - 1) * PageSize;
                sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                DataTable dtEvent = new DataTable();
                sqlConnect = new MySqlConnection(connectString);
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtEvent);
                if (dtEvent.Rows.Count >= 1)
                {
                    panelEvent1.Visible = true;
                    pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                    lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                    lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                    lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                    lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 2)
                {
                    panelEvent2.Visible = true;
                    pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                    lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                    lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                    lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                    lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 3)
                {
                    panelEvent3.Visible = true;
                    pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                    lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                    lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                    lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                    lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 4)
                {
                    panelEvent4.Visible = true;
                    pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                    lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                    lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                    lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                    lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 5)
                {
                    panelEvent5.Visible = true;
                    pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                    lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                    lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                    lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                    lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 6)
                {
                    panelEvent6.Visible = true;
                    pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                    lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                    lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                    lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                    lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 7)
                {
                    panelEvent7.Visible = true;
                    pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                    lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                    lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                    lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                    lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 8)
                {
                    panelEvent8.Visible = true;
                    pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                    lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                    lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                    lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                    lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                }
            }
            else
            {
                panelEvent1.Visible = false;
                panelEvent2.Visible = false;
                panelEvent3.Visible = false;
                panelEvent4.Visible = false;
                panelEvent5.Visible = false;
                panelEvent6.Visible = false;
                panelEvent7.Visible = false;
                panelEvent8.Visible = false;
                CurrentPageIndex = Convert.ToInt32(btnFirst.Text);
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                PageOffSet = (CurrentPageIndex - 1) * PageSize;
                sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                DataTable dtEvent = new DataTable();
                sqlConnect = new MySqlConnection(connectString);
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtEvent);
                if (dtEvent.Rows.Count >= 1)
                {
                    panelEvent1.Visible = true;
                    pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                    lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                    lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                    lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                    lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 2)
                {
                    panelEvent2.Visible = true;
                    pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                    lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                    lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                    lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                    lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 3)
                {
                    panelEvent3.Visible = true;
                    pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                    lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                    lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                    lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                    lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 4)
                {
                    panelEvent4.Visible = true;
                    pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                    lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                    lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                    lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                    lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 5)
                {
                    panelEvent5.Visible = true;
                    pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                    lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                    lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                    lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                    lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 6)
                {
                    panelEvent6.Visible = true;
                    pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                    lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                    lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                    lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                    lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 7)
                {
                    panelEvent7.Visible = true;
                    pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                    lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                    lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                    lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                    lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 8)
                {
                    panelEvent8.Visible = true;
                    pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                    lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                    lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                    lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                    lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = Convert.ToInt32(btnPrev.Text);
            if (kurangdarilima == false)
            {
                if (CurrentPageIndex == 3)
                {
                    panelEvent1.Visible = false;
                    panelEvent2.Visible = false;
                    panelEvent3.Visible = false;
                    panelEvent4.Visible = false;
                    panelEvent5.Visible = false;
                    panelEvent6.Visible = false;
                    panelEvent7.Visible = false;
                    panelEvent8.Visible = false;
                    btnFirst.Text = "1";
                    btnPrev.Text = (Convert.ToInt32(btnPrev.Text) - 1).ToString();
                    btnNow.Text = (Convert.ToInt32(btnNow.Text) - 1).ToString();
                    btnNext.Text = (Convert.ToInt32(btnNext.Text) - 1).ToString();
                    btnLast.Text = ">>";
                    btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    PageOffSet = (CurrentPageIndex - 1) * PageSize;
                    sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                    DataTable dtEvent = new DataTable();
                    sqlConnect = new MySqlConnection(connectString);
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtEvent);
                    if (dtEvent.Rows.Count >= 1)
                    {
                        panelEvent1.Visible = true;
                        pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                        lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                        lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                        lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                        lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 2)
                    {
                        panelEvent2.Visible = true;
                        pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                        lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                        lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                        lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                        lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 3)
                    {
                        panelEvent3.Visible = true;
                        pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                        lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                        lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                        lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                        lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 4)
                    {
                        panelEvent4.Visible = true;
                        pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                        lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                        lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                        lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                        lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 5)
                    {
                        panelEvent5.Visible = true;
                        pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                        lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                        lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                        lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                        lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 6)
                    {
                        panelEvent6.Visible = true;
                        pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                        lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                        lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                        lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                        lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 7)
                    {
                        panelEvent7.Visible = true;
                        pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                        lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                        lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                        lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                        lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 8)
                    {
                        panelEvent8.Visible = true;
                        pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                        lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                        lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                        lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                        lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                    }
                }
                else if (CurrentPageIndex == 2)
                {
                    panelEvent1.Visible = false;
                    panelEvent2.Visible = false;
                    panelEvent3.Visible = false;
                    panelEvent4.Visible = false;
                    panelEvent5.Visible = false;
                    panelEvent6.Visible = false;
                    panelEvent7.Visible = false;
                    panelEvent8.Visible = false;
                    btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    PageOffSet = (CurrentPageIndex - 1) * PageSize;
                    sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                    DataTable dtEvent = new DataTable();
                    sqlConnect = new MySqlConnection(connectString);
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtEvent);
                    if (dtEvent.Rows.Count >= 1)
                    {
                        panelEvent1.Visible = true;
                        pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                        lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                        lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                        lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                        lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 2)
                    {
                        panelEvent2.Visible = true;
                        pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                        lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                        lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                        lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                        lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 3)
                    {
                        panelEvent3.Visible = true;
                        pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                        lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                        lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                        lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                        lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 4)
                    {
                        panelEvent4.Visible = true;
                        pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                        lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                        lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                        lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                        lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 5)
                    {
                        panelEvent5.Visible = true;
                        pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                        lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                        lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                        lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                        lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 6)
                    {
                        panelEvent6.Visible = true;
                        pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                        lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                        lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                        lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                        lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 7)
                    {
                        panelEvent7.Visible = true;
                        pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                        lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                        lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                        lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                        lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 8)
                    {
                        panelEvent8.Visible = true;
                        pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                        lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                        lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                        lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                        lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                    }
                }
                else
                {
                    panelEvent1.Visible = false;
                    panelEvent2.Visible = false;
                    panelEvent3.Visible = false;
                    panelEvent4.Visible = false;
                    panelEvent5.Visible = false;
                    panelEvent6.Visible = false;
                    panelEvent7.Visible = false;
                    panelEvent8.Visible = false;
                    btnFirst.Text = "<<";
                    btnPrev.Text = (Convert.ToInt32(btnPrev.Text) - 1).ToString();
                    btnNow.Text = (Convert.ToInt32(btnNow.Text) - 1).ToString();
                    btnNext.Text = (Convert.ToInt32(btnNext.Text) - 1).ToString();
                    btnLast.Text = ">>";
                    btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    PageOffSet = (CurrentPageIndex - 1) * PageSize;
                    sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                    DataTable dtEvent = new DataTable();
                    sqlConnect = new MySqlConnection(connectString);
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtEvent);
                    if (dtEvent.Rows.Count >= 1)
                    {
                        panelEvent1.Visible = true;
                        pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                        lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                        lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                        lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                        lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 2)
                    {
                        panelEvent2.Visible = true;
                        pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                        lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                        lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                        lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                        lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 3)
                    {
                        panelEvent3.Visible = true;
                        pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                        lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                        lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                        lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                        lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 4)
                    {
                        panelEvent4.Visible = true;
                        pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                        lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                        lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                        lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                        lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 5)
                    {
                        panelEvent5.Visible = true;
                        pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                        lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                        lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                        lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                        lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 6)
                    {
                        panelEvent6.Visible = true;
                        pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                        lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                        lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                        lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                        lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 7)
                    {
                        panelEvent7.Visible = true;
                        pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                        lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                        lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                        lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                        lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 8)
                    {
                        panelEvent8.Visible = true;
                        pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                        lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                        lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                        lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                        lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                    }
                }
            }
            else
            {
                panelEvent1.Visible = false;
                panelEvent2.Visible = false;
                panelEvent3.Visible = false;
                panelEvent4.Visible = false;
                panelEvent5.Visible = false;
                panelEvent6.Visible = false;
                panelEvent7.Visible = false;
                panelEvent8.Visible = false;
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                PageOffSet = (CurrentPageIndex - 1) * PageSize;
                sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                DataTable dtEvent = new DataTable();
                sqlConnect = new MySqlConnection(connectString);
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtEvent);
                if (dtEvent.Rows.Count >= 1)
                {
                    panelEvent1.Visible = true;
                    pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                    lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                    lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                    lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                    lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 2)
                {
                    panelEvent2.Visible = true;
                    pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                    lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                    lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                    lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                    lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 3)
                {
                    panelEvent3.Visible = true;
                    pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                    lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                    lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                    lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                    lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 4)
                {
                    panelEvent4.Visible = true;
                    pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                    lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                    lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                    lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                    lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 5)
                {
                    panelEvent5.Visible = true;
                    pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                    lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                    lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                    lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                    lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 6)
                {
                    panelEvent6.Visible = true;
                    pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                    lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                    lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                    lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                    lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 7)
                {
                    panelEvent7.Visible = true;
                    pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                    lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                    lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                    lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                    lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 8)
                {
                    panelEvent8.Visible = true;
                    pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                    lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                    lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                    lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                    lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = Convert.ToInt32(btnNext.Text);
            if (kurangdarilima == false)
            {
                if (CurrentPageIndex == TotalPage - 2)
                {
                    panelEvent1.Visible = false;
                    panelEvent2.Visible = false;
                    panelEvent3.Visible = false;
                    panelEvent4.Visible = false;
                    panelEvent5.Visible = false;
                    panelEvent6.Visible = false;
                    panelEvent7.Visible = false;
                    panelEvent8.Visible = false;
                    btnFirst.Text = "<<";
                    btnPrev.Text = (Convert.ToInt32(btnPrev.Text) + 1).ToString();
                    btnNow.Text = (Convert.ToInt32(btnNow.Text) + 1).ToString();
                    btnNext.Text = (Convert.ToInt32(btnNext.Text) + 1).ToString();
                    btnLast.Text = TotalPage.ToString();
                    btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    PageOffSet = (CurrentPageIndex - 1) * PageSize;
                    sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                    DataTable dtEvent = new DataTable();
                    sqlConnect = new MySqlConnection(connectString);
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtEvent);
                    if (dtEvent.Rows.Count >= 1)
                    {
                        panelEvent1.Visible = true;
                        pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                        lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                        lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                        lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                        lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 2)
                    {
                        panelEvent2.Visible = true;
                        pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                        lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                        lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                        lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                        lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 3)
                    {
                        panelEvent3.Visible = true;
                        pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                        lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                        lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                        lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                        lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 4)
                    {
                        panelEvent4.Visible = true;
                        pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                        lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                        lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                        lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                        lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 5)
                    {
                        panelEvent5.Visible = true;
                        pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                        lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                        lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                        lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                        lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 6)
                    {
                        panelEvent6.Visible = true;
                        pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                        lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                        lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                        lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                        lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 7)
                    {
                        panelEvent7.Visible = true;
                        pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                        lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                        lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                        lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                        lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 8)
                    {
                        panelEvent8.Visible = true;
                        pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                        lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                        lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                        lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                        lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                    }
                }
                else if (CurrentPageIndex == TotalPage - 1)
                {
                    panelEvent1.Visible = false;
                    panelEvent2.Visible = false;
                    panelEvent3.Visible = false;
                    panelEvent4.Visible = false;
                    panelEvent5.Visible = false;
                    panelEvent6.Visible = false;
                    panelEvent7.Visible = false;
                    panelEvent8.Visible = false;
                    btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    PageOffSet = (CurrentPageIndex - 1) * PageSize;
                    sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                    DataTable dtEvent = new DataTable();
                    sqlConnect = new MySqlConnection(connectString);
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtEvent);
                    if (dtEvent.Rows.Count >= 1)
                    {
                        panelEvent1.Visible = true;
                        pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                        lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                        lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                        lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                        lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 2)
                    {
                        panelEvent2.Visible = true;
                        pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                        lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                        lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                        lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                        lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 3)
                    {
                        panelEvent3.Visible = true;
                        pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                        lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                        lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                        lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                        lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 4)
                    {
                        panelEvent4.Visible = true;
                        pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                        lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                        lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                        lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                        lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 5)
                    {
                        panelEvent5.Visible = true;
                        pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                        lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                        lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                        lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                        lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 6)
                    {
                        panelEvent6.Visible = true;
                        pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                        lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                        lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                        lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                        lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 7)
                    {
                        panelEvent7.Visible = true;
                        pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                        lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                        lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                        lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                        lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 8)
                    {
                        panelEvent8.Visible = true;
                        pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                        lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                        lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                        lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                        lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                    }
                }
                else
                {
                    panelEvent1.Visible = false;
                    panelEvent2.Visible = false;
                    panelEvent3.Visible = false;
                    panelEvent4.Visible = false;
                    panelEvent5.Visible = false;
                    panelEvent6.Visible = false;
                    panelEvent7.Visible = false;
                    panelEvent8.Visible = false;
                    btnFirst.Text = "<<";
                    btnPrev.Text = (Convert.ToInt32(btnPrev.Text) + 1).ToString();
                    btnNow.Text = (Convert.ToInt32(btnNow.Text) + 1).ToString();
                    btnNext.Text = (Convert.ToInt32(btnNext.Text) + 1).ToString();
                    btnLast.Text = ">>";
                    btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    PageOffSet = (CurrentPageIndex - 1) * PageSize;
                    sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                    DataTable dtEvent = new DataTable();
                    sqlConnect = new MySqlConnection(connectString);
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtEvent);
                    if (dtEvent.Rows.Count >= 1)
                    {
                        panelEvent1.Visible = true;
                        pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                        lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                        lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                        lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                        lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 2)
                    {
                        panelEvent2.Visible = true;
                        pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                        lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                        lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                        lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                        lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 3)
                    {
                        panelEvent3.Visible = true;
                        pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                        lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                        lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                        lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                        lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 4)
                    {
                        panelEvent4.Visible = true;
                        pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                        lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                        lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                        lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                        lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 5)
                    {
                        panelEvent5.Visible = true;
                        pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                        lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                        lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                        lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                        lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 6)
                    {
                        panelEvent6.Visible = true;
                        pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                        lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                        lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                        lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                        lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 7)
                    {
                        panelEvent7.Visible = true;
                        pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                        lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                        lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                        lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                        lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 8)
                    {
                        panelEvent8.Visible = true;
                        pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                        lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                        lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                        lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                        lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                    }
                }
            }
            else
            {
                panelEvent1.Visible = false;
                panelEvent2.Visible = false;
                panelEvent3.Visible = false;
                panelEvent4.Visible = false;
                panelEvent5.Visible = false;
                panelEvent6.Visible = false;
                panelEvent7.Visible = false;
                panelEvent8.Visible = false;
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                PageOffSet = (CurrentPageIndex - 1) * PageSize;
                sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                DataTable dtEvent = new DataTable();
                sqlConnect = new MySqlConnection(connectString);
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtEvent);
                if (dtEvent.Rows.Count >= 1)
                {
                    panelEvent1.Visible = true;
                    pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                    lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                    lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                    lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                    lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 2)
                {
                    panelEvent2.Visible = true;
                    pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                    lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                    lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                    lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                    lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 3)
                {
                    panelEvent3.Visible = true;
                    pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                    lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                    lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                    lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                    lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 4)
                {
                    panelEvent4.Visible = true;
                    pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                    lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                    lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                    lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                    lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 5)
                {
                    panelEvent5.Visible = true;
                    pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                    lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                    lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                    lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                    lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 6)
                {
                    panelEvent6.Visible = true;
                    pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                    lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                    lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                    lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                    lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 7)
                {
                    panelEvent7.Visible = true;
                    pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                    lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                    lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                    lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                    lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 8)
                {
                    panelEvent8.Visible = true;
                    pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                    lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                    lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                    lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                    lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                }
            }
        }

        private void btnNow_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = Convert.ToInt32(btnNow.Text);
            if (kurangdarilima == false)
            {
                if (CurrentPageIndex == 3 || CurrentPageIndex == TotalPage - 2)
                {
                    panelEvent1.Visible = false;
                    panelEvent2.Visible = false;
                    panelEvent3.Visible = false;
                    panelEvent4.Visible = false;
                    panelEvent5.Visible = false;
                    panelEvent6.Visible = false;
                    panelEvent7.Visible = false;
                    panelEvent8.Visible = false;
                    btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                    PageOffSet = (CurrentPageIndex - 1) * PageSize;
                    sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                    DataTable dtEvent = new DataTable();
                    sqlConnect = new MySqlConnection(connectString);
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlAdapter = new MySqlDataAdapter(sqlCommand);
                    sqlAdapter.Fill(dtEvent);
                    if (dtEvent.Rows.Count >= 1)
                    {
                        panelEvent1.Visible = true;
                        pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                        lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                        lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                        lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                        lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 2)
                    {
                        panelEvent2.Visible = true;
                        pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                        lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                        lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                        lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                        lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 3)
                    {
                        panelEvent3.Visible = true;
                        pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                        lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                        lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                        lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                        lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 4)
                    {
                        panelEvent4.Visible = true;
                        pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                        lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                        lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                        lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                        lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 5)
                    {
                        panelEvent5.Visible = true;
                        pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                        lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                        lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                        lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                        lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 6)
                    {
                        panelEvent6.Visible = true;
                        pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                        lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                        lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                        lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                        lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 7)
                    {
                        panelEvent7.Visible = true;
                        pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                        lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                        lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                        lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                        lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                    }
                    if (dtEvent.Rows.Count >= 8)
                    {
                        panelEvent8.Visible = true;
                        pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                        lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                        lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                        lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                        lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                    }
                }
                else
                {

                }
            }
            else
            {
                panelEvent1.Visible = false;
                panelEvent2.Visible = false;
                panelEvent3.Visible = false;
                panelEvent4.Visible = false;
                panelEvent5.Visible = false;
                panelEvent6.Visible = false;
                panelEvent7.Visible = false;
                panelEvent8.Visible = false;
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                PageOffSet = (CurrentPageIndex - 1) * PageSize;
                sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                DataTable dtEvent = new DataTable();
                sqlConnect = new MySqlConnection(connectString);
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtEvent);
                if (dtEvent.Rows.Count >= 1)
                {
                    panelEvent1.Visible = true;
                    pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                    lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                    lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                    lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                    lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 2)
                {
                    panelEvent2.Visible = true;
                    pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                    lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                    lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                    lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                    lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 3)
                {
                    panelEvent3.Visible = true;
                    pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                    lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                    lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                    lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                    lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 4)
                {
                    panelEvent4.Visible = true;
                    pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                    lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                    lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                    lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                    lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 5)
                {
                    panelEvent5.Visible = true;
                    pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                    lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                    lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                    lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                    lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 6)
                {
                    panelEvent6.Visible = true;
                    pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                    lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                    lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                    lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                    lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 7)
                {
                    panelEvent7.Visible = true;
                    pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                    lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                    lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                    lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                    lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 8)
                {
                    panelEvent8.Visible = true;
                    pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                    lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                    lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                    lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                    lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = TotalPage;
            if (kurangdarilima == false)
            {
                panelEvent1.Visible = false;
                panelEvent2.Visible = false;
                panelEvent3.Visible = false;
                panelEvent4.Visible = false;
                panelEvent5.Visible = false;
                panelEvent6.Visible = false;
                panelEvent7.Visible = false;
                panelEvent8.Visible = false;
                btnFirst.Text = "<<";
                btnPrev.Text = (CurrentPageIndex - 3).ToString();
                btnNow.Text = (CurrentPageIndex - 2).ToString();
                btnNext.Text = (CurrentPageIndex - 1).ToString();
                btnLast.Text = CurrentPageIndex.ToString();
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                PageOffSet = (CurrentPageIndex - 1) * PageSize;
                sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                DataTable dtEvent = new DataTable();
                sqlConnect = new MySqlConnection(connectString);
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtEvent);
                if (dtEvent.Rows.Count >= 1)
                {
                    panelEvent1.Visible = true;
                    pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                    lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                    lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                    lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                    lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 2)
                {
                    panelEvent2.Visible = true;
                    pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                    lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                    lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                    lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                    lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 3)
                {
                    panelEvent3.Visible = true;
                    pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                    lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                    lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                    lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                    lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 4)
                {
                    panelEvent4.Visible = true;
                    pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                    lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                    lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                    lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                    lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 5)
                {
                    panelEvent5.Visible = true;
                    pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                    lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                    lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                    lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                    lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 6)
                {
                    panelEvent6.Visible = true;
                    pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                    lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                    lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                    lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                    lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 7)
                {
                    panelEvent7.Visible = true;
                    pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                    lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                    lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                    lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                    lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 8)
                {
                    panelEvent8.Visible = true;
                    pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                    lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                    lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                    lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                    lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                }
            }
            else
            {
                panelEvent1.Visible = false;
                panelEvent2.Visible = false;
                panelEvent3.Visible = false;
                panelEvent4.Visible = false;
                panelEvent5.Visible = false;
                panelEvent6.Visible = false;
                panelEvent7.Visible = false;
                panelEvent8.Visible = false;
                CurrentPageIndex = Convert.ToInt32(btnLast.Text);
                btnFirst.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnPrev.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnNext.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                btnLast.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);
                btnNow.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                PageOffSet = (CurrentPageIndex - 1) * PageSize;
                sqlQuery = sqlQueryCoba + " LIMIT " + PageOffSet + ", 8";
                DataTable dtEvent = new DataTable();
                sqlConnect = new MySqlConnection(connectString);
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtEvent);
                if (dtEvent.Rows.Count >= 1)
                {
                    panelEvent1.Visible = true;
                    pbox1.ImageLocation = dtEvent.Rows[0]["Gambar"].ToString();
                    lblJudul1.Text = dtEvent.Rows[0]["Judul"].ToString();
                    lblWaktu1.Text = dtEvent.Rows[0]["Waktu"].ToString();
                    lblLokasi1.Text = dtEvent.Rows[0]["Lokasi"].ToString();
                    lblPenyelenggara1.Text = dtEvent.Rows[0]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 2)
                {
                    panelEvent2.Visible = true;
                    pbox2.ImageLocation = dtEvent.Rows[1]["Gambar"].ToString();
                    lblJudul2.Text = dtEvent.Rows[1]["Judul"].ToString();
                    lblWaktu2.Text = dtEvent.Rows[1]["Waktu"].ToString();
                    lblLokasi2.Text = dtEvent.Rows[1]["Lokasi"].ToString();
                    lblPenyelenggara2.Text = dtEvent.Rows[1]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 3)
                {
                    panelEvent3.Visible = true;
                    pbox3.ImageLocation = dtEvent.Rows[2]["Gambar"].ToString();
                    lblJudul3.Text = dtEvent.Rows[2]["Judul"].ToString();
                    lblWaktu3.Text = dtEvent.Rows[2]["Waktu"].ToString();
                    lblLokasi3.Text = dtEvent.Rows[2]["Lokasi"].ToString();
                    lblPenyelenggara3.Text = dtEvent.Rows[2]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 4)
                {
                    panelEvent4.Visible = true;
                    pbox4.ImageLocation = dtEvent.Rows[3]["Gambar"].ToString();
                    lblJudul4.Text = dtEvent.Rows[3]["Judul"].ToString();
                    lblWaktu4.Text = dtEvent.Rows[3]["Waktu"].ToString();
                    lblLokasi4.Text = dtEvent.Rows[3]["Lokasi"].ToString();
                    lblPenyelenggara4.Text = dtEvent.Rows[3]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 5)
                {
                    panelEvent5.Visible = true;
                    pbox5.ImageLocation = dtEvent.Rows[4]["Gambar"].ToString();
                    lblJudul5.Text = dtEvent.Rows[4]["Judul"].ToString();
                    lblWaktu5.Text = dtEvent.Rows[4]["Waktu"].ToString();
                    lblLokasi5.Text = dtEvent.Rows[4]["Lokasi"].ToString();
                    lblPenyelenggara5.Text = dtEvent.Rows[4]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 6)
                {
                    panelEvent6.Visible = true;
                    pbox6.ImageLocation = dtEvent.Rows[5]["Gambar"].ToString();
                    lblJudul6.Text = dtEvent.Rows[5]["Judul"].ToString();
                    lblWaktu6.Text = dtEvent.Rows[5]["Waktu"].ToString();
                    lblLokasi6.Text = dtEvent.Rows[5]["Lokasi"].ToString();
                    lblPenyelenggara6.Text = dtEvent.Rows[5]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 7)
                {
                    panelEvent7.Visible = true;
                    pbox7.ImageLocation = dtEvent.Rows[6]["Gambar"].ToString();
                    lblJudul7.Text = dtEvent.Rows[6]["Judul"].ToString();
                    lblWaktu7.Text = dtEvent.Rows[6]["Waktu"].ToString();
                    lblLokasi7.Text = dtEvent.Rows[6]["Lokasi"].ToString();
                    lblPenyelenggara7.Text = dtEvent.Rows[6]["Penyelenggara"].ToString();
                }
                if (dtEvent.Rows.Count >= 8)
                {
                    panelEvent8.Visible = true;
                    pbox8.ImageLocation = dtEvent.Rows[7]["Gambar"].ToString();
                    lblJudul8.Text = dtEvent.Rows[7]["Judul"].ToString();
                    lblWaktu8.Text = dtEvent.Rows[7]["Waktu"].ToString();
                    lblLokasi8.Text = dtEvent.Rows[7]["Lokasi"].ToString();
                    lblPenyelenggara8.Text = dtEvent.Rows[7]["Penyelenggara"].ToString();
                }
            }
        }

        private void btnBeli1_Click(object sender, EventArgs e)
        {
            FormHome.simpanjudul = lblJudul1.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
        }

        private void btnBeli2_Click(object sender, EventArgs e)
        {
            FormHome.simpanjudul = lblJudul2.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
        }

        private void btnBeli3_Click(object sender, EventArgs e)
        {
            FormHome.simpanjudul = lblJudul3.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
        }

        private void btnBeli4_Click(object sender, EventArgs e)
        {
            FormHome.simpanjudul = lblJudul4.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
        }

        private void btnBeli5_Click(object sender, EventArgs e)
        {
            FormHome.simpanjudul = lblJudul5.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
        }

        private void btnBeli6_Click(object sender, EventArgs e)
        {
            FormHome.simpanjudul = lblJudul6.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
        }

        private void btnBeli7_Click(object sender, EventArgs e)
        {
            FormHome.simpanjudul = lblJudul7.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
        }

        private void btnBeli8_Click(object sender, EventArgs e)
        {
            FormHome.simpanjudul = lblJudul8.Text;
            this.Hide();
            FormDetail fd = new FormDetail();
            fd.ShowDialog();
        }

        private void cboxAll_CheckedChanged(object sender, EventArgs e)
        {
            if(cboxAll.Checked == true)
            {
                dtpWaktu.Enabled = false;
            }
            if(cboxAll.Checked == false)
            {
                dtpWaktu.Enabled = true;
            }
            Querry();
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
