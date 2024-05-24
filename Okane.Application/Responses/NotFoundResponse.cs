using Okane.Application.Categories.ById;
using Okane.Application.Categories.Delete;
using Okane.Application.Expenses;
using Okane.Application.Expenses.ById;
using Okane.Application.Expenses.Create;
using Okane.Application.Expenses.Delete;
using Okane.Application.Expenses.Update;

namespace Okane.Application.Responses;

public record NotFoundResponse(string? Message = null) : 
    IGetCategoryByIdResponse,
    IDeleteCategoryResponse,
    ICreateExpenseResponse,
    IGetExpenseByIdResponse,
    IExpenseFactoryResponse,
    IUpdateExpenseResponse, 
    IDeleteExpenseResponse;