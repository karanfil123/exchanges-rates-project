using BusinnessApi.Models;
using System.Linq.Expressions;

namespace BusinnessApi.Services
{
    public interface ICurrencyService
    {
        Task<IList<Currency>> GetCurrencyListAsync(Expression<Func<Currency, bool>> filter);
        IQueryable<Currency> GetListAsync();
    }
}
