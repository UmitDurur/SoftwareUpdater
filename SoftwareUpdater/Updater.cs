using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.IO;
using System.Net;

namespace SoftwareUpdater
{
    public static class Updater
    {
        public readonly static string apiServerAddress, ftpServerAddress, ftpUsername, ftpUserpw;
        public static VersiyonBilgisi[] guncellenebilir;
        public static double guncellemeBoyutu = 0;


        static Updater()
        {
            apiServerAddress = Bilesenler.getSetting("updater_api_service_address");
            ftpServerAddress = Bilesenler.getSetting("updater_ftp_address");
            ftpUsername = Bilesenler.getSetting("ftp_username");
            ftpUserpw = Bilesenler.DESCoz(Bilesenler.getSetting("ftp_password"));
        }

        /// <summary>
        /// Güncelleme kontrol sınıfı
        /// </summary>
        /// <param name= "_namespace">Güncellenecek uygulamanın isim uzayı</param>
        /// <param name="_versiyon">Uygulamanın şuan ki versiyonu</param>
        /// <param name="_uygulamaAdi">Uygulama başlatıcısının adı</param>
        public static void KontrolEt(string _namespace, string _versiyon, string _uygulamaAdi)
        {
            UygulamaBilgisi.Namespace = _namespace;
            UygulamaBilgisi.UygulamaAdi = _uygulamaAdi;
            UygulamaBilgisi.Versiyon = _versiyon;
            KontrolEt();
        }

        public static void KontrolEt()
        {
            if (string.IsNullOrWhiteSpace(UygulamaBilgisi.Namespace) || string.IsNullOrWhiteSpace(UygulamaBilgisi.UygulamaAdi) || string.IsNullOrWhiteSpace(UygulamaBilgisi.Versiyon))
            {
                Bilesenler.logKaydiEkle(new NullReferenceException("Güncelleme için uygulama bilgisi eksik girildi."));
                return;
            }
            frmGuncellemeBildirimi bildirim = new frmGuncellemeBildirimi();
            bildirim.Location = new System.Drawing.Point(Screen.PrimaryScreen.WorkingArea.Width - bildirim.Width, Screen.PrimaryScreen.WorkingArea.Height - bildirim.Height);
            Task.Run(() => Application.Run(bildirim));

            string link = string.Format("{0}versiyon/{1}/{2}", apiServerAddress, UygulamaBilgisi.Namespace, UygulamaBilgisi.Versiyon);
            HttpWebRequest istek = (HttpWebRequest)WebRequest.Create(link);
            try
            {
                WebResponse cevap = istek.GetResponse();
                using (StreamReader okuyucu = new StreamReader(cevap.GetResponseStream(),Encoding.UTF8))
                {
                    guncellenebilir = new JavaScriptSerializer().Deserialize<VersiyonBilgisi[]>(okuyucu.ReadToEnd());
                }
            }
            catch (Exception ex) { ex.logKaydiEkle(); }

            if (guncellenebilir == null)
            {
                BildirimKapat(bildirim);
                return;
            }
            for (int i = 0; i < guncellenebilir.Count(); i++)
            {
                for (int j = 1; j <= Convert.ToInt32(guncellenebilir[i].PaketSayisi); j++)
                {
                    try
                    {
                        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServerAddress + UygulamaBilgisi.Namespace + "/" + guncellenebilir[i].Versiyon + "/" + j.ToString() + ".zip");
                        request.Credentials = new NetworkCredential(ftpUsername,ftpUserpw);
                        request.Method = WebRequestMethods.Ftp.GetFileSize;
                        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                        guncellemeBoyutu += response.ContentLength;
                        response.Close();
                    }
                    catch (Exception ex) { ex.logKaydiEkle(); }
                }
            }

            BildirimKapat(bildirim);

            frmYenilikler form = new frmYenilikler();
            DialogResult sonuc = form.ShowDialog();
            if (sonuc == DialogResult.OK)
            {
                frmGuncelle guncelle = new frmGuncelle();
                guncelle.ShowDialog();
            }
        }


        private static void BildirimKapat(frmGuncellemeBildirimi bildirim)
        {
            if (bildirim.InvokeRequired)
                bildirim.Invoke(new Action(() => bildirim.Close()));
            else bildirim.Close();
        }

    }
}