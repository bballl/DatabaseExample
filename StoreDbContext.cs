using Microsoft.EntityFrameworkCore;

namespace DatabaseExampleEFCore
{
    internal class StoreDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StoreDatabase;Trusted_Connection=True;");
        }
    }
}
