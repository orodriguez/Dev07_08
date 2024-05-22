using Okane.Application.Categories.ById;
using Okane.Application.Categories.Delete;
using Okane.Application.Categories.RetrieveByCategory;
using Okane.Application.Expenses.Create;

namespace Okane.Application.Responses;

public record NotFoundResponse(string? Message = null) : IResponse, 
    IGetCategoryByIdResponse, 
    IDeleteCategoryResponse, 
    ICreateExpenseResponse, IRetrieveExpensesByCategoryResponse;