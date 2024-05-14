namespace Okane.Tests.Expenses.Create;

public class HandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Valid()
    {
        var response = CreateExpense(new(10, "Food"));
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.Category);
    }
    
    [Fact]
    public void WithDescription()
    {
        var response = CreateExpense(new(10, "Food", "Papa"));
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.Category);
        Assert.Equal("Papa", response.Description);
    }
}