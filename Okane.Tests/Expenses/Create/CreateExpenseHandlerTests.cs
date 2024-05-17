using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;
using Okane.Application.Responses;

namespace Okane.Tests.Expenses.Create;

public class CreateExpenseHandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Valid()
    {
        Now = DateTime.Parse("2024-02-14");
        
        var response = Assert.IsType<ExpenseResponse>(CreateExpense(new(10, "Food")));
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.CategoryName);
        Assert.Equal(DateTime.Parse("2024-02-14"), response.CreatedAt);
    }
    
    [Fact]
    public void AmountZeroOrLess()
    {
        var request = new ValidCreateExpenseRequest { Amount = -1 };
        var errors = Assert.IsType<ValidationErrorsResponse>(CreateExpense(request));

        var error = Assert.Single(errors);
        
        Assert.Equal("Amount", error.Property);
        Assert.Equal("Amount must be a positive value", error.Message);
    }

    [Fact]
    public void WithDescription()
    {
        var response = Assert.IsType<ExpenseResponse>(
            CreateExpense(new(10, "Food", Description: "Pizza")));
        
        Assert.Equal("Pizza", response.Description);
    }

    [Fact]
    public void WithoutDescription()
    {
        var response = Assert.IsType<ExpenseResponse>(
            CreateExpense(new(10, "Food")));
        
        Assert.Null(response.Description);
    }

    [Fact]
    public void DescriptionTooBig()
    {
        var request = new ValidCreateExpenseRequest
        {
            Description = string.Join("", Enumerable.Repeat('x', 141))
        };
        var errors = Assert.IsType<ValidationErrorsResponse>(CreateExpense(request));

        var error = Assert.Single(errors);
        
        Assert.Equal(nameof(CreateExpenseRequest.Description), error.Property);
        Assert.Equal($"{nameof(CreateExpenseRequest.Description)} is too big", error.Message);
    }
    
    [Fact]
    public void CategoryTooBig()
    {
        var request = new ValidCreateExpenseRequest
        {
            CategoryName = string.Join("", Enumerable.Repeat('x', 51))
        };
        var errors = Assert.IsType<ValidationErrorsResponse>(CreateExpense(request));

        var error = Assert.Single(errors);
        
        Assert.Equal(nameof(CreateExpenseRequest.CategoryName), error.Property);
        Assert.Equal($"{nameof(CreateExpenseRequest.CategoryName)} is too big", error.Message);
    }
}