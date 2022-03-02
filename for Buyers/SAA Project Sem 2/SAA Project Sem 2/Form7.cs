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
    public partial class FormCheckout : System.Windows.Forms.Form
    {
        public FormCheckout()
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
        public static string kode = "";
        public static string total = "";
 

        private void btnBayar_Click(object sender, EventArgs e)
        {
            try
            { 
                
                string idTrans = "INV";
                sqlQuery = "SELECT * FROM transaksi_beli_tiket";
                DataTable dtTrans = new DataTable();
                sqlConnect = new MySqlConnection(connectString);
                sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtTrans);
               
               
                    int jumlahTransaksi = dtTrans.Rows.Count + 1;
                    if (jumlahTransaksi < 10)
                    {
                        idTrans += "000";
                        idTrans += jumlahTransaksi.ToString();
                    }
                    else if (jumlahTransaksi >= 10 && jumlahTransaksi < 100)
                    {
                        idTrans += "00";
                        idTrans += jumlahTransaksi.ToString();
                    }
                    else if (jumlahTransaksi >= 100 && jumlahTransaksi < 1000)
                    {
                        idTrans += "0";
                        idTrans += jumlahTransaksi.ToString();
                    }
                    else
                    {
                        idTrans += jumlahTransaksi.ToString();
                    }
                    DateTime dtnow = DateTime.Now;
                    sqlConnect = new MySqlConnection(connectString);
                    //Metode pembayaran masih ovo
                    sqlQuery = "INSERT INTO transaksi_beli_tiket VALUES ('" + idTrans + "', '" + FormLogin.simpanUser + "', '" + lblJudul.Text + "', '" + dtnow.ToString("yyyy-MM-dd") + "', '" + labelTotal.Text + "', 'OVO')";
                    sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                    sqlConnect.Open();
                    sqlCommand.ExecuteNonQuery();
                    sqlConnect.Close();
                    kode = idTrans;
                    total = labelTotal.Text;
                    if (FormDetail.d == 1)
                    {
                        sqlConnect = new MySqlConnection(connectString);
                        sqlQuery = "INSERT INTO detail_trans_beli_tiket VALUES ('" + idTrans + "', '" + labelNamaTiket1.Text + "', '" + labelJumlah1.Text + "', '" + labelHarga1.Text + "')";
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlConnect.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnect.Close();
                        sqlQuery = "select e.JUDUL_EVENT as `Judul`, KATEGORI_EVENT as `Kategori`, NAMA_P as `Penyelenggara`, WAKTU_EVENT as `Waktu`, concat(lokasi_event, ', ', alamat_event) as `Lokasi`, KATEGORI_TIKET as `Nama Tiket`, DESKRIPSI_TIKET as `Deskripsi Tiket`, HARGA_TIKET as `Harga`, DESKRIPSI_EVENT as `Deskripsi Event`, concat('Batas beli tiket: ', akhir_tiket) as `Akhir Tiket`, URL_EVENT as `URL`, TIKET_TERJUAL AS `Terjual` from event_acara e, tiket t where e.JUDUL_EVENT = t.JUDUL_EVENT and e.JUDUL_EVENT = '" + FormHome.simpanjudul.ToString() + "' AND KATEGORI_TIKET = '" + labelNamaTiket1.Text + "';";
                        DataTable dtTiket = new DataTable();
                        sqlConnect = new MySqlConnection(connectString);
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlAdapter = new MySqlDataAdapter(sqlCommand);
                        sqlAdapter.Fill(dtTiket);
                        String TiketTerjual1 = dtTiket.Rows[0]["Terjual"].ToString();
                        if (FormDetail.a > 0)
                        {
                            TiketTerjual1 = TiketTerjual1 + FormDetail.a;
                        }
                        if (FormDetail.b > 0)
                        {
                            TiketTerjual1 = TiketTerjual1 + FormDetail.b;
                        }
                        if (FormDetail.c > 0)
                        {
                            TiketTerjual1 = TiketTerjual1 + FormDetail.c;
                        }
                        sqlConnect = new MySqlConnection(connectString);
                        sqlQuery = "UPDATE tiket SET TIKET_TERJUAL = '" + TiketTerjual1 + "' WHERE KATEGORI_TIKET = '" + labelNamaTiket1.Text + "'";
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlConnect.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnect.Close();
                    }
                    if (FormDetail.d == 2)
                    {
                        sqlConnect = new MySqlConnection(connectString);
                        sqlQuery = "INSERT INTO detail_trans_beli_tiket VALUES ('" + idTrans + "', '" + labelNamaTiket1.Text + "', '" + labelJumlah1.Text + "', '" + labelHarga1.Text + "')";
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlConnect.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnect.Close();
                        sqlConnect = new MySqlConnection(connectString);
                        sqlQuery = "INSERT INTO detail_trans_beli_tiket VALUES ('" + idTrans + "', '" + labelNamaTiket2.Text + "', '" + labelJumlah2.Text + "', '" + labelHarga2.Text + "')";
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlConnect.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnect.Close();
                        sqlQuery = "select e.JUDUL_EVENT as `Judul`, KATEGORI_EVENT as `Kategori`, NAMA_P as `Penyelenggara`, WAKTU_EVENT as `Waktu`, concat(lokasi_event, ', ', alamat_event) as `Lokasi`, KATEGORI_TIKET as `Nama Tiket`, DESKRIPSI_TIKET as `Deskripsi Tiket`, HARGA_TIKET as `Harga`, DESKRIPSI_EVENT as `Deskripsi Event`, concat('Batas beli tiket: ', akhir_tiket) as `Akhir Tiket`, URL_EVENT as `URL`, TIKET_TERJUAL AS `Terjual` from event_acara e, tiket t where e.JUDUL_EVENT = t.JUDUL_EVENT and e.JUDUL_EVENT = '" + FormHome.simpanjudul.ToString() + "' AND (KATEGORI_TIKET = '" + labelNamaTiket1.Text + "' OR KATEGORI_TIKET = '" + labelNamaTiket2.Text + "');";
                        DataTable dtTiket = new DataTable();
                        sqlConnect = new MySqlConnection(connectString);
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlAdapter = new MySqlDataAdapter(sqlCommand);
                        sqlAdapter.Fill(dtTiket);
                        String TiketTerjual1 = dtTiket.Rows[0]["Terjual"].ToString();
                        String TiketTerjual2 = dtTiket.Rows[1]["Terjual"].ToString();
                        if (FormDetail.a > 0 && FormDetail.b > 0)
                        {
                            TiketTerjual1 = TiketTerjual1 + FormDetail.a;
                            TiketTerjual2 = TiketTerjual2 + FormDetail.b;
                        }
                        if (FormDetail.a > 0 && FormDetail.c > 0)
                        {
                            TiketTerjual1 = TiketTerjual1 + FormDetail.a;
                            TiketTerjual2 = TiketTerjual2 + FormDetail.c;
                        }
                        if (FormDetail.b > 0 && FormDetail.c > 0)
                        {
                            TiketTerjual1 = TiketTerjual1 + FormDetail.b;
                            TiketTerjual2 = TiketTerjual2 + FormDetail.c;
                        }
                        sqlConnect = new MySqlConnection(connectString);
                        sqlQuery = "UPDATE tiket SET TIKET_TERJUAL = '" + TiketTerjual1 + "' WHERE KATEGORI_TIKET = '" + labelNamaTiket1.Text + "'";
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlConnect.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnect.Close();
                        sqlConnect = new MySqlConnection(connectString);
                        sqlQuery = "UPDATE tiket SET TIKET_TERJUAL = '" + TiketTerjual2 + "' WHERE KATEGORI_TIKET = '" + labelNamaTiket2.Text + "'";
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlConnect.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnect.Close();
                    }
                    if (FormDetail.d == 3)
                    {
                        sqlConnect = new MySqlConnection(connectString);
                        sqlQuery = "INSERT INTO detail_trans_beli_tiket VALUES ('" + idTrans + "', '" + labelNamaTiket1.Text + "', '" + labelJumlah1.Text + "', '" + labelHarga1.Text + "')";
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlConnect.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnect.Close();
                        sqlConnect = new MySqlConnection(connectString);
                        sqlQuery = "INSERT INTO detail_trans_beli_tiket VALUES ('" + idTrans + "', '" + labelNamaTiket2.Text + "', '" + labelJumlah2.Text + "', '" + labelHarga2.Text + "')";
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlConnect.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnect.Close();
                        sqlConnect = new MySqlConnection(connectString);
                        sqlQuery = "INSERT INTO detail_trans_beli_tiket VALUES ('" + idTrans + "', '" + labelNamaTiket3.Text + "', '" + labelJumlah3.Text + "', '" + labelHarga3.Text + "')";
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlConnect.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnect.Close();
                        sqlQuery = "select e.JUDUL_EVENT as `Judul`, KATEGORI_EVENT as `Kategori`, NAMA_P as `Penyelenggara`, WAKTU_EVENT as `Waktu`, concat(lokasi_event, ', ', alamat_event) as `Lokasi`, KATEGORI_TIKET as `Nama Tiket`, DESKRIPSI_TIKET as `Deskripsi Tiket`, HARGA_TIKET as `Harga`, DESKRIPSI_EVENT as `Deskripsi Event`, concat('Batas beli tiket: ', akhir_tiket) as `Akhir Tiket`, URL_EVENT as `URL`, TIKET_TERJUAL AS `Terjual` from event_acara e, tiket t where e.JUDUL_EVENT = t.JUDUL_EVENT and e.JUDUL_EVENT = '" + FormHome.simpanjudul.ToString() + "';";
                        DataTable dtTiket = new DataTable();
                        sqlConnect = new MySqlConnection(connectString);
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlAdapter = new MySqlDataAdapter(sqlCommand);
                        sqlAdapter.Fill(dtTiket);
                        String TiketTerjual1 = dtTiket.Rows[0]["Terjual"].ToString();
                        String TiketTerjual2 = dtTiket.Rows[1]["Terjual"].ToString();
                        String TiketTerjual3 = dtTiket.Rows[2]["Terjual"].ToString();
                        TiketTerjual1 = TiketTerjual1 + FormDetail.a;
                        TiketTerjual2 = TiketTerjual2 + FormDetail.b;
                        TiketTerjual3 = TiketTerjual3 + FormDetail.c;
                        sqlConnect = new MySqlConnection(connectString);
                        sqlQuery = "UPDATE tiket SET TIKET_TERJUAL = '" + TiketTerjual1 + "' WHERE KATEGORI_TIKET = '" + labelNamaTiket1.Text + "'";
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlConnect.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnect.Close();
                        sqlConnect = new MySqlConnection(connectString);
                        sqlQuery = "UPDATE tiket SET TIKET_TERJUAL = '" + TiketTerjual2 + "' WHERE KATEGORI_TIKET = '" + labelNamaTiket2.Text + "'";
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlConnect.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnect.Close();
                        sqlConnect = new MySqlConnection(connectString);
                        sqlQuery = "UPDATE tiket SET TIKET_TERJUAL = '" + TiketTerjual3 + "' WHERE KATEGORI_TIKET = '" + labelNamaTiket3.Text + "'";
                        sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
                        sqlConnect.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnect.Close();
                    }
                    this.Hide();
                    FormBerhasil fb = new FormBerhasil();
                    fb.ShowDialog();
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlConnect.Close();
            }
        }

        private void FormCheckout_Load(object sender, EventArgs e)
        {
            sqlConnect = new MySqlConnection(connectString);
            sqlQuery = "select e.JUDUL_EVENT as `Judul`, KATEGORI_EVENT as `Kategori`, NAMA_P as `Penyelenggara`, WAKTU_EVENT as `Waktu`, concat(lokasi_event, ', ', alamat_event) as `Lokasi`, KATEGORI_TIKET as `Nama Tiket`, DESKRIPSI_TIKET as `Deskripsi Tiket`, HARGA_TIKET as `Harga`, DESKRIPSI_EVENT as `Deskripsi Event`, concat('Batas beli tiket: ', akhir_tiket) as `Akhir Tiket`, URL_EVENT as `URL`, TIKET_TERJUAL AS `Terjual` from event_acara e, tiket t where e.JUDUL_EVENT=t.JUDUL_EVENT and e.JUDUL_EVENT = '" + FormHome.simpanjudul.ToString() + "';";
            sqlCommand = new MySqlCommand(sqlQuery, sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtdetailevent);

            lblJudul.Text = dtdetailevent.Rows[0]["Judul"].ToString();
            lblKategori.Text = dtdetailevent.Rows[0]["Kategori"].ToString();
            labelIsiPenyelenggara.Text = dtdetailevent.Rows[0]["Penyelenggara"].ToString();
            labelIsiWaktu.Text = dtdetailevent.Rows[0]["Waktu"].ToString();
            labelIsiLokasi.Text = dtdetailevent.Rows[0]["Lokasi"].ToString();
            imagelocation = dtdetailevent.Rows[0]["URL"].ToString();
            pictureBoxDetailEvent.ImageLocation = imagelocation;

            if (FormDetail.d == 1)
            {
                PanelTiket2.Height = 0;
                PanelTiket3.Height = 0;
                if(FormDetail.a > 0)
                {
                    labelNamaTiket1.Text = dtdetailevent.Rows[0]["Nama Tiket"].ToString();
                    labelJumlah1.Text = FormDetail.a.ToString();
                    int HargaSementara1 = Convert.ToInt32(dtdetailevent.Rows[0]["Harga"]) * FormDetail.a;
                    labelHarga1.Text = HargaSementara1.ToString();
                }
                if (FormDetail.b > 0)
                {
                    labelNamaTiket1.Text = dtdetailevent.Rows[1]["Nama Tiket"].ToString();
                    labelJumlah1.Text = FormDetail.b.ToString();
                    int HargaSementara1 = Convert.ToInt32(dtdetailevent.Rows[1]["Harga"]) * FormDetail.b;
                    labelHarga1.Text = HargaSementara1.ToString();
                }
                if (FormDetail.c > 0)
                {
                    labelNamaTiket1.Text = dtdetailevent.Rows[2]["Nama Tiket"].ToString();
                    labelJumlah1.Text = FormDetail.c.ToString();
                    int HargaSementara1 = Convert.ToInt32(dtdetailevent.Rows[2]["Harga"]) * FormDetail.c;
                    labelHarga1.Text = HargaSementara1.ToString();
                }
                labelTotal.Text = labelHarga1.Text;
                
            }
            if (FormDetail.d == 2)
            {
                PanelTiket3.Height = 0;
                if(FormDetail.a > 0 && FormDetail.b > 0)
                {
                    labelNamaTiket1.Text = dtdetailevent.Rows[0]["Nama Tiket"].ToString();
                    labelJumlah1.Text = FormDetail.a.ToString();
                    int HargaSementara1 = Convert.ToInt32(dtdetailevent.Rows[0]["Harga"]) * FormDetail.a;
                    labelHarga1.Text = HargaSementara1.ToString();
                    labelNamaTiket2.Text = dtdetailevent.Rows[1]["Nama Tiket"].ToString();
                    labelJumlah2.Text = FormDetail.b.ToString();
                    int HargaSementara2 = Convert.ToInt32(dtdetailevent.Rows[1]["Harga"]) * FormDetail.b;
                    labelHarga2.Text = HargaSementara2.ToString();
                    int HargaTotal = HargaSementara1 + HargaSementara2;
                    labelTotal.Text = HargaTotal.ToString();
                }
                if (FormDetail.a > 0 && FormDetail.c > 0)
                {
                    labelNamaTiket1.Text = dtdetailevent.Rows[0]["Nama Tiket"].ToString();
                    labelJumlah1.Text = FormDetail.a.ToString();
                    int HargaSementara1 = Convert.ToInt32(dtdetailevent.Rows[0]["Harga"]) * FormDetail.a;
                    labelHarga1.Text = HargaSementara1.ToString();
                    labelNamaTiket2.Text = dtdetailevent.Rows[2]["Nama Tiket"].ToString();
                    labelJumlah2.Text = FormDetail.c.ToString();
                    int HargaSementara2 = Convert.ToInt32(dtdetailevent.Rows[2]["Harga"]) * FormDetail.c;
                    labelHarga2.Text = HargaSementara2.ToString();
                    int HargaTotal = HargaSementara1 + HargaSementara2;
                    labelTotal.Text = HargaTotal.ToString();
                }
                if (FormDetail.b > 0 && FormDetail.c > 0)
                {
                    labelNamaTiket1.Text = dtdetailevent.Rows[1]["Nama Tiket"].ToString();
                    labelJumlah1.Text = FormDetail.b.ToString();
                    int HargaSementara1 = Convert.ToInt32(dtdetailevent.Rows[1]["Harga"]) * FormDetail.b;
                    labelHarga1.Text = HargaSementara1.ToString();
                    labelNamaTiket2.Text = dtdetailevent.Rows[2]["Nama Tiket"].ToString();
                    labelJumlah2.Text = FormDetail.c.ToString();
                    int HargaSementara2 = Convert.ToInt32(dtdetailevent.Rows[2]["Harga"]) * FormDetail.c;
                    labelHarga2.Text = HargaSementara2.ToString();
                    int HargaTotal = HargaSementara1 + HargaSementara2;
                    labelTotal.Text = HargaTotal.ToString();
                }
                
            }
            if (FormDetail.d == 3)
            {
                labelNamaTiket1.Text = dtdetailevent.Rows[0]["Nama Tiket"].ToString();
                labelJumlah1.Text = FormDetail.a.ToString();
                int HargaSementara1 = Convert.ToInt32(dtdetailevent.Rows[0]["Harga"]) * FormDetail.a;
                labelHarga1.Text = HargaSementara1.ToString();
                labelNamaTiket2.Text = dtdetailevent.Rows[1]["Nama Tiket"].ToString();
                labelJumlah2.Text = FormDetail.b.ToString();
                int HargaSementara2 = Convert.ToInt32(dtdetailevent.Rows[1]["Harga"]) * FormDetail.b;
                labelHarga2.Text = HargaSementara2.ToString();
                labelNamaTiket3.Text = dtdetailevent.Rows[2]["Nama Tiket"].ToString();
                labelJumlah3.Text = FormDetail.c.ToString();
                int HargaSementara3 = Convert.ToInt32(dtdetailevent.Rows[2]["Harga"]) * FormDetail.c;
                labelHarga3.Text = HargaSementara3.ToString();
                int HargaTotal = HargaSementara1 + HargaSementara2 + HargaSementara3;
                labelTotal.Text = HargaTotal.ToString();
            }

        }
    }
}
