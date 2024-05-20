using Okane.Application.Categories.ById;

namespace Okane.Application.Responses;

public record NotFoundResponse : IResponse, IGetCategoryByIdResponse;