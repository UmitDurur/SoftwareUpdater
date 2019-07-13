namespace SoftwareUpdater
{
    partial class frmYenilikler
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
            this.pnlGuncellestirmeNotlari = new System.Windows.Forms.Panel();
            this.btnAtla = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.lblGuncellemeBoyutu = new System.Windows.Forms.Label();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGuncellestirmeNotlari
            // 
            this.pnlGuncellestirmeNotlari.AutoScroll = true;
            this.pnlGuncellestirmeNotlari.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGuncellestirmeNotlari.Location = new System.Drawing.Point(0, 0);
            this.pnlGuncellestirmeNotlari.Name = "pnlGuncellestirmeNotlari";
            this.pnlGuncellestirmeNotlari.Size = new System.Drawing.Size(340, 260);
            this.pnlGuncellestirmeNotlari.TabIndex = 0;
            this.pnlGuncellestirmeNotlari.TabStop = true;
            // 
            // btnAtla
            // 
            this.btnAtla.Location = new System.Drawing.Point(5, 21);
            this.btnAtla.Name = "btnAtla";
            this.btnAtla.Size = new System.Drawing.Size(165, 33);
            this.btnAtla.TabIndex = 1;
            this.btnAtla.Text = "Atla";
            this.btnAtla.UseVisualStyleBackColor = true;
            this.btnAtla.Click += new System.EventHandler(this.btnAtla_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(170, 21);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(165, 33);
            this.btnGuncelle.TabIndex = 0;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // pnlFooter
            // 
            this.pnlFooter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.lblGuncellemeBoyutu);
            this.pnlFooter.Controls.Add(this.btnGuncelle);
            this.pnlFooter.Controls.Add(this.btnAtla);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 260);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(340, 60);
            this.pnlFooter.TabIndex = 2;
            this.pnlFooter.TabStop = true;
            // 
            // lblGuncellemeBoyutu
            // 
            this.lblGuncellemeBoyutu.AutoSize = true;
            this.lblGuncellemeBoyutu.Location = new System.Drawing.Point(69, 5);
            this.lblGuncellemeBoyutu.Name = "lblGuncellemeBoyutu";
            this.lblGuncellemeBoyutu.Size = new System.Drawing.Size(101, 13);
            this.lblGuncellemeBoyutu.TabIndex = 2;
            this.lblGuncellemeBoyutu.Text = "Güncelleme boyutu:";
            // 
            // frmYenilikler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(340, 320);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlGuncellestirmeNotlari);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmYenilikler";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Güncelleme bildirimi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmYenilikler_FormClosing);
            this.Load += new System.EventHandler(this.frmYenilikler_Load);
            this.Shown += new System.EventHandler(this.frmYenilikler_Shown);
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlGuncellestirmeNotlari;
        private System.Windows.Forms.Button btnAtla;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Label lblGuncellemeBoyutu;
    }
}