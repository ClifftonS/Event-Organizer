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
    public partial class FormTiket : Form
    {
        public FormTiket()
        {
            InitializeComponent();
        }
        public FormLogin fLogin;
        public void init(FormMenu f)
        {
            fLogin = f.fLogin;
        }
        private void FormTiket_Load(object sender, EventArgs e)
        {
            try
            {
                lblJudulEvent.Text = FormMenu.simpanEvent;
                string sqlQuery = "select KATEGORI_TIKET as `Nama Tiket`, HARGA_TIKET as `Harga Tiket`, KAPASITAS as `Kapasitas`, TIKET_TERJUAL as `Tiket Terjual` from tiket where JUDUL_EVENT = '" + lblJudulEvent.Text.ToString() + "';";
                DataTable dtTiket = new DataTable();
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlQuery, fLogin.conn);
                sqlAdapter.Fill(dtTiket);

                dgvTiket.DataSource = dtTiket;
                dgvTiket.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            try
            {
                FormMenu fmenu = new FormMenu();
                fmenu.init(this);
                fmenu.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
