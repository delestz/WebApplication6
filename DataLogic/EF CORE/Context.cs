using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using DataLogic.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DataLogic
{
    public class Context : DbContext
    {
        public DbSet<Buyer> buyer { get; set; }
        public DbSet<Product> product { get; set; }
        public DbSet<Order> order { get; set; }
        override protected void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=ASPMagazineV1;Trusted_Connection=True;");
        }
        override protected void OnModelCreating(ModelBuilder modelBuilder)
        {
            var file = JsonConvert.DeserializeObject<products>(File.ReadAllText(@"C:\Users\Kekozavrishe\source\repos\WebApplication6\DataLogic\DataForCreating\dbData.json"));
            for (int i = 0; i < file.Products.Length; i++)
            {
                modelBuilder.Entity<Product>().HasData(new Product()
                {
                    Id = i + 1,
                    ProductName = file.Products[i].ProductName,
                    Catagery = (Category)System.Enum.Parse(typeof(Category), file.Products[i].Category),
                    Price = file.Products[i].Price,
                    Cpecific = file.Products[i].Cpecific,
                    ProductImg = File.ReadAllBytes($@"C:\Users\Kekozavrishe\source\repos\WebApplication6\DataLogic\ByteImgs\{file.Products[i].ProductName}.jpg")
                });
            }
        }
    }
    public class products
    {
        public product[] Products;
        public class product
        {
            public string ProductName { get; set; }
            public string Category { get; set; }
            public string Cpecific { get; set; }
            public double Price { get; set; }
        }
    }
}
