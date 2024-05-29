using Okane.Application.Expenses;
using Okane.Application.Expenses.ById;
using Okane.Application.Expenses.Delete;
using Okane.Application.Expenses.Update;

namespace Okane.Application.Responses;

public record NotFoundResponse(string? Message = null) : IGetExpenseByIdResponse,
    IExpenseFactoryResponse,
    IUpdateExpenseResponse, 
    IDeleteExpenseResponse, IResponse;