using Microsoft.EntityFrameworkCore;
using Okane.Domain;

namespace Okane.Storage.EF;

public class OkaneDbContext : DbContext
{
    public DbSet<Expense> Expenses { get; set; }
    
    public OkaneDbContext(DbContextOptions options) : base(options)
    {
    }
}