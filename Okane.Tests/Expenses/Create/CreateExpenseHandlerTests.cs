using System.Globalization;
using Okane.Application.Categories.Create;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;
using Okane.Application.Responses;
using Okane.Application.Results;
using Request = Okane.Application.Expenses.Create.Request;

namespace Okane.Tests.Expenses.Create;

public class CreateExpenseHandlerTests : AbstractHandlerTests, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        await Handle(new Application.Categories.Create.Request("Food"));
        await Handle(new Application.Categories.Create.Request("Entertainment"));
        await Handle(new Application.Categories.Create.Request("Games"));
    }

    [Fact]
    public async Task Valid()
    {
        Now = DateTime.Parse("2024-02-14", new CultureInfo("es-US"));

        var response = await App.Expenses.Create(new(10, "Food"));
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.CategoryName);
        Assert.Equal(DateTime.Parse("2024-02-14", new CultureInfo("en-US")), response.CreatedAt);
    }

    [Fact]
    public async Task AmountZeroOrLess()
    {
        var result = await App.Expenses.TryCreate(-1, "Food", "Pizza");

        var errors = Assert.Single(result.Errors.OfType<ValidationErrors>());
        var propertyError = Assert.Single(errors.PropertyErrors);
        Assert.Contains("Amount", propertyError.PropertyName);
        Assert.Equal("Amount must be a positive value", propertyError.Message);
    }

    [Fact]
    public async Task WithDescription()
    {
        var response = await App.Expenses.Create(
            new(10, "Food", Description: "Pizza"));
        
        Assert.Equal("Pizza", response.Description);
    }

    [Fact]
    public async Task WithoutDescription()
    {
        var response = await App.Expenses.Create(
            new(10, "Food"));
        
        Assert.Null(response.Description);
    }

    [Fact]
    public async Task DescriptionTooBig()
    {
        var result = await App.Expenses.TryCreate(
            10, "Food", string.Join("", Enumerable.Repeat('x', 141)));
        
        var errors = Assert.Single(result.Errors.OfType<ValidationErrors>());
        var propertyError = Assert.Single(errors.PropertyErrors);
        Assert.Equal(nameof(Request.Description), propertyError.PropertyName);
        Assert.Equal($"{nameof(Request.Description)} is too big", propertyError.Message);
    }

    [Fact]
    public async Task CategoryTooBig()
    {
        var result = await App.Expenses.TryCreate(
            10, string.Join("", Enumerable.Repeat('x', 51)), "Pizza");
        
        var errors = Assert.Single(result.Errors.OfType<ValidationErrors>());
        var propertyError = Assert.Single(errors.PropertyErrors);
        Assert.Equal(nameof(Request.CategoryName), propertyError.PropertyName);
        Assert.Equal($"{nameof(Request.CategoryName)} is too big", propertyError.Message);
    }

    [Fact]
    public async Task CategoryDoesNotExist()
    {
        var result = await App.Expenses.TryCreate(
            10, "Unknown", "Pizza");
        
        var error = Assert.Single(result.Errors.OfType<RecordNotFoundError>());
        Assert.Equal("Category with Name 'Unknown' was not found.", error.Message);
    }

    public Task DisposeAsync() => 
        Task.CompletedTask;
}