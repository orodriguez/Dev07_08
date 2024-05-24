using Okane.Application.Categories.ById;
using Okane.Application.Categories.Delete;
using Okane.Application.Expenses.Create;

namespace Okane.Application.Responses;

public record NotFoundResponse(string? Message = null) : 
    IGetCategoryByIdResponse,
    IDeleteCategoryResponse,
    ICreateExpenseResponse;