namespace Okane.Tests.Expenses.Create;

public class HandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Valid()
    {
        var response = CreateExpense(new(10, "Food", null));
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.Category);
        Assert.Null(response.Description);
    }
    
    [Fact]
    public void WithNoDescription()
    {
        var response = CreateExpense(new(10, "Food", null));
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.Category);
        Assert.Null(response.Description);
    }
    
    
    [Fact]
    public void WithDescription()
    {
        var response = CreateExpense(new(10, "Food", "Beef"));
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.Category);
        Assert.Equal("Beef",response.Description);
    }
}