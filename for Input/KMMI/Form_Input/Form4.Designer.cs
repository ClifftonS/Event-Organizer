
namespace Form_Input
{
    partial class FormMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.btnLaporan = new System.Windows.Forms.Button();
            this.gbLaporan = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.cbJenisLaporan = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.gbPenjualan = new System.Windows.Forms.GroupBox();
            this.cbUsername = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.gbDetail = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblHargaSatuan = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.nudJmlBeli = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.cbTiket = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbEvent = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvDetail = new System.Windows.Forms.DataGridView();
            this.txtIDINV = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gbObat = new System.Windows.Forms.GroupBox();
            this.cboxAll = new System.Windows.Forms.CheckBox();
            this.dtpWaktu = new System.Windows.Forms.DateTimePicker();
            this.lblJmlEvent = new System.Windows.Forms.Label();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.dgvEvent = new System.Windows.Forms.DataGridView();
            this.btnPenjualan = new System.Windows.Forms.Button();
            this.btnEvent = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.gbLaporan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.gbPenjualan.SuspendLayout();
            this.gbDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudJmlBeli)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).BeginInit();
            this.gbObat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLaporan
            // 
            this.btnLaporan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(20)))), ((int)(((byte)(149)))));
            this.btnLaporan.Font = new System.Drawing.Font("Geometr415 Blk BT", 12F);
            this.btnLaporan.ForeColor = System.Drawing.Color.White;
            this.btnLaporan.Location = new System.Drawing.Point(865, 7);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(120, 35);
            this.btnLaporan.TabIndex = 11;
            this.btnLaporan.Text = "Laporan";
            this.btnLaporan.UseVisualStyleBackColor = false;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // gbLaporan
            // 
            this.gbLaporan.Controls.Add(this.label19);
            this.gbLaporan.Controls.Add(this.dgvLaporan);
            this.gbLaporan.Controls.Add(this.cbJenisLaporan);
            this.gbLaporan.Controls.Add(this.label18);
            this.gbLaporan.Location = new System.Drawing.Point(895, 62);
            this.gbLaporan.Name = "gbLaporan";
            this.gbLaporan.Size = new System.Drawing.Size(568, 424);
            this.gbLaporan.TabIndex = 10;
            this.gbLaporan.TabStop = false;
            this.gbLaporan.Text = "LAPORAN";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label19.Location = new System.Drawing.Point(341, 34);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(197, 23);
            this.label19.TabIndex = 29;
            this.label19.Text = "<-- Pilih Jenis Laporan ";
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.AllowUserToAddRows = false;
            this.dgvLaporan.AllowUserToDeleteRows = false;
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Location = new System.Drawing.Point(10, 71);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.ReadOnly = true;
            this.dgvLaporan.RowHeadersWidth = 51;
            this.dgvLaporan.RowTemplate.Height = 29;
            this.dgvLaporan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLaporan.Size = new System.Drawing.Size(528, 335);
            this.dgvLaporan.TabIndex = 28;
            // 
            // cbJenisLaporan
            // 
            this.cbJenisLaporan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbJenisLaporan.FormattingEnabled = true;
            this.cbJenisLaporan.Items.AddRange(new object[] {
            "Total Event Perbulan",
            "Event Terlaris",
            "Total Event Perkategori"});
            this.cbJenisLaporan.Location = new System.Drawing.Point(71, 34);
            this.cbJenisLaporan.Name = "cbJenisLaporan";
            this.cbJenisLaporan.Size = new System.Drawing.Size(258, 24);
            this.cbJenisLaporan.TabIndex = 27;
            this.cbJenisLaporan.SelectedIndexChanged += new System.EventHandler(this.cbJenisLaporan_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(10, 37);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(49, 17);
            this.label18.TabIndex = 26;
            this.label18.Text = "Jenis :";
            // 
            // gbPenjualan
            // 
            this.gbPenjualan.Controls.Add(this.cbUsername);
            this.gbPenjualan.Controls.Add(this.btnSave);
            this.gbPenjualan.Controls.Add(this.label16);
            this.gbPenjualan.Controls.Add(this.lblTotal);
            this.gbPenjualan.Controls.Add(this.gbDetail);
            this.gbPenjualan.Controls.Add(this.txtIDINV);
            this.gbPenjualan.Controls.Add(this.label11);
            this.gbPenjualan.Controls.Add(this.label6);
            this.gbPenjualan.Location = new System.Drawing.Point(8, 54);
            this.gbPenjualan.Name = "gbPenjualan";
            this.gbPenjualan.Size = new System.Drawing.Size(840, 605);
            this.gbPenjualan.TabIndex = 9;
            this.gbPenjualan.TabStop = false;
            this.gbPenjualan.Text = "PENJUALAN";
            this.gbPenjualan.Visible = false;
            // 
            // cbUsername
            // 
            this.cbUsername.DisplayMember = "USERNAME";
            this.cbUsername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsername.FormattingEnabled = true;
            this.cbUsername.Location = new System.Drawing.Point(144, 69);
            this.cbUsername.Name = "cbUsername";
            this.cbUsername.Size = new System.Drawing.Size(424, 24);
            this.cbUsername.TabIndex = 32;
            this.cbUsername.ValueMember = "USERNAME";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(614, 542);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 46);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.label16.Location = new System.Drawing.Point(575, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(155, 32);
            this.label16.TabIndex = 30;
            this.label16.Text = "TOTAL = Rp.";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(575, 69);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(35, 41);
            this.lblTotal.TabIndex = 29;
            this.lblTotal.Text = "0";
            // 
            // gbDetail
            // 
            this.gbDetail.Controls.Add(this.label17);
            this.gbDetail.Controls.Add(this.lblSubtotal);
            this.gbDetail.Controls.Add(this.lblHargaSatuan);
            this.gbDetail.Controls.Add(this.lbl1);
            this.gbDetail.Controls.Add(this.btnClear);
            this.gbDetail.Controls.Add(this.btnAdd);
            this.gbDetail.Controls.Add(this.nudJmlBeli);
            this.gbDetail.Controls.Add(this.label15);
            this.gbDetail.Controls.Add(this.cbTiket);
            this.gbDetail.Controls.Add(this.label13);
            this.gbDetail.Controls.Add(this.cbEvent);
            this.gbDetail.Controls.Add(this.label14);
            this.gbDetail.Controls.Add(this.dgvDetail);
            this.gbDetail.Location = new System.Drawing.Point(11, 145);
            this.gbDetail.Name = "gbDetail";
            this.gbDetail.Size = new System.Drawing.Size(747, 391);
            this.gbDetail.TabIndex = 23;
            this.gbDetail.TabStop = false;
            this.gbDetail.Text = "OBAT YANG DIBELI";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(201, 107);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 17);
            this.label17.TabIndex = 30;
            this.label17.Text = "Subtotal = Rp.";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblSubtotal.Location = new System.Drawing.Point(330, 105);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(19, 23);
            this.lblSubtotal.TabIndex = 29;
            this.lblSubtotal.Text = "0";
            // 
            // lblHargaSatuan
            // 
            this.lblHargaSatuan.AutoSize = true;
            this.lblHargaSatuan.Location = new System.Drawing.Point(451, 71);
            this.lblHargaSatuan.Name = "lblHargaSatuan";
            this.lblHargaSatuan.Size = new System.Drawing.Size(47, 17);
            this.lblHargaSatuan.TabIndex = 28;
            this.lblHargaSatuan.Text = "Harga";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(451, 37);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(198, 17);
            this.lbl1.TabIndex = 28;
            this.lbl1.Text = "<1 Event Dalam 1 Pembelian>";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(652, 92);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(89, 32);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(652, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(89, 60);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "Add to Cart";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // nudJmlBeli
            // 
            this.nudJmlBeli.Location = new System.Drawing.Point(105, 105);
            this.nudJmlBeli.Name = "nudJmlBeli";
            this.nudJmlBeli.Size = new System.Drawing.Size(90, 22);
            this.nudJmlBeli.TabIndex = 26;
            this.nudJmlBeli.ValueChanged += new System.EventHandler(this.nudJmlBeli_ValueChanged);
            this.nudJmlBeli.KeyUp += new System.Windows.Forms.KeyEventHandler(this.nudJmlBeli_KeyUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(26, 107);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 17);
            this.label15.TabIndex = 25;
            this.label15.Text = "Jumlah :";
            // 
            // cbTiket
            // 
            this.cbTiket.DisplayMember = "nama_obat";
            this.cbTiket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTiket.FormattingEnabled = true;
            this.cbTiket.Location = new System.Drawing.Point(105, 68);
            this.cbTiket.Name = "cbTiket";
            this.cbTiket.Size = new System.Drawing.Size(340, 24);
            this.cbTiket.TabIndex = 24;
            this.cbTiket.ValueMember = "KATEGORI_TIKET";
            this.cbTiket.SelectedIndexChanged += new System.EventHandler(this.cbTiket_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(42, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(47, 17);
            this.label13.TabIndex = 23;
            this.label13.Text = "Tiket :";
            // 
            // cbEvent
            // 
            this.cbEvent.DisplayMember = "nama_obat";
            this.cbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEvent.FormattingEnabled = true;
            this.cbEvent.Location = new System.Drawing.Point(105, 34);
            this.cbEvent.Name = "cbEvent";
            this.cbEvent.Size = new System.Drawing.Size(340, 24);
            this.cbEvent.TabIndex = 24;
            this.cbEvent.ValueMember = "JUDUL_EVENT";
            this.cbEvent.SelectedIndexChanged += new System.EventHandler(this.cbEvent_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(42, 37);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 17);
            this.label14.TabIndex = 23;
            this.label14.Text = "Event :";
            // 
            // dgvDetail
            // 
            this.dgvDetail.AllowUserToAddRows = false;
            this.dgvDetail.AllowUserToDeleteRows = false;
            this.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetail.Location = new System.Drawing.Point(7, 151);
            this.dgvDetail.MultiSelect = false;
            this.dgvDetail.Name = "dgvDetail";
            this.dgvDetail.ReadOnly = true;
            this.dgvDetail.RowHeadersWidth = 51;
            this.dgvDetail.RowTemplate.Height = 29;
            this.dgvDetail.Size = new System.Drawing.Size(720, 227);
            this.dgvDetail.TabIndex = 0;
            // 
            // txtIDINV
            // 
            this.txtIDINV.Enabled = false;
            this.txtIDINV.Location = new System.Drawing.Point(147, 33);
            this.txtIDINV.Name = "txtIDINV";
            this.txtIDINV.ReadOnly = true;
            this.txtIDINV.Size = new System.Drawing.Size(243, 22);
            this.txtIDINV.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 17);
            this.label11.TabIndex = 1;
            this.label11.Text = "Username Pembeli :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Invoice :";
            // 
            // gbObat
            // 
            this.gbObat.Controls.Add(this.cboxAll);
            this.gbObat.Controls.Add(this.dtpWaktu);
            this.gbObat.Controls.Add(this.lblJmlEvent);
            this.gbObat.Controls.Add(this.btnAddEvent);
            this.gbObat.Controls.Add(this.dgvEvent);
            this.gbObat.Location = new System.Drawing.Point(12, 53);
            this.gbObat.Name = "gbObat";
            this.gbObat.Size = new System.Drawing.Size(836, 414);
            this.gbObat.TabIndex = 8;
            this.gbObat.TabStop = false;
            this.gbObat.Text = "EVENT";
            this.gbObat.Enter += new System.EventHandler(this.gbObat_Enter);
            // 
            // cboxAll
            // 
            this.cboxAll.AutoSize = true;
            this.cboxAll.Checked = true;
            this.cboxAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxAll.Location = new System.Drawing.Point(636, 92);
            this.cboxAll.Name = "cboxAll";
            this.cboxAll.Size = new System.Drawing.Size(79, 21);
            this.cboxAll.TabIndex = 17;
            this.cboxAll.Text = "All Date";
            this.cboxAll.UseVisualStyleBackColor = true;
            this.cboxAll.CheckedChanged += new System.EventHandler(this.cboxAll_CheckedChanged);
            // 
            // dtpWaktu
            // 
            this.dtpWaktu.Enabled = false;
            this.dtpWaktu.Location = new System.Drawing.Point(636, 64);
            this.dtpWaktu.Name = "dtpWaktu";
            this.dtpWaktu.Size = new System.Drawing.Size(167, 22);
            this.dtpWaktu.TabIndex = 16;
            this.dtpWaktu.ValueChanged += new System.EventHandler(this.dtpWaktu_ValueChanged);
            // 
            // lblJmlEvent
            // 
            this.lblJmlEvent.AutoSize = true;
            this.lblJmlEvent.Font = new System.Drawing.Font("Segoe UI", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblJmlEvent.Location = new System.Drawing.Point(6, 26);
            this.lblJmlEvent.Name = "lblJmlEvent";
            this.lblJmlEvent.Size = new System.Drawing.Size(144, 28);
            this.lblJmlEvent.TabIndex = 15;
            this.lblJmlEvent.Text = "Jumlah Event:";
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(525, 21);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(94, 29);
            this.btnAddEvent.TabIndex = 1;
            this.btnAddEvent.Text = "Add New";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // dgvEvent
            // 
            this.dgvEvent.AllowUserToAddRows = false;
            this.dgvEvent.AllowUserToDeleteRows = false;
            this.dgvEvent.AllowUserToResizeRows = false;
            this.dgvEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvent.Location = new System.Drawing.Point(6, 64);
            this.dgvEvent.MultiSelect = false;
            this.dgvEvent.Name = "dgvEvent";
            this.dgvEvent.ReadOnly = true;
            this.dgvEvent.RowHeadersWidth = 51;
            this.dgvEvent.RowTemplate.Height = 29;
            this.dgvEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvent.Size = new System.Drawing.Size(613, 320);
            this.dgvEvent.TabIndex = 0;
            this.dgvEvent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvent_CellClick);
            // 
            // btnPenjualan
            // 
            this.btnPenjualan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(20)))), ((int)(((byte)(149)))));
            this.btnPenjualan.Font = new System.Drawing.Font("Geometr415 Blk BT", 12F);
            this.btnPenjualan.ForeColor = System.Drawing.Color.White;
            this.btnPenjualan.Location = new System.Drawing.Point(728, 7);
            this.btnPenjualan.Name = "btnPenjualan";
            this.btnPenjualan.Size = new System.Drawing.Size(120, 35);
            this.btnPenjualan.TabIndex = 7;
            this.btnPenjualan.Text = "Penjualan";
            this.btnPenjualan.UseVisualStyleBackColor = false;
            this.btnPenjualan.Click += new System.EventHandler(this.btnPenjualan_Click);
            // 
            // btnEvent
            // 
            this.btnEvent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(20)))), ((int)(((byte)(149)))));
            this.btnEvent.Font = new System.Drawing.Font("Geometr415 Blk BT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEvent.ForeColor = System.Drawing.Color.White;
            this.btnEvent.Location = new System.Drawing.Point(593, 7);
            this.btnEvent.Name = "btnEvent";
            this.btnEvent.Size = new System.Drawing.Size(120, 35);
            this.btnEvent.TabIndex = 6;
            this.btnEvent.Text = "Event";
            this.btnEvent.UseVisualStyleBackColor = false;
            this.btnEvent.Click += new System.EventHandler(this.btnEvent_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(20)))), ((int)(((byte)(149)))));
            this.panel1.Controls.Add(this.btnLaporan);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.btnPenjualan);
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Controls.Add(this.btnEvent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1505, 48);
            this.panel1.TabIndex = 12;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(3, 8);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(36, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // btnHome
            // 
            this.btnHome.FlatAppearance.BorderSize = 0;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Font = new System.Drawing.Font("Geometr415 Blk BT", 16F);
            this.btnHome.ForeColor = System.Drawing.Color.White;
            this.btnHome.Location = new System.Drawing.Point(34, 5);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(144, 41);
            this.btnHome.TabIndex = 0;
            this.btnHome.Text = "EVENT";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1505, 853);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbPenjualan);
            this.Controls.Add(this.gbLaporan);
            this.Controls.Add(this.gbObat);
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Menu";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            this.gbLaporan.ResumeLayout(false);
            this.gbLaporan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.gbPenjualan.ResumeLayout(false);
            this.gbPenjualan.PerformLayout();
            this.gbDetail.ResumeLayout(false);
            this.gbDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudJmlBeli)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetail)).EndInit();
            this.gbObat.ResumeLayout(false);
            this.gbObat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvent)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLaporan;
        private System.Windows.Forms.GroupBox gbLaporan;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.ComboBox cbJenisLaporan;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox gbPenjualan;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox gbDetail;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.NumericUpDown nudJmlBeli;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cbEvent;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvDetail;
        private System.Windows.Forms.TextBox txtIDINV;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gbObat;
        private System.Windows.Forms.Label lblJmlEvent;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.DataGridView dgvEvent;
        private System.Windows.Forms.Button btnPenjualan;
        private System.Windows.Forms.Button btnEvent;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.ComboBox cbTiket;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbUsername;
        private System.Windows.Forms.Label lblHargaSatuan;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.CheckBox cboxAll;
        private System.Windows.Forms.DateTimePicker dtpWaktu;
    }
}