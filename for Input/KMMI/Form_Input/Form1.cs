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
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
        }
        public static int buat = 0;
        public FormLogin fLogin;
        public void init(FormMenu f)
        {
            fLogin = f.fLogin;
        }
        public static bool buatEventGratis = false;
        string imageLocation = "";
        public static DateTime dt1;
        public static bool a = false;
        string TanggalAwal1;
        string TanggalAkhir1;
        string TanggalAwal2;
        string TanggalAkhir2;
        string TanggalAwal3;
        string TanggalAkhir3;
        public static string NamaPenyelenggara = "";
        public static string DeskripsiPenyelenggara = "";
        public static string AlamatPenyelenggara = "";
        public static bool Profil = false;
        bool gambar = false;

        private void FormInput_Load(object sender, EventArgs e)
        {
            dtpWaktu.Format = DateTimePickerFormat.Custom;
            dtpWaktu.CustomFormat = "HH:mm";
            dtpWaktu.ShowUpDown = true;
            dtpWaktu2.Format = DateTimePickerFormat.Custom;
            dtpWaktu2.CustomFormat = "HH:mm";
            dtpWaktu2.ShowUpDown = true;
            dtpTanggal.MinDate = DateTime.Today;
          
            
            cboxLokasi.Items.Add("Event Online");
            cboxLokasi.Items.Add("Jakarta");
            cboxLokasi.Items.Add("Semarang");
            cboxLokasi.Items.Add("Surabaya");
            cboxLokasi.Items.Add("Bandung");
            cboxLokasi.Items.Add("Yogyakarta");
            

    
            
            cboxKategori.Items.Add("Sports");
            cboxKategori.Items.Add("Concert");
            cboxKategori.Items.Add("Exhibition");
            cboxKategori.Items.Add("Conference");
            cboxKategori.Items.Add("Workshop");
            cboxKategori.Items.Add("Attraction");
            
            
            

        }

        private void btnGambar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    gambar = true;
                    imageLocation = dialog.FileName;
                    pictureBoxGambar.ImageLocation = imageLocation;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTiketBayar_Click(object sender, EventArgs e)
        {
            
            FormBayar fb = new FormBayar();
            fb.ShowDialog();
            if(buat == 1 && a == true)
            {
                panelTiket1.Height = 55;
                lblNamaTiket1.Text = fb.NamaTiket;
                lblDeskripsi1.Text = fb.Deskripsi;
                lblHarga1.Text = fb.Harga;
                lblKapasitas1.Text = fb.Kapasitas;
                TanggalAwal1 = fb.Awal;
                TanggalAkhir1 = fb.Akhir;
            }
            if (buat == 2 && a == true)
            {
                panelTiket2.Height = 55;
                lblNamaTiket2.Text = fb.NamaTiket;
                lblDeskripsi2.Text = fb.Deskripsi;
                lblHarga2.Text = fb.Harga;
                lblKapasitas2.Text = fb.Kapasitas;
                TanggalAwal2 = fb.Awal;
                TanggalAkhir2 = fb.Akhir;
            }
            if (buat == 3 && a == true)
            {
                panelTiket3.Height = 55;
                lblNamaTiket3.Text = fb.NamaTiket;
                lblDeskripsi3.Text = fb.Deskripsi;
                lblHarga3.Text = fb.Harga;
                lblKapasitas3.Text = fb.Kapasitas;
                TanggalAwal3 = fb.Awal;
                TanggalAkhir3 = fb.Akhir;
            }
            a = false;
            
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            panelTiket1.Height = 0;
            panelTiket2.Height = 0;
            panelTiket3.Height = 0;
            buat = 0;
            lblNamaTiket1.Text = "";
            lblDeskripsi1.Text = "";
            lblHarga1.Text = "";
            lblKapasitas1.Text = "";
            lblNamaTiket2.Text = "";
            lblDeskripsi2.Text = "";
            lblHarga2.Text = "";
            lblKapasitas2.Text = "";
            lblNamaTiket3.Text = "";
            lblDeskripsi3.Text = "";
            lblHarga3.Text = "";
            lblKapasitas3.Text = "";
        }

        private void btnTiketGratis_Click(object sender, EventArgs e)
        {
            buatEventGratis = true;
            FormBayar fb = new FormBayar();
            fb.ShowDialog();
            
            if (buat == 1 && a == true)
            {
                panelTiket1.Height = 55;
                lblNamaTiket1.Text = fb.NamaTiket;
                lblDeskripsi1.Text = fb.Deskripsi;
                lblHarga1.Text = "0";
                lblKapasitas1.Text = fb.Kapasitas;
                TanggalAwal1 = fb.Awal;
                TanggalAkhir1 = fb.Akhir;
            }
            if (buat == 2 && a == true)
            {
                panelTiket2.Height = 55;
                lblNamaTiket2.Text = fb.NamaTiket;
                lblDeskripsi2.Text = fb.Deskripsi;
                lblHarga2.Text = "0";
                lblKapasitas2.Text = fb.Kapasitas;
                TanggalAwal2 = fb.Awal;
                TanggalAkhir2 = fb.Akhir;
            }
            if (buat == 3 && a == true)
            {
                panelTiket3.Height = 55;
                lblNamaTiket3.Text = fb.NamaTiket;
                lblDeskripsi3.Text = fb.Deskripsi;
                lblHarga3.Text = "0";
                lblKapasitas3.Text = fb.Kapasitas;
                TanggalAwal3 = fb.Awal;
                TanggalAkhir3 = fb.Akhir;
            }
            buatEventGratis = false;
            a = false;
        }

        private void tboxDeskripsi_TextChanged(object sender, EventArgs e)
        {
            string Total = "";
            Total = tboxDeskripsi.TextLength.ToString();
            lblTotal.Text = Total + "/300";
        }

        private void dtpTanggal_ValueChanged(object sender, EventArgs e)
        {
            dt1 = dtpTanggal.Value;
        }

        private void btnBuatEvent_Click(object sender, EventArgs e)
        {
            if (tboxJudul.Text != "" && cboxKategori.Text != "" && cboxLokasi.Text != "" && tboxDeskripsi.Text != "" && tboxAlamat.Text != "" && buat > 0 && Profil == true && gambar == true) 
            {
                try
                {

                    string waktu = dtpWaktu.Value.ToString("HH:mm") + "-" + dtpWaktu2.Value.ToString("HH:mm");
                    imageLocation = imageLocation.Replace("\\", "/");

                    MySqlCommand cmdins1 = new MySqlCommand();
                    cmdins1.Connection = fLogin.conn;
                    cmdins1.CommandText = "INSERT INTO penyelenggara (NAMA_P, ALAMAT_P, DESKRIPSI_P) VALUES ('" + NamaPenyelenggara + "', '" + AlamatPenyelenggara + "', '" + DeskripsiPenyelenggara + "')";
                    cmdins1.ExecuteNonQuery();

                    MySqlCommand cmdins2 = new MySqlCommand();
                    cmdins2.Connection = fLogin.conn;
                    cmdins2.CommandText = "INSERT INTO event_acara (JUDUL_EVENT, NAMA_P, TGL_EVENT, KATEGORI_EVENT, DESKRIPSI_EVENT, LOKASI_EVENT, ALAMAT_EVENT, WAKTU_EVENT, URL_EVENT) VALUES ('" + tboxJudul.Text + "', '" + NamaPenyelenggara + "', '" + dtpTanggal.Value.ToString("yyyy-MM-dd") + "', '" + cboxKategori.Text + "', '" + tboxDeskripsi.Text + "', '" + cboxLokasi.Text + "', '" + tboxAlamat.Text + "', '" + waktu + "', '" + imageLocation + "')";
                    cmdins2.ExecuteNonQuery();

                    if (buat >= 1)
                    {
                        MySqlCommand cmdins3 = new MySqlCommand();
                        cmdins3.Connection = fLogin.conn;
                        cmdins3.CommandText = "INSERT INTO tiket (KATEGORI_TIKET, JUDUL_EVENT, DESKRIPSI_TIKET, HARGA_TIKET, KAPASITAS, TIKET_TERJUAL, AWAL_TIKET, AKHIR_TIKET) VALUES ('" + lblNamaTiket1.Text + "', '" + tboxJudul.Text + "', '" + lblDeskripsi1.Text + "', '" + lblHarga1.Text + "', '" + lblKapasitas1.Text + "', '0','" + TanggalAwal1 + "', '" + TanggalAkhir1 + "')";
                        cmdins3.ExecuteNonQuery();
       
                    }
                    if (buat >= 2)
                    {
                        MySqlCommand cmdins4 = new MySqlCommand();
                        cmdins4.Connection = fLogin.conn;
                        cmdins4.CommandText = "INSERT INTO tiket (KATEGORI_TIKET, JUDUL_EVENT, DESKRIPSI_TIKET, HARGA_TIKET, KAPASITAS, TIKET_TERJUAL, AWAL_TIKET, AKHIR_TIKET) VALUES ('" + lblNamaTiket2.Text + "', '" + tboxJudul.Text + "', '" + lblDeskripsi2.Text + "', '" + lblHarga2.Text + "', '" + lblKapasitas2.Text + "', '0', '" + TanggalAwal2 + "', '" + TanggalAkhir2 + "')";
                        cmdins4.ExecuteNonQuery();
                    }
                    if (buat >= 3)
                    {
                        MySqlCommand cmdins5 = new MySqlCommand();
                        cmdins5.Connection = fLogin.conn;
                        cmdins5.CommandText = "INSERT INTO tiket (KATEGORI_TIKET, JUDUL_EVENT, DESKRIPSI_TIKET, HARGA_TIKET, KAPASITAS, TIKET_TERJUAL, AWAL_TIKET, AKHIR_TIKET) VALUES ('" + lblNamaTiket3.Text + "', '" + tboxJudul.Text + "', '" + lblDeskripsi3.Text + "', '" + lblHarga3.Text + "', '" + lblKapasitas3.Text + "', '0', '" + TanggalAwal3 + "', '" + TanggalAkhir3 + "')";
                        cmdins5.ExecuteNonQuery();
                    }
                    MessageBox.Show("Input Berhasil");
                    FormMenu fMenu = new FormMenu();
                    fMenu.init(this);
                    fMenu.ShowDialog();
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

        private void btnProfil_Click(object sender, EventArgs e)
        {
            FormProfil fp = new FormProfil();
            fp.ShowDialog();
        }
    }
}
