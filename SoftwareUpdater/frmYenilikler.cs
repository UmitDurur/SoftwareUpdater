using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareUpdater
{
    public partial class frmYenilikler : Form
    {
        public frmYenilikler()
        {
            InitializeComponent();
        }
        
        private void frmYenilikler_Load(object sender, EventArgs e)
        {
            if (Updater.guncellemeBoyutu < 1000000)
                lblGuncellemeBoyutu.Text += string.Format("{0:0.00 KB}", Updater.guncellemeBoyutu / 1024);
            else if (Updater.guncellemeBoyutu > 1000000)
                lblGuncellemeBoyutu.Text += string.Format("{0:0.00 MB}", (Updater.guncellemeBoyutu / 1024) / 1024);
            Point nokta = new Point(10, 20);
            foreach (VersiyonBilgisi versiyon in Updater.guncellenebilir)
            {
                if (versiyon != null)
                {
                    Label lbl = new Label();
                    lbl.AutoSize = true;
                    lbl.MaximumSize = new Size(this.Size.Width - 50, 0);
                    lbl.Text = "\n" + versiyon.Versiyon + "\n--------------------------------------------------------------------------------------------\n" + versiyon.GuncellemeNotu;
                    lbl.Location = nokta;
                    pnlGuncellestirmeNotlari.Controls.Add(lbl);
                    nokta.Y += lbl.Size.Height + 20;
                }
            }
        }

        private void frmYenilikler_Shown(object sender, EventArgs e)
        {

            foreach (VersiyonBilgisi versiyon in Updater.guncellenebilir)
                if (versiyon.Zorunlu != 0)
                {
                    btnAtla.Enabled = false;
                    break;
                }
            btnGuncelle.Focus();
        }

        private void btnAtla_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Ignore;
            this.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmYenilikler_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK&&this.DialogResult!=DialogResult.Ignore)
            Environment.Exit(0);
        }
    }
}
