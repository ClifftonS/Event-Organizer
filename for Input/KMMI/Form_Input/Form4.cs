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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }
        public FormLogin fLogin;
        public void init(FormLogin f)
        {
            fLogin = f;
        }
        public void init(FormTiket f)
        {
            fLogin = f.fLogin;
        }
        public void init(FormInput f)
        {
            fLogin = f.fLogin;
        }
        private void btnLaporan_Click(object sender, EventArgs e)
        {
            gbObat.Visible = false;
            gbPenjualan.Visible = false;
            gbLaporan.Visible = true;
        }

        private void gbObat_Enter(object sender, EventArgs e)
        {

        }

        private void btnPenjualan_Click(object sender, EventArgs e)
        {
            gbObat.Visible = false;
            gbPenjualan.Visible = true;
            gbLaporan.Visible = false;
            genINV();
            isiDataUser();
            isiEvent();
            isiDetailJual();

        }


        private void FormMenu_Load(object sender, EventArgs e)
        {
            gbObat.Visible = true;
            gbPenjualan.Visible = false;
            gbLaporan.Visible = false;
            IsiDgvEvent();
        }
        //LAPORAN
        private void isiDgvLaporan(int pilihan)
        {
            try
            {
                string query = "";
                if (pilihan == 0)
                {
                    query = "SELECT * FROM Event_Perbulan";
                }
                else if (pilihan == 1)
                {
                    query = "SELECT * FROM event_terlaris";
                }
                else if (pilihan == 2)
                {
                    query = "SELECT * FROM Event_Perkategori";
                }

                MySqlDataAdapter daLaporan = new MySqlDataAdapter(query, fLogin.conn);
                DataSet dsLaporan = new DataSet();
                daLaporan.Fill(dsLaporan);
                dgvLaporan.DataSource = dsLaporan.Tables[0];
                dgvLaporan.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbJenisLaporan_SelectedIndexChanged(object sender, EventArgs e)
        {
            isiDgvLaporan(cbJenisLaporan.SelectedIndex);
        }
        private void genINV()
        {
            try
            {
                MySqlCommand cmdINV = new MySqlCommand();
                cmdINV.Connection = fLogin.conn;
                cmdINV.CommandType = CommandType.StoredProcedure;
                cmdINV.CommandText = "fGenINV";

                MySqlParameter parRet = new MySqlParameter();
                parRet.Direction = ParameterDirection.ReturnValue;
                parRet.MySqlDbType = MySqlDbType.VarChar;
                parRet.Size = 13;
                cmdINV.Parameters.Add(parRet);

                cmdINV.ExecuteNonQuery();
                txtIDINV.Text = parRet.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        //PENJUALAN
        private void isiDataUser()
        {
            try
            {
                cbUsername.DataSource = null;
                string query = "SELECT * FROM pengguna";
                MySqlDataAdapter daUser = new MySqlDataAdapter(query, fLogin.conn);
                DataSet dsUser = new DataSet();
                daUser.Fill(dsUser);
                cbUsername.Items.Clear();
                cbUsername.DataSource = dsUser.Tables[0];
                cbUsername.ValueMember = "USERNAME";
                cbUsername.DisplayMember = "USERNAME";
                cbUsername.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void isiEvent()
        {
            try
            {
                string query = "SELECT JUDUL_EVENT AS `Judul` FROM event_acara ";
                MySqlDataAdapter daEvent = new MySqlDataAdapter(query, fLogin.conn);
                DataTable dtEvent = new DataTable();
                daEvent.Fill(dtEvent);
                cbEvent.DataSource = dtEvent;
                cbEvent.ValueMember = "Judul";
                cbEvent.DisplayMember = "Judul";
                cbEvent.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void cbEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbEvent.Text != "")
                {
                    string query = "SELECT * FROM tiket WHERE KAPASITAS - TIKET_TERJUAL > 0 AND JUDUL_EVENT = '" + cbEvent.Text + "'";
                    MySqlDataAdapter daTiket = new MySqlDataAdapter(query, fLogin.conn);
                    DataTable dtTiket = new DataTable();
                    daTiket.Fill(dtTiket);
                    cbTiket.DataSource = dtTiket;
                    cbTiket.ValueMember = "KATEGORI_TIKET";
                    cbTiket.DisplayMember = "KATEGORI_TIKET";
                    if (cbTiket.Items.Count == 0)
                    {
                        cbTiket.Text = "Tiket Habis";
                    }
                    nudJmlBeli.Value = 0;
                    lblSubtotal.Text = "0";
                    lblTotal.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        DataSet dsDetail;
        MySqlDataAdapter daDetail;
        private void isiDetailJual()
        {
            try
            {
                daDetail = new MySqlDataAdapter();
                dsDetail = new DataSet();

                MySqlCommand cmdDetail = new MySqlCommand();
                cmdDetail.Connection = fLogin.conn;
                cmdDetail.CommandText = "SELECT ID_TRANS as `ID Transaksi`, KATEGORI_TIKET as `Nama Tiket`, BELI_QTY as `Jumlah`, BELI_HARGA as `Harga` FROM detail_trans_beli_tiket WHERE 1=2";

                MySqlCommandBuilder builder = new MySqlCommandBuilder(daDetail);
                daDetail.SelectCommand = cmdDetail;

                daDetail.Fill(dsDetail);
                dgvDetail.DataSource = dsDetail.Tables[0];
                dgvDetail.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        int hrgSatuan = 0;

        private void cbTiket_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MySqlCommand cmdHrgTiket = new MySqlCommand();
                cmdHrgTiket.Connection = fLogin.conn;
                cmdHrgTiket.CommandText = "SELECT HARGA_TIKET FROM tiket WHERE KATEGORI_TIKET = @judul ";
                cmdHrgTiket.Parameters.AddWithValue("@judul", cbTiket.SelectedValue.ToString());
                hrgSatuan = Convert.ToInt32(cmdHrgTiket.ExecuteScalar().ToString());
                lblHargaSatuan.Text = "Rp. " + hrgSatuan + " / pcs";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void nudJmlBeli_KeyUp(object sender, KeyEventArgs e)
        {
            lblSubtotal.Text = (nudJmlBeli.Value * hrgSatuan).ToString();
        }

        private void nudJmlBeli_ValueChanged(object sender, EventArgs e)
        {
            lblSubtotal.Text = (nudJmlBeli.Value * hrgSatuan).ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (nudJmlBeli.Value != 0)
            {
                try
                {
                    bool ada = false;
                    for (int i = 0; i < dgvDetail.Rows.Count; i++)
                    {
                        if (dgvDetail.Rows[i].Cells[1].Value == cbTiket.SelectedValue)
                        {
                            ada = true;
                            dsDetail.Tables[0].Rows[i][2] = Convert.ToInt32(dgvDetail.Rows[i].Cells[2].Value) + nudJmlBeli.Value;
                            dsDetail.Tables[0].Rows[i][3] = Convert.ToInt32(dgvDetail.Rows[i].Cells[3].Value) + Convert.ToInt32(lblSubtotal.Text);
                            lblTotal.Text = (Convert.ToInt32(lblTotal.Text) + Convert.ToInt32(lblSubtotal.Text)).ToString();
                            MessageBox.Show("Obat sudah di-Ubah");
                        }
                    }

                    if (!ada)
                    {
                        DataRow drow = dsDetail.Tables[0].NewRow();
                        drow[0] = txtIDINV.Text;
                        drow[1] = cbTiket.SelectedValue.ToString();
                        drow[2] = nudJmlBeli.Value;
                        drow[3] = lblSubtotal.Text;
                        drow.EndEdit();
                        dsDetail.Tables[0].Rows.Add(drow);
                        lblTotal.Text = (Convert.ToInt32(lblTotal.Text) + Convert.ToInt32(lblSubtotal.Text)).ToString();
                    }
                    cbTiket.SelectedIndex = 0;
                    nudJmlBeli.Value = 0;
                    if (dsDetail.Tables[0].Rows.Count > 0)
                    {
                        cbEvent.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dgvDetail.Rows.Count > 0 && cbUsername.Text != "")
            {
                MySqlTransaction trans;
                trans = fLogin.conn.BeginTransaction();

                try
                {
                    DateTime dtnow = DateTime.Now;
                    MySqlCommand cmdIns = new MySqlCommand();
                    cmdIns.Connection = fLogin.conn;
                    cmdIns.CommandText = "INSERT INTO transaksi_beli_tiket VALUES ('" + txtIDINV.Text + "', '" + cbUsername.Text + "', '" + cbEvent.Text + "', '" + dtnow.ToString("yyyy-MM-dd") + "', '" + lblTotal.Text + "', 'OVO')";
                    cmdIns.ExecuteNonQuery();


                    daDetail.Update(dsDetail);

                    trans.Commit();
                    MessageBox.Show("Transaksi Berhasil !");
                    dsDetail.Clear();


                    txtIDINV.Clear();
                    cbUsername.SelectedIndex = -1;
                    cbEvent.SelectedIndex = 0;
                    cbEvent.Enabled = true;
                    nudJmlBeli.Value = 0;
                    lblSubtotal.Text = "0";
                    lblTotal.Text = "0";

                    FormMenu_Load(null, null);
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    MessageBox.Show(ex.Message.ToString());
                }
            }
            else
            {
                MessageBox.Show("Data Belum Lengkap");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dsDetail.Clear();
            cbEvent.Enabled = true;
            lblTotal.Text = "0";
            lblSubtotal.Text = "0";
        }
        
        //EVENT
        
        private void IsiDgvEvent()
        {
            try
            {
                if (cboxAll.Checked == true)
                {
                    string query = "select e.judul_event as `Judul Event`, e.nama_p as `Penyelenggara`, e.tgl_event as `Tanggal`, count(t.judul_event) as `Total Jenis Tiket` from event_acara e, tiket t  where e.judul_event=t.judul_event group by e.JUDUL_EVENT";
                    MySqlDataAdapter daEvent = new MySqlDataAdapter(query, fLogin.conn);
                    DataTable dtEvent = new DataTable();
                    daEvent.Fill(dtEvent);
                    dgvEvent.DataSource = dtEvent;

                    lblJmlEvent.Text = "Jumlah Event: " + Convert.ToString(dtEvent.Rows.Count) + " event";
                    dgvEvent.Refresh();
                }
                else
                {
                    MySqlCommand cmdTgl = new MySqlCommand();
                    cmdTgl.Connection = fLogin.conn;
                    cmdTgl.CommandText = "call pCariTanggal('" + dtpWaktu.Value.ToString("yyyy-MM-dd") + "')";

                    MySqlDataAdapter daEvent = new MySqlDataAdapter(cmdTgl);
                    DataTable dtEvent = new DataTable();
                    daEvent.Fill(dtEvent);
                    dgvEvent.DataSource = dtEvent;

                    lblJmlEvent.Text = "Jumlah Event: " + Convert.ToString(dtEvent.Rows.Count) + " event";
                    dgvEvent.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnEvent_Click(object sender, EventArgs e)
        {
            gbObat.Visible = true;
            gbPenjualan.Visible = false;
            gbLaporan.Visible = false;
            IsiDgvEvent();
        }

        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            FormInput fInput = new FormInput();
            fInput.init(this);
            fInput.ShowDialog();
        }

        public static string simpanEvent;
        private void dgvEvent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                simpanEvent = dgvEvent.Rows[e.RowIndex].Cells["Judul Event"].Value.ToString();

                FormTiket fTiket = new FormTiket();
                fTiket.init(this);
                fTiket.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cboxAll.Checked == true)
            {
                dtpWaktu.Enabled = false;
            }
            if (cboxAll.Checked == false)
            {
                dtpWaktu.Enabled = true;
            }
            IsiDgvEvent();
        }

        private void dtpWaktu_ValueChanged(object sender, EventArgs e)
        {
            IsiDgvEvent();
        }
    }
}
