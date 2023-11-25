
using System;
using System.Net;
using System.Xml;

class Program
{
    static void Main()
    {
        // Başlangıç ve bitiş tarihlerini belirleyin
        DateTime startDate = DateTime.Now.AddMonths(-2);
        DateTime endDate = DateTime.Now;

        // Her gün için döviz kurlarını al
        for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
        {
            string url = "https://www.tcmb.gov.tr/kurlar/" + date.ToString("yyyyMM") + "/" + date.ToString("ddMMyyyy") + ".xml";
            using (WebClient client = new WebClient())
            {
                try
                {
                    string xmlContent = client.DownloadString(url);
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(xmlContent);

                    XmlNodeList currencyNodes = xmlDocument.SelectNodes("//Currency");
                    foreach (XmlNode currencyNode in currencyNodes)
                    {
                        string currencyCode = currencyNode.Attributes["CurrencyCode"].Value;
                        string currencyName = currencyNode["CurrencyName"].InnerText;
                        string forexBuying = currencyNode["ForexBuying"].InnerText;
                        string forexSelling = currencyNode["ForexSelling"].InnerText;

                        Console.WriteLine("Tarih: {0}, Para Birimi: {1} ({2}), Alış Kuru: {3}, Satış Kuru: {4}", date.ToString("dd/MM/yyyy"), currencyName, currencyCode, forexBuying, forexSelling);
                    }
                }
                catch (WebException)
                {
                    // Belirtilen tarihte bir XML dosyası yoksa hata oluşabilir, bu durumda döngüyü devam ettirin
                    continue;
                }
            }
        }
    }
}