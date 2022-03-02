using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAA_Project_Sem_2
{
    public partial class FormBerhasil : Form
    {
        public FormBerhasil()
        {
            InitializeComponent();
        }
        

        private void FormBerhasil_Load(object sender, EventArgs e)
        {
            lblKode.Text = FormCheckout.kode;
            lblTotal.Text = FormCheckout.total;
     
        }

        private void btnCekPesanan_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPesanan fp = new FormPesanan();
            fp.ShowDialog();
        }

        private void btnHomePage_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormHome fh = new FormHome();
            fh.ShowDialog();
        }
    }
}
