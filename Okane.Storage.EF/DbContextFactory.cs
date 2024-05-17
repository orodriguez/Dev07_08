using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Okane.Storage.EF;

public class DbContextFactory : IDesignTimeDbContextFactory<OkaneDbContext>
{
    public OkaneDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<OkaneDbContext>();
        optionsBuilder.UseNpgsql(
            "Host=localhost;Port=5432;Database=OkaneDev;Username=postgres;Password=1234;");

        return new OkaneDbContext(optionsBuilder.Options);
    }
}