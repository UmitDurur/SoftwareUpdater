namespace SoftwareUpdater
{
    partial class frmGuncelle
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGuncelle));
            this.pnlAyrintilar = new System.Windows.Forms.Panel();
            this.btnDuraklat = new System.Windows.Forms.Button();
            this.lblKalanSure = new System.Windows.Forms.Label();
            this.lblHiz = new System.Windows.Forms.Label();
            this.lblIndirilen = new System.Windows.Forms.Label();
            this.lblBoyut = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            this.lbl_klnsure = new System.Windows.Forms.Label();
            this.lbl_hiz = new System.Windows.Forms.Label();
            this.lbl_indir = new System.Windows.Forms.Label();
            this.lbl_boyut = new System.Windows.Forms.Label();
            this.lbl_durum = new System.Windows.Forms.Label();
            this.pBarYuzde = new System.Windows.Forms.ProgressBar();
            this.lViewAyrintilar = new System.Windows.Forms.ListView();
            this.btnAyrintilar = new System.Windows.Forms.Button();
            this.imagelAyrintiButon = new System.Windows.Forms.ImageList(this.components);
            this.bgWorkerIndir = new System.ComponentModel.BackgroundWorker();
            this.tmrDurumGuncelle = new System.Windows.Forms.Timer(this.components);
            this.pnlAyrintilar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlAyrintilar
            // 
            this.pnlAyrintilar.Controls.Add(this.btnDuraklat);
            this.pnlAyrintilar.Controls.Add(this.lblKalanSure);
            this.pnlAyrintilar.Controls.Add(this.lblHiz);
            this.pnlAyrintilar.Controls.Add(this.lblIndirilen);
            this.pnlAyrintilar.Controls.Add(this.lblBoyut);
            this.pnlAyrintilar.Controls.Add(this.lblDurum);
            this.pnlAyrintilar.Controls.Add(this.lbl_klnsure);
            this.pnlAyrintilar.Controls.Add(this.lbl_hiz);
            this.pnlAyrintilar.Controls.Add(this.lbl_indir);
            this.pnlAyrintilar.Controls.Add(this.lbl_boyut);
            this.pnlAyrintilar.Controls.Add(this.lbl_durum);
            this.pnlAyrintilar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAyrintilar.Location = new System.Drawing.Point(0, 0);
            this.pnlAyrintilar.Name = "pnlAyrintilar";
            this.pnlAyrintilar.Size = new System.Drawing.Size(415, 106);
            this.pnlAyrintilar.TabIndex = 8;
            // 
            // btnDuraklat
            // 
            this.btnDuraklat.Location = new System.Drawing.Point(328, 79);
            this.btnDuraklat.Name = "btnDuraklat";
            this.btnDuraklat.Size = new System.Drawing.Size(75, 23);
            this.btnDuraklat.TabIndex = 22;
            this.btnDuraklat.Text = "Duraklat";
            this.btnDuraklat.UseVisualStyleBackColor = true;
            this.btnDuraklat.Click += new System.EventHandler(this.btnDuraklat_Click);
            // 
            // lblKalanSure
            // 
            this.lblKalanSure.AutoSize = true;
            this.lblKalanSure.Location = new System.Drawing.Point(138, 84);
            this.lblKalanSure.Name = "lblKalanSure";
            this.lblKalanSure.Size = new System.Drawing.Size(96, 13);
            this.lblKalanSure.TabIndex = 21;
            this.lblKalanSure.Text = "Tahmini kalan süre";
            // 
            // lblHiz
            // 
            this.lblHiz.AutoSize = true;
            this.lblHiz.Location = new System.Drawing.Point(138, 67);
            this.lblHiz.Name = "lblHiz";
            this.lblHiz.Size = new System.Drawing.Size(60, 13);
            this.lblHiz.TabIndex = 20;
            this.lblHiz.Text = "Aktarım hızı";
            // 
            // lblIndirilen
            // 
            this.lblIndirilen.AutoSize = true;
            this.lblIndirilen.Location = new System.Drawing.Point(138, 50);
            this.lblIndirilen.Name = "lblIndirilen";
            this.lblIndirilen.Size = new System.Drawing.Size(43, 13);
            this.lblIndirilen.TabIndex = 19;
            this.lblIndirilen.Text = "İndirilen";
            // 
            // lblBoyut
            // 
            this.lblBoyut.AutoSize = true;
            this.lblBoyut.Location = new System.Drawing.Point(138, 33);
            this.lblBoyut.Name = "lblBoyut";
            this.lblBoyut.Size = new System.Drawing.Size(34, 13);
            this.lblBoyut.TabIndex = 18;
            this.lblBoyut.Text = "Boyut";
            // 
            // lblDurum
            // 
            this.lblDurum.AutoSize = true;
            this.lblDurum.Location = new System.Drawing.Point(138, 9);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(38, 13);
            this.lblDurum.TabIndex = 17;
            this.lblDurum.Text = "Durum";
            // 
            // lbl_klnsure
            // 
            this.lbl_klnsure.AutoSize = true;
            this.lbl_klnsure.Location = new System.Drawing.Point(12, 84);
            this.lbl_klnsure.Name = "lbl_klnsure";
            this.lbl_klnsure.Size = new System.Drawing.Size(96, 13);
            this.lbl_klnsure.TabIndex = 15;
            this.lbl_klnsure.Text = "Tahmini kalan süre";
            // 
            // lbl_hiz
            // 
            this.lbl_hiz.AutoSize = true;
            this.lbl_hiz.Location = new System.Drawing.Point(12, 67);
            this.lbl_hiz.Name = "lbl_hiz";
            this.lbl_hiz.Size = new System.Drawing.Size(60, 13);
            this.lbl_hiz.TabIndex = 14;
            this.lbl_hiz.Text = "Aktarım hızı";
            // 
            // lbl_indir
            // 
            this.lbl_indir.AutoSize = true;
            this.lbl_indir.Location = new System.Drawing.Point(12, 50);
            this.lbl_indir.Name = "lbl_indir";
            this.lbl_indir.Size = new System.Drawing.Size(43, 13);
            this.lbl_indir.TabIndex = 13;
            this.lbl_indir.Text = "İndirilen";
            // 
            // lbl_boyut
            // 
            this.lbl_boyut.AutoSize = true;
            this.lbl_boyut.Location = new System.Drawing.Point(12, 33);
            this.lbl_boyut.Name = "lbl_boyut";
            this.lbl_boyut.Size = new System.Drawing.Size(34, 13);
            this.lbl_boyut.TabIndex = 12;
            this.lbl_boyut.Text = "Boyut";
            // 
            // lbl_durum
            // 
            this.lbl_durum.AutoSize = true;
            this.lbl_durum.Location = new System.Drawing.Point(12, 9);
            this.lbl_durum.Name = "lbl_durum";
            this.lbl_durum.Size = new System.Drawing.Size(38, 13);
            this.lbl_durum.TabIndex = 11;
            this.lbl_durum.Text = "Durum";
            // 
            // pBarYuzde
            // 
            this.pBarYuzde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pBarYuzde.Location = new System.Drawing.Point(12, 114);
            this.pBarYuzde.MarqueeAnimationSpeed = 1;
            this.pBarYuzde.Name = "pBarYuzde";
            this.pBarYuzde.Size = new System.Drawing.Size(391, 23);
            this.pBarYuzde.Step = 1;
            this.pBarYuzde.TabIndex = 9;
            // 
            // lViewAyrintilar
            // 
            this.lViewAyrintilar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lViewAyrintilar.AutoArrange = false;
            this.lViewAyrintilar.FullRowSelect = true;
            this.lViewAyrintilar.GridLines = true;
            this.lViewAyrintilar.Location = new System.Drawing.Point(12, 166);
            this.lViewAyrintilar.MultiSelect = false;
            this.lViewAyrintilar.Name = "lViewAyrintilar";
            this.lViewAyrintilar.Size = new System.Drawing.Size(391, 198);
            this.lViewAyrintilar.TabIndex = 11;
            this.lViewAyrintilar.UseCompatibleStateImageBehavior = false;
            this.lViewAyrintilar.View = System.Windows.Forms.View.Details;
            this.lViewAyrintilar.Visible = false;
            // 
            // btnAyrintilar
            // 
            this.btnAyrintilar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAyrintilar.FlatAppearance.BorderSize = 0;
            this.btnAyrintilar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyrintilar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)), true);
            this.btnAyrintilar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAyrintilar.ImageIndex = 0;
            this.btnAyrintilar.ImageList = this.imagelAyrintiButon;
            this.btnAyrintilar.Location = new System.Drawing.Point(12, 140);
            this.btnAyrintilar.Name = "btnAyrintilar";
            this.btnAyrintilar.Size = new System.Drawing.Size(391, 23);
            this.btnAyrintilar.TabIndex = 10;
            this.btnAyrintilar.Text = "Ayrıntılar";
            this.btnAyrintilar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAyrintilar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAyrintilar.UseVisualStyleBackColor = true;
            this.btnAyrintilar.Click += new System.EventHandler(this.btnAyrintilar_Click);
            // 
            // imagelAyrintiButon
            // 
            this.imagelAyrintiButon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagelAyrintiButon.ImageStream")));
            this.imagelAyrintiButon.TransparentColor = System.Drawing.Color.Transparent;
            this.imagelAyrintiButon.Images.SetKeyName(0, "down.png");
            this.imagelAyrintiButon.Images.SetKeyName(1, "up.png");
            // 
            // bgWorkerIndir
            // 
            this.bgWorkerIndir.WorkerReportsProgress = true;
            this.bgWorkerIndir.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgWorkerIndir_DoWork);
            this.bgWorkerIndir.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgWorkerIndir_ProgressChanged);
            this.bgWorkerIndir.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgWorkerIndir_RunWorkerCompleted);
            // 
            // tmrDurumGuncelle
            // 
            this.tmrDurumGuncelle.Interval = 1000;
            this.tmrDurumGuncelle.Tick += new System.EventHandler(this.tmrDurumGuncelle_Tick);
            // 
            // frmGuncelle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 169);
            this.Controls.Add(this.lViewAyrintilar);
            this.Controls.Add(this.btnAyrintilar);
            this.Controls.Add(this.pBarYuzde);
            this.Controls.Add(this.pnlAyrintilar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(2000, 410);
            this.MinimumSize = new System.Drawing.Size(300, 208);
            this.Name = "frmGuncelle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmGuncelle";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGuncelle_FormClosing);
            this.Load += new System.EventHandler(this.frmGuncelle_Load);
            this.Shown += new System.EventHandler(this.frmGuncelle_Shown);
            this.pnlAyrintilar.ResumeLayout(false);
            this.pnlAyrintilar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlAyrintilar;
        private System.Windows.Forms.Label lblKalanSure;
        private System.Windows.Forms.Label lblHiz;
        private System.Windows.Forms.Label lblIndirilen;
        private System.Windows.Forms.Label lblBoyut;
        private System.Windows.Forms.Label lblDurum;
        private System.Windows.Forms.Label lbl_klnsure;
        private System.Windows.Forms.Label lbl_hiz;
        private System.Windows.Forms.Label lbl_indir;
        private System.Windows.Forms.Label lbl_boyut;
        private System.Windows.Forms.Label lbl_durum;
        private System.Windows.Forms.ProgressBar pBarYuzde;
        private System.Windows.Forms.ListView lViewAyrintilar;
        private System.Windows.Forms.Button btnAyrintilar;
        private System.ComponentModel.BackgroundWorker bgWorkerIndir;
        private System.Windows.Forms.ImageList imagelAyrintiButon;
        private System.Windows.Forms.Timer tmrDurumGuncelle;
        private System.Windows.Forms.Button btnDuraklat;
    }
}