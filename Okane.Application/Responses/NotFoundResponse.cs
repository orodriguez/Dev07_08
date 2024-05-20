using Okane.Application.Categories.ById;
using Okane.Application.Categories.Delete;

namespace Okane.Application.Responses;

public record NotFoundResponse : IResponse, IGetCategoryByIdResponse, IDeleteCategoryResponse;