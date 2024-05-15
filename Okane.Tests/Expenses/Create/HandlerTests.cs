using Okane.Application;
using Okane.Application.Expenses;

namespace Okane.Tests.Expenses.Create;

public class HandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Valid()
    {
        var response = Assert.IsType<SuccessResponse>(CreateExpense(new(10, "Food")));
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.Category);
    }
    
    [Fact]
    public void AmountZeroOrLess()
    {
        var errors = Assert.IsType<ValidationErrorsResponse>(CreateExpense(new(-1, "Food")));

        var error = Assert.Single(errors);
        
        Assert.Equal("Amount", error.Property);
        Assert.Equal("Amount must be a positive value", error.Message);
    }
    
    [Fact]
    public void WithDescription()
    {
        var response = Assert.IsType<SuccessResponse>(
            CreateExpense(new(10, "Food", Description: "Pizza")));
        
        Assert.Equal("Pizza", response.Description);
    }
    
    [Fact]
    public void WithoutDescription()
    {
        var response = Assert.IsType<SuccessResponse>(
            CreateExpense(new(10, "Food")));
        
        Assert.Null(response.Description);
    }
}