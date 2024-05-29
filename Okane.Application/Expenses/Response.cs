using Okane.Application.Expenses.ById;
using Okane.Application.Expenses.Delete;
using Okane.Application.Expenses.Update;
using Okane.Application.Responses;

namespace Okane.Application.Expenses;

public record Response(int Id, 
    int Amount, 
    string CategoryName, 
    string? Description, DateTime CreatedAt) 
    : ISuccessResponse,
        IGetExpenseByIdResponse,
        IUpdateExpenseResponse, IDeleteExpenseResponse, IResponse;