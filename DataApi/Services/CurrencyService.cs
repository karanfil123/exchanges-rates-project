using DataApi.Context;
using DataApi.Models;
using System.Net;
using System.Xml;

namespace DataApi.Services
{
    public class CurrencyService
    {
        private readonly AppDbContext _context;
        public CurrencyService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddTwoMountsCurrencyData()
        {
            DateTime startDate = DateTime.Now.AddMonths(-2);
            DateTime endDate = DateTime.Now;

            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    string url = "https://www.tcmb.gov.tr/kurlar/" + date.ToString("yyyyMM") + "/" + date.ToString("ddMMyyyy") + ".xml";

                    try
                    {
                        using (WebClient client = new WebClient())
                        {
                            string xmlContent = await client.DownloadStringTaskAsync(url);
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.LoadXml(xmlContent);

                            XmlNodeList currencyNodes = xmlDocument.SelectNodes("//Currency");
                            foreach (XmlNode currencyNode in currencyNodes)
                            {
                                string currencyCode = currencyNode.Attributes["CurrencyCode"].Value;
                                string currencyName = currencyNode["Isim"].InnerText;
                                string forexBuying = currencyNode["ForexBuying"].InnerText;
                                string forexSelling = currencyNode["ForexSelling"].InnerText;

                                if (!string.IsNullOrEmpty(currencyCode) &&
                                    !string.IsNullOrEmpty(currencyName) &&
                                    decimal.TryParse(forexBuying, out decimal forexBuyingValue) &&
                                    decimal.TryParse(forexSelling, out decimal forexSellingValue))
                                {
                                    var currency = new Currency
                                    {
                                        CurrencyCode = currencyCode,
                                        CurrencyName = currencyName,
                                        ForexBuying = forexBuyingValue,
                                        ForexSelling = forexSellingValue,
                                        Date = date.ToString(),
                                    };
                                    await _context.Currencies.AddAsync(currency);
                                }
                            }
                            await _context.SaveChangesAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Güncellenme işlemi başarısız oldu!!! - Hata: " + ex.Message);
                    }
                }
            }
        }


    }
}

