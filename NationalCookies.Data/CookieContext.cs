using Microsoft.EntityFrameworkCore;

namespace NationalCookies.Data
{
    public class CookieContext : DbContext
    {

        public CookieContext(DbContextOptions options) : base (options)
        {
            
        }

        public CookieContext()
        {
           
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<Cookie> Cookies { get; set; }
    }
}
