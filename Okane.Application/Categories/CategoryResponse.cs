using Okane.Application.Responses;

namespace Okane.Application.Categories;

public record CategoryResponse(int Id, string Name) : ISuccessResponse;