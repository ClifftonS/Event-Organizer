
namespace Form_Input
{
    partial class FormTiket
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTiket));
            this.panel9 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.Button();
            this.lblJudulEvent = new System.Windows.Forms.Label();
            this.lblJudulEventket = new System.Windows.Forms.Label();
            this.buttonBack = new System.Windows.Forms.Button();
            this.dgvTiket = new System.Windows.Forms.DataGridView();
            this.panel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiket)).BeginInit();
            this.SuspendLayout();
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(20)))), ((int)(((byte)(149)))));
            this.panel9.Controls.Add(this.pictureBox3);
            this.panel9.Controls.Add(this.btnHome);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(917, 48);
            this.panel9.TabIndex = 6;
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
            this.btnHome.TabStop = false;
            this.btnHome.Text = "EVENT";
            this.btnHome.UseVisualStyleBackColor = true;
            // 
            // lblJudulEvent
            // 
            this.lblJudulEvent.AutoSize = true;
            this.lblJudulEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudulEvent.Location = new System.Drawing.Point(185, 58);
            this.lblJudulEvent.Name = "lblJudulEvent";
            this.lblJudulEvent.Size = new System.Drawing.Size(16, 24);
            this.lblJudulEvent.TabIndex = 10;
            this.lblJudulEvent.Text = "-";
            // 
            // lblJudulEventket
            // 
            this.lblJudulEventket.AutoSize = true;
            this.lblJudulEventket.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudulEventket.Location = new System.Drawing.Point(41, 58);
            this.lblJudulEventket.Name = "lblJudulEventket";
            this.lblJudulEventket.Size = new System.Drawing.Size(138, 24);
            this.lblJudulEventket.TabIndex = 9;
            this.lblJudulEventket.Text = "Judul Event : ";
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(796, 95);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(89, 30);
            this.buttonBack.TabIndex = 8;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // dgvTiket
            // 
            this.dgvTiket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTiket.Location = new System.Drawing.Point(45, 95);
            this.dgvTiket.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvTiket.Name = "dgvTiket";
            this.dgvTiket.RowHeadersWidth = 62;
            this.dgvTiket.RowTemplate.Height = 28;
            this.dgvTiket.Size = new System.Drawing.Size(701, 342);
            this.dgvTiket.TabIndex = 7;
            // 
            // FormTiket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 478);
            this.Controls.Add(this.lblJudulEvent);
            this.Controls.Add(this.lblJudulEventket);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.dgvTiket);
            this.Controls.Add(this.panel9);
            this.Name = "FormTiket";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Tiket";
            this.Load += new System.EventHandler(this.FormTiket_Load);
            this.panel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTiket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Label lblJudulEvent;
        private System.Windows.Forms.Label lblJudulEventket;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.DataGridView dgvTiket;
    }
}