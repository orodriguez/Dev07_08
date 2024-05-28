using Okane.Application.Auth;
using Okane.Application.Auth.Signup;
using Okane.Application.Categories.Create;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Retrieve;

namespace Okane.Tests.Expenses.Retrieve;

public class RetrieveExpensesHandlerTests : AbstractHandlerTests, IAsyncLifetime
{
    public async Task InitializeAsync()
    {
        CurrentUserId = Assert.IsType<UserResponse>(
            await Handle(new Request("user1@mail.com", "1234"))).Id;
        
        await Handle(new CreateCategoryRequest("Food"));
        await Handle(new CreateCategoryRequest("Games"));
    }

    [Fact]
    public async Task NoExpenses()
    {
        var response = Assert.IsType<RetrieveExpensesResponse>(await Handle(new RetrieveExpensesRequest()));
        Assert.Empty(response);
    }

    [Fact]
    public async Task OneExpenses()
    {
        await Handle(new CreateExpenseRequest(10, "Food"));

        var expenses = Assert.IsType<RetrieveExpensesResponse>(await Handle(new RetrieveExpensesRequest()));
        var expense = Assert.Single(expenses);
        Assert.Equal(1, expense.Id);
        Assert.Equal(10, expense.Amount);
        Assert.Equal("Food", expense.CategoryName);
    }

    [Fact]
    public async Task ManyExpenses()
    {
        await Handle(new CreateExpenseRequest(10, "Food"));
        await Handle(new CreateExpenseRequest(20, "Games"));
        
        var response = Assert.IsType<RetrieveExpensesResponse>(await Handle(new RetrieveExpensesRequest()));
        
        Assert.Equal(2, response.Count());
    }

    [Fact]
    public async Task ExpensesFromAnotherUser()
    {
        await Handle(new CreateExpenseRequest(10, "Food"));
        
        
        CurrentUserId = Assert.IsType<UserResponse>(
            await Handle(new Request("user2@mail.com", "1234"))).Id;

        await Handle(new CreateExpenseRequest(20, "Games"));
        
        var response = Assert.IsType<RetrieveExpensesResponse>(await Handle(new RetrieveExpensesRequest()));
        
        var expense = Assert.Single(response);
        Assert.Equal("Games", expense.CategoryName);
    }

    public Task DisposeAsync() => Task.CompletedTask;
}