using System.Diagnostics.CodeAnalysis;
using Okane.WebApi.DTOs;

namespace Okane.WebApi;

public class CreateExpenseRequestHandler
{
    public Expense Handle(CreateExpenseRequest request)
    {
        return new Expense(request.Amount, request.Category);
    }
}