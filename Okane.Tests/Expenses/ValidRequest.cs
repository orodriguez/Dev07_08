using Okane.Application.Expenses.Create;

namespace Okane.Tests.Expenses;

public record ValidRequest() : Request(10, "Food", "Pizza");