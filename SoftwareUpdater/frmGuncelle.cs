using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareUpdater
{
    public partial class frmGuncelle : Form
    {
        public frmGuncelle()
        {
            InitializeComponent();
        }

        string indirmeKonumu = Directory.GetCurrentDirectory() + @"\dwnld\";
        double indirilen = 0;
        string format = "";
        double oncekiIndirilen = 0;
        bool duraklat = false;

        private void frmGuncelle_Load(object sender, EventArgs e)
        {
            if (Updater.guncellemeBoyutu < 1000000)
                lblBoyut.Text = string.Format("{0:0.00 KB}", Updater.guncellemeBoyutu / 1024);
            else if (Updater.guncellemeBoyutu > 1000000)
                lblBoyut.Text = string.Format("{0:0.00 MB}", (Updater.guncellemeBoyutu / 1024) / 1024);

            tmrDurumGuncelle.Start();
        }

        private void frmGuncelle_Shown(object sender, EventArgs e)
        {
            bgWorkerIndir.RunWorkerAsync();
            lViewAyrintilar.Columns.Add("ID");
            lViewAyrintilar.Columns[0].Width = 25;

            lViewAyrintilar.Columns.Add("Versiyon");
            lViewAyrintilar.Columns[1].Width = 75;

            lViewAyrintilar.Columns.Add("Paket");
            lViewAyrintilar.Columns[2].Width = 40;

            lViewAyrintilar.Columns.Add("Durum");
            lViewAyrintilar.Columns[3].Width = 100;
            int islemid = 1;
            foreach (VersiyonBilgisi versiyon in Updater.guncellenebilir)
            {
                for (int i = 1; i <= versiyon.PaketSayisi; i++)
                {
                    ListViewItem item = new ListViewItem(islemid.ToString());
                    item.UseItemStyleForSubItems = false;
                    item.SubItems.Add(versiyon.Versiyon);
                    item.SubItems.Add(i.ToString());
                    item.SubItems.Add("Beklemede");
                    item.SubItems[3].ForeColor = Color.Orange;
                    lViewAyrintilar.Items.Add(item);
                    islemid++;
                }
            }
        }

        private void btnAyrintilar_Click(object sender, EventArgs e)
        {
            if (lViewAyrintilar.Visible)
            {
                this.Size = new Size(this.Size.Width, this.Size.Height - (lViewAyrintilar.Size.Height + 6));
                lViewAyrintilar.Visible = false;
                btnAyrintilar.Image = imagelAyrintiButon.Images[0];
            }
            else
            {
                lViewAyrintilar.Visible = true;
                btnAyrintilar.Image = imagelAyrintiButon.Images[1];
                this.Size = new Size(this.Size.Width, this.Size.Height + (lViewAyrintilar.Size.Height + 6));
            }
        }
        private void bgWorkerIndir_DoWork(object sender, DoWorkEventArgs e)
        {
            int islem = 0;
            try
            {
                if (!Directory.Exists(Directory.GetCurrentDirectory() + @"\dwnld"))
                    Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\dwnld");
                string uygulamaDizini = Updater.ftpServerAddress + UygulamaBilgisi.Namespace;
                foreach (VersiyonBilgisi versiyon in Updater.guncellenebilir)
                {
                    for (int j = 1; j <= Convert.ToInt32(versiyon.PaketSayisi); j++)
                    {
                        indirmeDurumuDegistir(islem, 0);
                        string dosyaAdi = versiyon.Versiyon + "-" + j.ToString() + ".zip";
                        if (!File.Exists(indirmeKonumu + dosyaAdi))
                        {
                            try
                            {
                                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uygulamaDizini + "/" + versiyon.Versiyon + "/" + j.ToString() + ".zip");
                                request.Credentials = new NetworkCredential(Updater.ftpUsername, Updater.ftpUserpw);
                                request.UseBinary = true;
                                request.Method = WebRequestMethods.Ftp.DownloadFile;

                                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                                Stream responseStream = response.GetResponseStream();
                                FileStream writer = new FileStream(indirmeKonumu + dosyaAdi, FileMode.Create);
                                int bufferSize = 2048;
                                int readCount;
                                byte[] buffer = new byte[bufferSize];

                                readCount = responseStream.Read(buffer, 0, bufferSize);

                                while (readCount > 0)
                                {
                                    writer.Write(buffer, 0, readCount);
                                    indirilen += readCount;
                                    bgWorkerIndir.ReportProgress(Convert.ToInt32((indirilen / Updater.guncellemeBoyutu) * 100));
                                    //Thread.Sleep(5);
                                    readCount = responseStream.Read(buffer, 0, bufferSize);
                                    while (duraklat)
                                    {
                                        Thread.Sleep(2000);
                                    }
                                }

                                indirmeDurumuDegistir(islem, 1);
                                responseStream.Close();
                                response.Close();
                                writer.Close();
                            }
                            catch (Exception ex) { ex.logKaydiEkle(); indirmeDurumuDegistir(islem, -1); }
                            finally
                            {
                                islem++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { ex.logKaydiEkle(); }
        }

        private void bgWorkerIndir_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Progress ilerlemesinde kullanıcıya iletilecek ilerleme durumu gibi bilgiler
            pBarYuzde.Value = e.ProgressPercentage;
            if (indirilen < 1000000) { lblIndirilen.Text = string.Format("{0:0.00 KB}", indirilen / 1024) + format + " " + string.Format("(%{0:0.00})", (indirilen / Updater.guncellemeBoyutu) * 100); }
            else if (indirilen > 1000000) { lblIndirilen.Text = string.Format("{0:0.00 MB}", (indirilen / 1024) / 1024) + format + " " + string.Format("(%{0:0.00})", (indirilen / Updater.guncellemeBoyutu) * 100); }

            //string.Format("{0:0.00 kb} / {1:0.00}", tmp_inen, tmp_dosyaboyutu);
            //lbl_indirsnc.Text = /*(inen / 1024).ToString("0.00 KB")+"/"*/ tmp_inen+inecekformat;
        }

        private void tmrDurumGuncelle_Tick(object sender, EventArgs e)
        {
            lblHiz.Text = string.Format("{0:0.00 KB/s}", ((indirilen - oncekiIndirilen)) / 1024f);
            double saniye = (Updater.guncellemeBoyutu - indirilen) / ((indirilen - oncekiIndirilen));
            lblKalanSure.Text = string.Format("{0:0} dakika {1:00} saniye",saniye/60,saniye%60); oncekiIndirilen = indirilen;
        }

        private void bgWorkerIndir_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnDuraklat.Enabled = false;
            lblDurum.ForeColor = Color.Green;
            lblDurum.Text = "Tamamlandı.";
            tmrDurumGuncelle.Stop();
            Thread.Sleep(3000);
            //zipten çıkarma işlemi için parametreleri oluştur
            string parametreler = UygulamaBilgisi.UygulamaAdi  + " ";

            foreach (VersiyonBilgisi p in Updater.guncellenebilir)
                parametreler += p.Versiyon + "-" + p.PaketSayisi + " ";

            //Zipten çıkarma işlemini başlat
            Process.Start("zipcikar.exe", parametreler);
            Environment.Exit(0);
        }

        private void indirmeDurumuDegistir(int indis, int durum)
        {
            if (durum == 0)
            {
                if (lViewAyrintilar.InvokeRequired)
                {
                    lViewAyrintilar.Invoke(new Action(() =>
                    {
                        lViewAyrintilar.Items[indis].SubItems[3].ForeColor = Color.Black;
                        lViewAyrintilar.Items[indis].SubItems[3].Text = "İndiriliyor...";
                    }));
                }
                else
                {
                    lViewAyrintilar.Items[indis].SubItems[3].ForeColor = Color.Black;
                    lViewAyrintilar.Items[indis].SubItems[3].Text = "İndiriliyor...";
                }
                if (lblDurum.InvokeRequired)
                    lblDurum.Invoke(new Action(() => { lblDurum.Text = "v" + lViewAyrintilar.Items[indis].SubItems[1].Text +" " +lViewAyrintilar.Items[indis].SubItems[2].Text + ". paket indiriliyor"; }));
                else lblDurum.Text = "v" + lViewAyrintilar.Items[indis].SubItems[1].Text + " " + lViewAyrintilar.Items[indis].SubItems[2].Text + ". paket indiriliyor";
            }
            else if (durum == 1)
            {
                if (lViewAyrintilar.InvokeRequired)
                {
                    lViewAyrintilar.Invoke(new Action(() =>
                    {
                        lViewAyrintilar.Items[indis].SubItems[3].ForeColor = Color.Green;
                        lViewAyrintilar.Items[indis].SubItems[3].Text = "Tamamlandı.";
                    }));
                }
                else
                {
                    lViewAyrintilar.Items[indis].SubItems[3].ForeColor = Color.Green;
                    lViewAyrintilar.Items[indis].SubItems[3].Text = "Tamamlandı.";
                }
                if (lblDurum.InvokeRequired)
                    lblDurum.Invoke(new Action(() => { lblDurum.Text = "İndirme işlemi tamamlandı."; }));
                else lblDurum.Text = "İndirme işlemi tamamlandı.";
            }
            if (durum == -1)
            {
                if (lViewAyrintilar.InvokeRequired)
                {
                    lViewAyrintilar.Invoke(new Action(() =>
                    {
                        lViewAyrintilar.Items[indis].SubItems[3].ForeColor = Color.Red;
                        lViewAyrintilar.Items[indis].SubItems[3].Text = "Hata. İndirilemedi.";
                    }));
                }
                else
                {
                    lViewAyrintilar.Items[indis].SubItems[3].ForeColor = Color.Red;
                    lViewAyrintilar.Items[indis].SubItems[3].Text = "Hata. İndirilemedi.";
                }

                if (lblDurum.InvokeRequired)
                    lblDurum.Invoke(new Action(() => { lblDurum.Text = "İndirme tamamlanamadı. Bir hata meydana geldi."; }));
                else lblDurum.Text = "İndirme tamamlanamadı. Bir hata meydana geldi.";
            }


        }


        private void frmGuncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnDuraklat_Click(object sender, EventArgs e)
        {
            if (!duraklat)
            {
                btnDuraklat.Text ="Başlat";
                duraklat = true;
                tmrDurumGuncelle.Stop();
                lblHiz.Text = string.Format("{0:0.00 KB/s}", 0.00);
                lblKalanSure.Text = "-";
            }
            else if (duraklat)
            {
                btnDuraklat.Text = "Duraklat";
                duraklat = false;
                tmrDurumGuncelle.Start();
            }
        }
    }
}
