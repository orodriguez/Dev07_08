namespace Okane.Tests;

public class DependencyInjectionTests
{
    
    [Fact]
    public void ManualInjection()
    {
        var foo = new Foo(new NewBar());
        
        Assert.True(foo.CallBar());
    }
}

public class NewBar : IBar
{
    public bool DoIt()
    {
        return true;
    }
}

public class Foo
{
    private readonly IBar _bar;

    public Foo(IBar bar) => _bar = bar;

    public bool CallBar() => _bar.DoIt();
}

public interface IBar
{
    bool DoIt();
}

public class Bar : IBar
{
    public bool DoIt()
    {
        return true;
    }
}