using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Okane.Storage.EF;

public class DbContextFactory : IDesignTimeDbContextFactory<OkaneDbContext>
{
    private const string AppSettingsFileName = "appsettings.json";

    public OkaneDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(AppSettingsFileName)
            .Build();

        var connectionString = configuration.GetConnectionString("Default");
        
        var optionsBuilder = new DbContextOptionsBuilder<OkaneDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new OkaneDbContext(optionsBuilder.Options);
    }
}