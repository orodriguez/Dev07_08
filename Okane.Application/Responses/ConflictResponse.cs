using Okane.Application.Budget.Create;
using Okane.Application.Categories.Create;

namespace Okane.Application.Responses;

public record ConflictResponse(string Message) : ICreateCategoryResponse, ICreateBudgetResponse;