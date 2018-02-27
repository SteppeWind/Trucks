using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using Trucks.Domain;

namespace Trucks.Data.Infrastructure
{
    public class TrucksDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Point> Points { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Settings> Settingses { get; set; }
        public DbSet<City> Cities { get; set; }

        public TrucksDbContext() : base("TrucksDb")
        {            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasRequired(o => o.Truck)
                .WithOptional(t => t.Order);

            modelBuilder.Entity<Point>()
                .Ignore(p => p.DisplayAddress);

            modelBuilder.Entity<Order>()
                .HasRequired(o => o.ToPoint)
                .WithMany(o => o.ToPointOrders)
                .HasForeignKey(p => p.ToPointId);

            modelBuilder.Entity<Order>()
                .HasRequired(o => o.FromPoint)
                .WithMany(o => o.FromPointOrders)
                .HasForeignKey(p => p.FromPointId);

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();           
        }
    }
}