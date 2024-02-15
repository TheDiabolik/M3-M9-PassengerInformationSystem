using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace M3YBSCommunication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                bool TekProcess;
                Mutex mx = new Mutex(true, "BenimGuzelMutexim", out TekProcess);
                if (!TekProcess)
                {
                    //MessageBox.Show("Başka bir kopya çalıştıramazsınız");
                    return;
                }

                //AppDomain.CurrentDomain.UnhandledException -= new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
                ThreadExceptionHandler.Init();


                ServiceHost host = new ServiceHost(typeof(M3YBSCommunication));



                host.Open();

                Console.WriteLine("Servis Çalışmaya Başladı...");
                Console.ReadKey(); 

            }
            catch (Exception ex)
            {
                Console.WriteLine("Main : " + ex.ToString());
            }

        }

        static class ThreadExceptionHandler
        {
            public static void Init()
            {
                // ThreadExceptionHandler'ı başlat
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            }
        }
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Console.WriteLine("Bir Hata İle Karşılaşıldı! \nLütfen Program Loglarına Bakınız...\nHata Mesajı : " + e.Exception.Message);
            //Logging.WriteLog(DateTime.Now.ToString(), e.Exception.Message.ToString(),
            //    e.Exception.StackTrace.ToString(), e.Exception.TargetSite.ToString(), "");
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("Bir Hata İle Karşılaşıldı! \nLütfen Program Loglarına Bakınız...\nHata Mesajı : " + (e.ExceptionObject as Exception).Message);

            Exception ex = (Exception)e.ExceptionObject;
        }
    }
}
