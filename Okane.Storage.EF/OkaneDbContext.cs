using Microsoft.EntityFrameworkCore;
using Okane.Domain;

namespace Okane.Storage.EF;

public class OkaneDbContext : DbContext
{
    public DbSet<Budget> Budgets { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<Category> Categories { get; set; }

    public OkaneDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Budget>().ToTable("Budgets");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
}