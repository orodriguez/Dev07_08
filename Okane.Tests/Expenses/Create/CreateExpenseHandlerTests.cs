using System.Globalization;
using Okane.Application.Categories.Create;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;
using Okane.Application.Responses;

namespace Okane.Tests.Expenses.Create;

public class CreateExpenseHandlerTests : AbstractHandlerTests, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        await Handle(new CreateCategoryRequest("Food"));
        await Handle(new CreateCategoryRequest("Entertainment"));
        await Handle(new CreateCategoryRequest("Games"));
    }

    [Fact]
    public async Task Valid()
    {
        Now = DateTime.Parse("2024-02-14", new CultureInfo("es-US"));
        
        var response = Assert.IsType<ExpenseResponse>(await Handle(new CreateExpenseRequest(10, "Food")));
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.CategoryName);
        Assert.Equal(DateTime.Parse("2024-02-14", new CultureInfo("en-US")), response.CreatedAt);
    }

    [Fact]
    public async Task AmountZeroOrLess()
    {
        var errors = Assert.IsType<ValidationErrorsResponse>(
            await Handle(new CreateExpenseRequest(-1, "Food", "Pizza")));

        var error = Assert.Single(errors);
        
        Assert.Equal("Amount", error.Property);
        Assert.Equal("Amount must be a positive value", error.Message);
    }

    [Fact]
    public async Task WithDescription()
    {
        var response = Assert.IsType<ExpenseResponse>(
            await Handle(new CreateExpenseRequest(10, "Food", Description: "Pizza")));
        
        Assert.Equal("Pizza", response.Description);
    }

    [Fact]
    public async Task WithoutDescription()
    {
        var response = Assert.IsType<ExpenseResponse>(
            await Handle(new CreateExpenseRequest(10, "Food")));
        
        Assert.Null(response.Description);
    }

    [Fact]
    public async Task DescriptionTooBig()
    {
        var errors = Assert.IsType<ValidationErrorsResponse>(
            await Handle(
                new CreateExpenseRequest(10, "Food", string.Join("", Enumerable.Repeat('x', 141)))));

        var error = Assert.Single(errors);
        
        Assert.Equal(nameof(CreateExpenseRequest.Description), error.Property);
        Assert.Equal($"{nameof(CreateExpenseRequest.Description)} is too big", error.Message);
    }

    [Fact]
    public async Task CategoryTooBig()
    {
        var errors = Assert.IsType<ValidationErrorsResponse>(
            await Handle(
                new CreateExpenseRequest(10, string.Join("", Enumerable.Repeat('x', 51)), "Pizza")));

        var error = Assert.Single(errors);
        
        Assert.Equal(nameof(CreateExpenseRequest.CategoryName), error.Property);
        Assert.Equal($"{nameof(CreateExpenseRequest.CategoryName)} is too big", error.Message);
    }

    [Fact]
    public async Task CategoryDoesNotExist()
    {
        var notFoundResponse = Assert.IsType<NotFoundResponse>(
            await Handle(new CreateExpenseRequest(10, "Unknown", "Pizza")));
        
        Assert.Equal("Category with Name 'Unknown' was not found.", notFoundResponse.Message);
    }

    public Task DisposeAsync() => 
        Task.CompletedTask;
}