using BusinnessApi.Models;
using BusinnessApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinnessApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchageRateController : ControllerBase
    {
        private readonly ICurrencyService _service;


        public ExchageRateController(ICurrencyService service)
        {
            _service = service;
        }


        [HttpGet("rates")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetListAsync().ToListAsync();
            return Ok(result);
        }

        [HttpGet("rates/{currencyCode}")]
        public async Task<IActionResult> GetAll(string currencyCode)
        {
            var result = await _service.GetCurrencyListAsync(x => x.CurrencyCode.ToUpper() == currencyCode.ToUpper());
            return Ok(result);
        }

    }
}
