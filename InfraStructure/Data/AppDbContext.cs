﻿using Domain;
using IMS.Application.InterFaces;
using Microsoft.EntityFrameworkCore;

namespace InfraStructure.Data
{
    public class AppDbContext : DbContext,IAppDbContext  
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Product> Products { get; set; }
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
              modelBuilder.Entity<Inventory>().HasData(
              new Inventory { InventoryId = 1, InventoryName = "Gas Engine", Price = 1000, Quantity = 1 },
              new Inventory { InventoryId = 2, InventoryName = "Body", Price = 400, Quantity = 1 },
              new Inventory { InventoryId = 3, InventoryName = "Wheel", Quantity = 4, Price = 100 },
              new Inventory { InventoryId = 4, InventoryName = "Seat", Price = 50, Quantity = 5 },
              new Inventory { InventoryId = 5, InventoryName = "Electric Engine", Price = 8000, Quantity = 2 },
              new Inventory { InventoryId = 6, InventoryName = "Battery", Price = 400, Quantity = 5 }
              
          );
            modelBuilder.Entity<Product>().HasData(
             new Product { ProductId = 1, ProductName = "Car", Price = 1000, Quantity = 1 },
             new Product { ProductId = 2, ProductName = "Bike", Price = 400, Quantity = 1 },
             new Product { ProductId = 3, ProductName = "Truck", Quantity = 4, Price = 100 },
             new Product { ProductId = 4, ProductName = "Auto", Price = 50, Quantity = 5 },
             new Product { ProductId = 5, ProductName = " Jeep", Price = 8000, Quantity = 2 },
             new Product { ProductId = 6, ProductName = "Caravan", Price = 400, Quantity = 5 }

         );

        }


    }
    

}
