using System.ComponentModel.DataAnnotations;

namespace BusinnessApi.Models
{
    public class Currency
    {
        [Key, Required]
        public int Id { get; set; }
        public string? CurrencyName { get; set; }
        public string? CurrencyCode { get; set; }
        public decimal? ForexBuying { get; set; }
        public decimal? ForexSelling { get; set; }
        public string Date { get; set; }
    }
}
