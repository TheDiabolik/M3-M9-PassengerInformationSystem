using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPUMessenger
{
     class ExceptionMessages
    {
        internal static string SerilizationSettingsExceptionMessage = "Ayarlar Kaydedilemedi!";
        internal static string DeSerilizationSettingsExceptionMessage =  "Ayarlar Okunamadı!";
        internal static string CheckSerilizationFileExceptionMessage = "Ayarlar Dosyası Bulanamadı!";
        internal static string LoggingExceptionMessage = "Log Yazılamadı!";
        internal static string AddVariablesResponseExceptionMessage = "MPU'ya Değişken Eklemek İçin Gönderilecek Paket Oluşturulamadı!";
        internal static string AddVariablesExceptionMessage = "MPU'ya Değişken Sorgulama Paketleri Gönderilemedi!";
        internal static string PrepareGetVariablesXML = "MPU'ya Değişken Talep Paketi Oluşturulamadı!";
        internal static string TimerGetVariablesXML = "Değişken Talep Timer Başlatılamadı!";
        internal static string GetVariablesExceptionMessage = "MPU'ya Değişken Değerleri Talep Paketleri Gönderilemedi!";
        internal static string ParseGetVariablesExceptionMessage = "MPU'dan Gelen Değişken Mesajı Okunamadı!";


        internal static string ReConnectMPURedundancyServiceExceptionMessage = "MPU Yedeklilik Servisine Tekrar Bağlantı Hatası!";
        internal static string ConnectMPURedundancyServiceExceptionMessage = "MPU Yedeklilik Servisine Bağlantı Hatası!";
        internal static string StopMPURedundancyServiceExceptionMessage = "MPU Yedeklilik Servisine Bağlantısını Durdurma Hatası!";
    }
}
