using CoffeeShopAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShopAPI.DBLayer
{
    public class CoffeeShopDbContext : DbContext
    {
       
        public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options) : base(options) { 
        
        }

        public DbSet<CoffeeShop> CoffeeShops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<CoffeeShop>(builder =>
            {
                builder.ToTable("CoffeeShop", tablebuilder =>
                {
                    //it is helpful to write table constrains 

                });
                builder.HasKey(x => x.Id);
                builder.Property(p => p.CoffeeShopName).HasMaxLength(100).IsRequired();
                builder.Property(p => p.CoffeeShopDescription).HasMaxLength(150);
                builder.Property(p => p.IsOpen);
                builder.Property(p => p.CreationDateTime);

            });


            #region CoffeeShopSeed
            modelBuilder.Entity<CoffeeShop>().HasData(new List<CoffeeShop>()
            {
                new CoffeeShop { Id = Guid.NewGuid(), IsOpen = true, CoffeeShopName = "Star BUcks", CoffeeShopDescription = "Great and Lavish Place", CreationDateTime = DateTime.Now },
                new CoffeeShop { Id = Guid.NewGuid(), IsOpen = true, CoffeeShopName = "Barista", CoffeeShopDescription = "The Great Coffee shop", CreationDateTime = DateTime.Now },
                new CoffeeShop { Id = Guid.NewGuid(), IsOpen = true, CoffeeShopName = "The Filter Coffee", CoffeeShopDescription = "The US Brand Coffee shop", CreationDateTime = DateTime.Now }

            });
               
            #endregion
        }
    }
}
