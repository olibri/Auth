using Microsoft.EntityFrameworkCore;
using Sprint16.Models;

namespace Sprint16.Data
{
    public class ShoppingContext : DbContext
    {
        public ShoppingContext(DbContextOptions<ShoppingContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Supermarket> Supermarkets { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<BuyerType> BuyerTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "admin";
            string userRoleName = "user";

            Role adminRole = new Role { Id= 1, Name= adminRoleName };
            Role userRole = new Role { Id=2, Name = userRoleName };

            modelBuilder.Entity<Role>().HasData(new Role[] {adminRole, userRole});

            base.OnModelCreating(modelBuilder);
        }

    }
}
