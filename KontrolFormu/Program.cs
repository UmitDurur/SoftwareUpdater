using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using SoftwareUpdater;
using System.Diagnostics;

namespace KontrolFormu
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            string Namespace =Assembly.GetExecutingAssembly().GetName().Name;
            string uygulamaAdi= System.Reflection.Assembly.GetEntryAssembly().Location.Substring(Assembly.GetEntryAssembly().Location.LastIndexOf('\\') + 1);
            string versiyon =  FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location).FileVersion;
            Updater.KontrolEt(Namespace, versiyon, uygulamaAdi);

            Application.Run(new Form1());
        }

    }
}
