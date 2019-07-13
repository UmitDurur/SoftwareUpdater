using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Script.Serialization;

namespace SoftwareUpdater
{
    public static class Bilesenler
    {
        static Dictionary<string, object> SETTINGS;
        static readonly string ERRORLOG_FILE_PATH;

        static Bilesenler()
        {
            SETTINGS = (Dictionary<string, object>)new JavaScriptSerializer().DeserializeObject(new StreamReader("UpdaterSettings.json").ReadToEnd());
            ERRORLOG_FILE_PATH = getSetting("errorlog_file_path");
        }

        public static string getSetting(string settingKey)
        {
            return SETTINGS.Where(ayar => ayar.Key.Contains(settingKey)).FirstOrDefault().Value.ToString();
        }



        public static void logKaydiEkle(this Exception error)
        {
            //string konum = getSetting("errorlog_location");
            File.AppendAllText(ERRORLOG_FILE_PATH, "["+DateTime.Now +"] - "+error.ToString() + Environment.NewLine);
        }

        public static string DESCoz(string strGiris)
        {
            string strSonuc = "";
            if (strGiris == "" || strGiris == null)
            {
                throw new ArgumentNullException("Şifrelenecek veri yok.");
            }
            else
            {
                byte[] aryKey = Byte8("des_key");
                byte[] aryIV = Byte8("des_IV");
                DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream(Convert.FromBase64String(strGiris));
                CryptoStream cs = new CryptoStream(ms, cryptoProvider.CreateDecryptor(aryKey, aryIV), CryptoStreamMode.Read);
                StreamReader reader = new StreamReader(cs);
                strSonuc = reader.ReadToEnd();
                reader.Dispose();
                cs.Dispose();
                ms.Dispose();
            }
            return strSonuc;
        }

        private static byte[] ByteDonustur(string deger)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            return ByteConverter.GetBytes(deger);
        }

        private static byte[] Byte8(string deger)
        {
            char[] arrayChar = deger.ToCharArray();
            byte[] arrayByte = new byte[arrayChar.Length];
            for (int i = 0; i < arrayByte.Length; i++)
            {
                arrayByte[i] = Convert.ToByte(arrayChar[i]);
            }
            return arrayByte;
        }

    }

    public class VersiyonBilgisi
    {
        private string versiyon;
        public string Versiyon
        { get { return versiyon; } set { versiyon = value; } }

        private int paketSayisi;
        public int PaketSayisi
        { get { return paketSayisi; } set { paketSayisi = value; } }

        private byte zorunlu;
        public byte Zorunlu
        { get { return zorunlu; } set { zorunlu = value; } }

        private string guncellemeNotu;
        public string GuncellemeNotu
        { get { return guncellemeNotu; } set { guncellemeNotu = value; } }
    }
    public static class UygulamaBilgisi
    {
        private static string uygNamespace;
        public static string Namespace
        { get { return uygNamespace; } set { uygNamespace = value; } }

        private static string versiyon;
        public static string Versiyon
        { get { return versiyon; } set { versiyon = value; } }

        private static string uygulamaAdi;
        public static string UygulamaAdi
        { get { return uygulamaAdi; } set { uygulamaAdi = value; } }


    }


}
