using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_Input
{
    public partial class FormBayar : Form
    {
        public FormBayar()
        {
            InitializeComponent();
        }
        public string NamaTiket = "";
        public string Kapasitas = "";
        public string Harga = "";
        public string Deskripsi = "";
        public string Awal;
        public string Akhir;

        private void tboxHarga_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tboxDeskripsi_TextChanged(object sender, EventArgs e)
        {
            string Total = "";
            Total = tboxDeskripsi.TextLength.ToString();
            lblTotal.Text = Total + "/70";
        }

        private void btnBuat_Click(object sender, EventArgs e)
        {
            if (FormInput.buat < 3)
            {
                if (tboxNama.Text != "" && tboxKapasitas.Text != "" && tboxHarga.Text != "" && tboxDeskripsi.Text != "")
                {
                    FormInput.a = true;
                    FormInput.buat++;
                    NamaTiket = tboxNama.Text;
                    Kapasitas = tboxKapasitas.Text;
                    Harga = tboxHarga.Text;
                    Deskripsi = tboxDeskripsi.Text;
                    Awal = dtpTanggal1.Value.ToString("yyyy-MM-dd");
                    Akhir = dtpTanggal2.Value.ToString("yyyy-MM-dd");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Data masih ada yang kosong");
                }
            }
            else
            {
                
                MessageBox.Show("Tiket sudah maksimal");
            }
        }

        private void tboxKapasitas_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void FormBayar_Load(object sender, EventArgs e)
        {
            
            dtpTanggal1.MinDate = DateTime.Today;
            dtpTanggal1.MaxDate = FormInput.dt1;
            dtpTanggal2.MinDate = DateTime.Today;
            dtpTanggal2.MaxDate = FormInput.dt1;
            
            if (FormInput.buatEventGratis == true)
            {
                tboxHarga.Text = "GRATIS";
                tboxHarga.Enabled = false;
            }

        }
    }
}
