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
    public partial class FormProfil : Form
    {
        public FormProfil()
        {
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (tboxNama.Text != "" && tboxAlamat.Text != "" && tboxDeskripsi.Text != "")
            {
                FormInput.NamaPenyelenggara = tboxNama.Text;
                FormInput.AlamatPenyelenggara = tboxAlamat.Text;
                FormInput.DeskripsiPenyelenggara = tboxDeskripsi.Text;
                FormInput.Profil = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Data masih ada yang kosong");
            }
        }
    }
}
