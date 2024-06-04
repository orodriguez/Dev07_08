using System.Collections;

namespace Okane.Application.Expenses.Retrieve;

public class RetrieveExpensesResponse : IEnumerable<Response>
{
    private readonly IEnumerable<Response> _expenses;

    public RetrieveExpensesResponse(IEnumerable<Response> expenses) => _expenses = expenses;

    public IEnumerator<Response> GetEnumerator() => _expenses.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}