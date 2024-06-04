using Okane.Application.Expenses.ById;
using Okane.Application.Expenses.Delete;
using Okane.Application.Expenses.Update;

namespace Okane.Application.Expenses;

public record Response(int Id, 
    int Amount, 
    string CategoryName, 
    string? Description, DateTime CreatedAt) 
    : IGetExpenseByIdResponse,
        IUpdateExpenseResponse, IDeleteExpenseResponse;