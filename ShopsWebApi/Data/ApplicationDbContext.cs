using Microsoft.EntityFrameworkCore;
using ShopsWebApi.Models;

namespace ShopsWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureDeleted();

            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
                {
                new User {Id=1, Login="admin", Password="123456789", Role = Role.Admin},
                new User {Id=2, Login="courier", Password="123456789", Role = Role.Courier},
                });
            modelBuilder.Entity<Customer>().HasData(new Customer[]
                {
                new Customer {Id=1, Name="Илья", City="Снов", Street="Карчмита", HomeNum= 2},
                new Customer {Id=2, Name="Женя", City="Минск", Street="Ленина", HomeNum= 4},
                new Customer {Id=3, Name="Оля", City="Брест", Street="Пушкина", HomeNum= 12}
                });
            modelBuilder.Entity<Shop>().HasData(new Shop[]
                {
                new Shop {Id=1, Name="Комунарка", City="Минск", Street="Гагарина", HomeNum= 5},
                new Shop {Id=2, Name="Пищевик", City="Бобруйск", Street="Столинская", HomeNum= 9},
                new Shop {Id=3,  Name="Coca-Cola", City="Рогичин", Street="Первомайская", HomeNum= 21}
                });
            modelBuilder.Entity<Product>().HasData(new Product[]
                {
                new Product {Id=1, Name="Зефир", ShopId=1, Color="Зелёный", Price=2.15},
                new Product {Id=2, Name="Зефир", ShopId=1, Color="Красный", Price=5},
                new Product {Id=3, Name="Зефир", ShopId=2, Color="Синий", Price=4.19},
                new Product {Id=4, Name="Зефир", ShopId=2, Color="Белый", Price=1.51},
                new Product {Id=5, Name="Зефир", ShopId=3, Color="Розовый", Price=2},
                new Product {Id=6, Name="Зефир", ShopId=3, Color="Фиолетовый", Price=3.28},

                });
            modelBuilder.Entity<Order>().HasData(new Order[]
                {
                new Order {Id=1, CustomerId = 1, Status = OrderStatus.Active},
                new Order {Id=2, CustomerId = 1, Status = OrderStatus.Complete},
                new Order {Id=3, CustomerId = 2, Status = OrderStatus.Active},
                new Order {Id=4, CustomerId = 3, Status = OrderStatus.Active},
            });
            modelBuilder.Entity<OrderProduct>().HasData(new OrderProduct[]
                {
                new OrderProduct {Id=1, OrderId = 1, ProductId=1},
                new OrderProduct {Id=2, OrderId = 1, ProductId=2},
                new OrderProduct {Id=3, OrderId = 2, ProductId=3},
                new OrderProduct {Id=4, OrderId = 2, ProductId=4},
                new OrderProduct {Id=5, OrderId = 3, ProductId=5},
                new OrderProduct {Id=6, OrderId = 3, ProductId=6},
                new OrderProduct {Id=7, OrderId = 4, ProductId=2},
                new OrderProduct {Id=8, OrderId = 4, ProductId=4}
            });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Product> Products{ get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Customer> Customers { get; set; }
    }
}
