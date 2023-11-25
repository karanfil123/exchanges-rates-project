using DataApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyService _currencyService;

        public CurrencyController(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpPost("addcCurrencyData")]
        public async Task<IActionResult> AddTwoMountsCurrencyData()
        {
            try
            {
                await _currencyService.AddTwoMountsCurrencyData();
                return Ok("Para birimi verileri başarıyla eklendi!!!");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ekleme işlemi başarısız oldu!!! - Hata: {ex.Message}");
            }
        }

    }
}
