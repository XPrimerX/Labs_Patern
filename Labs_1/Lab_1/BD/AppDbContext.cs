using Lab_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab_1.BD;

public class AppDbContext : DbContext
{
    private readonly string _connectionString;

    public AppDbContext(string dbPath = "app.db")
    {
        _connectionString = dbPath;
    }

    public DbSet<Transaction> Transactions => Set<Transaction>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={_connectionString}");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(t => t.Id);
            entity.Property(t => t.Amount).HasColumnType("TEXT");
        });
    }
}