using Microsoft.EntityFrameworkCore;

namespace TuringApi.Models
{
    public class TuringContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<CashClose> CashCloses { get; set; }
        public DbSet<CashMov> CashMovs { get; set; }
        public DbSet<CashMovType> CashMovTypes { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sell> Sells { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockMov> StockMovs { get; set; }
        public DbSet<StockMovType> StockMovTypes { get; set; }
        public DbSet<SubCategorie> SubCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public TuringContext(DbContextOptions options) : base(options) { }
    }
}
