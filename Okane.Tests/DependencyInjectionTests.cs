using Microsoft.Extensions.DependencyInjection;

namespace Okane.Tests;

public class DependencyInjectionTests
{
    
    [Fact]
    public void ManualInjection()
    {
        var company = new Company(new Erick());
        
        Assert.Equal("print 'Hello world'", company.CreateSoftware());
    }

    [Fact]
    public void ContainerInjection()
    {
        var services = new ServiceCollection();
        services.AddTransient<Company>();
        services.AddTransient<Company2>();
        services.AddTransient<IProgrammer, Juan>();

        var provider = services.BuildServiceProvider();

        var company = provider.GetRequiredService<Company>();
        
        Assert.Equal("print 'Hello world'", company.CreateSoftware());

        provider.GetRequiredService<Company2>();
    }
}

public class Company2
{
    private readonly IProgrammer _programmer;

    public Company2(IProgrammer programmer) => _programmer = programmer;
}

public class Company
{
    private readonly IProgrammer _programmer;
    
    public Company(IProgrammer programmer) => _programmer = programmer;

    public string CreateSoftware() => _programmer.Code();
}

public interface IProgrammer
{
    string Code();
}

public class Erick : IProgrammer
{
    public string Code() => "print 'Hello world'";
}

public class Juan : IProgrammer
{
    public string Code() => "print 'Hello world'";
}