using System.Collections;
using Okane.Application.Responses;

namespace Okane.Application.Expenses.Retrieve;

public class RetrieveExpensesResponse : IEnumerable<ExpenseResponse>, IResponse
{
    private readonly IEnumerable<ExpenseResponse> _expenses;

    public RetrieveExpensesResponse(IEnumerable<ExpenseResponse> expenses) => _expenses = expenses;

    public IEnumerator<ExpenseResponse> GetEnumerator() => _expenses.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}