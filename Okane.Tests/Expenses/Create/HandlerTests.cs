using Okane.Application.Common.Responses;
using Okane.Application.Expenses;

namespace Okane.Tests.Expenses.Create;

public class HandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Valid()
    {
        var response = (Application.Expenses.Response) CreateExpense(new(10, "Food"));

        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.Category);
    }
    
    [Fact]
    public void NegativeAmount()
    {
        var response = CreateExpense(new(-10, "Food"));

        var errors = Assert.IsType<ValidationErrorsResponse>(response);

        var (property, message) = Assert.Single(errors);
        
        Assert.Equal("Amount", property);
        Assert.Contains("'Amount' must be greater than '0'", message);
    }
    
    [Fact]
    public void WithDescription()
    {
        var response = CreateExpense(new(10, "Food"));
        var expense = Assert.IsType<Response>(response);
        Assert.Equal(1, expense.Id);
        Assert.Equal(10, expense.Amount);
        Assert.Equal("Food", expense.Category);
    }
}