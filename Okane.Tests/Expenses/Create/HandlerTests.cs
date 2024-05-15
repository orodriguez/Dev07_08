namespace Okane.Tests.Expenses.Create;

public class HandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Valid()
    {
        var response = CreateExpense(new(10, "Food","Comida China"));
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.Category);
    }
    
    // Enviando la description fill
    [Fact]
    public void WithDescription()
    {
        var response = CreateExpense(new(10, "Food","Comida Mexicana"));
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.Category);
        Assert.Equal("Comida Mexicana", response.Description);
    }
    
    // Enviando la description Empty
        
    [Fact]
    public void WithEmptyDescription()
    {
        var response = CreateExpense(new(10, "Food",""));
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.Category);
        Assert.Equal("",response.Description);
    }
    
    // Enviando la description Null !
    [Fact]
    public void WithNullDescription()
    {
        var response = CreateExpense(new(10, "Food",null));
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.Category);
        Assert.Null(response.Description);
    }
}