using Microsoft.EntityFrameworkCore;

namespace ProjetoPratico.Models
{
    public class Context : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categorys { get; set; }

        public Context(DbContextOptions<Context> options) : base(options) 
        {

        }
    }
}
