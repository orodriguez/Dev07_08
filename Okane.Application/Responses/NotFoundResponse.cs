using Okane.Application.Categories.ById;
using Okane.Application.Categories.Delete;

namespace Okane.Application.Responses;

public record NotFoundResponse(string? Message = null) : IResponse, IGetCategoryByIdResponse, IDeleteCategoryResponse;