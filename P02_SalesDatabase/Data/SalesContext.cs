using Microsoft.EntityFrameworkCore;
using P02_SalesDatabase.Models;

namespace P02_SalesDatabase.Data;

public class SalesContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Store> Stores { get; set; }

    public DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=3MOELJO\\SQLEXPRESS;Database=SalesDatabase;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}