using BusinnessApi.Context;
using BusinnessApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;

namespace BusinnessApi.Services
{
    public class CurrencyService : ICurrencyService 
    {
        private readonly AppBusinessDbContext _context;
        private readonly IMemoryCache _cache;

        public CurrencyService(AppBusinessDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<IList<Currency>> GetCurrencyListAsync(Expression<Func<Currency, bool>> filter)
        {
           
               var result = await _context.Set<Currency>().Where(filter).ToListAsync();

           
            return result;
        }


        public IQueryable<Currency> GetListAsync() => _context.Set<Currency>().AsQueryable();
    }
}
