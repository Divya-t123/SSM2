using Microsoft.EntityFrameworkCore;

namespace SSM2.Models
{
    public class AppdbContext:DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> options) : base(options)
        {
        }
        public DbSet<User> user{ get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Category> Category{ get; set; }
        public DbSet<Cart> cart { get; set; }
        public DbSet<User_Role> user_role { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SOS;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        
    }
}
