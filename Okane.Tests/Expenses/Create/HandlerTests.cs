using Okane.Application;
using Okane.Application.Expenses;
using Okane.Application.Expenses.Create;

namespace Okane.Tests.Expenses.Create;

public class HandlerTests
{
    [Fact]
    public void Valid()
    {
        var request = new Request(10, "Food");

        var handler = new Handler(new InMemoryRepository());

        var response = handler.Handle(request);
        
        Assert.Equal(1, response.Id);
        Assert.Equal(10, response.Amount);
        Assert.Equal("Food", response.Category);
    }
}