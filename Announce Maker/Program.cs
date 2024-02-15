using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnnounceMaker
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            //Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
        }

        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show("Bir Hata İle Karşılaşıldı! \nLütfen Program Loglarına Bakınız...\nHata Mesajı : " + e.Exception.Message, "UserMessages.MessageCaptionMessage", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Logging.WriteLog(DateTime.Now.ToString(), e.Exception.Message.ToString(),
            //    e.Exception.StackTrace.ToString(), e.Exception.TargetSite.ToString(), "");
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            //System.Diagnostics.Process.Start(
            //System.Reflection.Assembly.GetEntryAssembly().Location,
            //string.Join(" ", Environment.GetCommandLineArgs()));
            //Environment.Exit(1);

            MessageBox.Show("Bir Hata İle Karşılaşıldı! \nLütfen Program Loglarına Bakınız...\nHata Mesajı : " + (e.ExceptionObject as Exception).Message, "UserMessages.MessageCaptionMessage", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Exception ex = (Exception)e.ExceptionObject;

            //Logging.WriteLog(DateTime.Now.ToString(), ex.Message.ToString(),
            //    ex.StackTrace.ToString(), ex.TargetSite.ToString(), "");
        }
    }
}
