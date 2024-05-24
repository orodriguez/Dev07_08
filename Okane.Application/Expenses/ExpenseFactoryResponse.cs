using Okane.Domain;

namespace Okane.Application.Expenses;

public record ExpenseFactoryResponse(Expense Value) : IExpenseFactoryResponse;