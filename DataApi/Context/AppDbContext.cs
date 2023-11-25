using DataApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DataApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Currency> Currencies => Set<Currency>();

    }
}
