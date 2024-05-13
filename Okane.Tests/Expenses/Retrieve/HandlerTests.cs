using Okane.Application.Expenses;

namespace Okane.Tests.Expenses.Retrieve;


public class HandlerTests
{
    [Fact]
    public void NoExpenses()
    {
        var retrieveHandler = new Application.Expenses.Retrieve.Handler(new InMemoryRepository());
        var response = retrieveHandler.Handle();
        Assert.Empty(response);
    }
    
    [Fact]
    public void OneExpenses()
    {
        var expenses = new InMemoryRepository();
        
        var create = new Application.Expenses.Create.Handler(expenses);
        create.Handle(new(10, "Food"));
        
        var retrieve = new Application.Expenses.Retrieve.Handler(expenses);
        var response = retrieve.Handle();
        
        var expense = Assert.Single(response);
        Assert.Equal(1, expense.Id);
        Assert.Equal(10, expense.Amount);
        Assert.Equal("Food", expense.Category);
    }
    
    [Fact]
    public void ManyExpenses()
    {
        var expenses = new InMemoryRepository();
        
        var create = new Application.Expenses.Create.Handler(expenses);
        create.Handle(new(10, "Food"));
        create.Handle(new(20, "Games"));
        
        var retrieve = new Application.Expenses.Retrieve.Handler(expenses);
        var response = retrieve.Handle();

        Assert.Equal(2, response.Count());
    }
}