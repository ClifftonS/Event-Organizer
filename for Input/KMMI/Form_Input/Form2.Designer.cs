
namespace Form_Input
{
    partial class FormBayar
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tboxNama = new System.Windows.Forms.TextBox();
            this.tboxKapasitas = new System.Windows.Forms.TextBox();
            this.tboxHarga = new System.Windows.Forms.TextBox();
            this.tboxDeskripsi = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnBuat = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpTanggal1 = new System.Windows.Forms.DateTimePicker();
            this.dtpTanggal2 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detail Tiket";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nama Tiket";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Kapasitas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Harga Tiket";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Deskripsi Tiket";
            // 
            // tboxNama
            // 
            this.tboxNama.Location = new System.Drawing.Point(136, 69);
            this.tboxNama.Name = "tboxNama";
            this.tboxNama.Size = new System.Drawing.Size(159, 22);
            this.tboxNama.TabIndex = 1;
            // 
            // tboxKapasitas
            // 
            this.tboxKapasitas.Location = new System.Drawing.Point(136, 115);
            this.tboxKapasitas.Name = "tboxKapasitas";
            this.tboxKapasitas.Size = new System.Drawing.Size(159, 22);
            this.tboxKapasitas.TabIndex = 2;
            this.tboxKapasitas.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxKapasitas_KeyPress);
            // 
            // tboxHarga
            // 
            this.tboxHarga.Location = new System.Drawing.Point(136, 160);
            this.tboxHarga.Name = "tboxHarga";
            this.tboxHarga.Size = new System.Drawing.Size(159, 22);
            this.tboxHarga.TabIndex = 3;
            this.tboxHarga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tboxHarga_KeyPress);
            // 
            // tboxDeskripsi
            // 
            this.tboxDeskripsi.Location = new System.Drawing.Point(136, 205);
            this.tboxDeskripsi.MaxLength = 70;
            this.tboxDeskripsi.Multiline = true;
            this.tboxDeskripsi.Name = "tboxDeskripsi";
            this.tboxDeskripsi.Size = new System.Drawing.Size(212, 87);
            this.tboxDeskripsi.TabIndex = 4;
            this.tboxDeskripsi.TextChanged += new System.EventHandler(this.tboxDeskripsi_TextChanged);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(304, 295);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(36, 17);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "0/70";
            // 
            // btnBuat
            // 
            this.btnBuat.Location = new System.Drawing.Point(161, 415);
            this.btnBuat.Name = "btnBuat";
            this.btnBuat.Size = new System.Drawing.Size(75, 23);
            this.btnBuat.TabIndex = 4;
            this.btnBuat.Text = "Buat";
            this.btnBuat.UseVisualStyleBackColor = true;
            this.btnBuat.Click += new System.EventHandler(this.btnBuat_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mulai Penjualan";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 17);
            this.label7.TabIndex = 5;
            this.label7.Text = "Akhir Penjualan";
            // 
            // dtpTanggal1
            // 
            this.dtpTanggal1.Location = new System.Drawing.Point(136, 317);
            this.dtpTanggal1.Name = "dtpTanggal1";
            this.dtpTanggal1.Size = new System.Drawing.Size(162, 22);
            this.dtpTanggal1.TabIndex = 5;
            // 
            // dtpTanggal2
            // 
            this.dtpTanggal2.Location = new System.Drawing.Point(136, 353);
            this.dtpTanggal2.Name = "dtpTanggal2";
            this.dtpTanggal2.Size = new System.Drawing.Size(162, 22);
            this.dtpTanggal2.TabIndex = 6;
            // 
            // FormBayar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 450);
            this.Controls.Add(this.dtpTanggal2);
            this.Controls.Add(this.dtpTanggal1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnBuat);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.tboxDeskripsi);
            this.Controls.Add(this.tboxHarga);
            this.Controls.Add(this.tboxKapasitas);
            this.Controls.Add(this.tboxNama);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormBayar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormBuatTiket";
            this.Load += new System.EventHandler(this.FormBayar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tboxNama;
        private System.Windows.Forms.TextBox tboxKapasitas;
        private System.Windows.Forms.TextBox tboxHarga;
        private System.Windows.Forms.TextBox tboxDeskripsi;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnBuat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpTanggal1;
        private System.Windows.Forms.DateTimePicker dtpTanggal2;
    }
}