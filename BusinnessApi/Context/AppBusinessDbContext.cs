using BusinnessApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BusinnessApi.Context
{
    public class AppBusinessDbContext:DbContext
    {
        public AppBusinessDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Currency> Currencies { get; set; }
    }
}
