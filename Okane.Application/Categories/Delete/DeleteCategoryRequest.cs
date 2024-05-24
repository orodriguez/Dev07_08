using MediatR;

namespace Okane.Application.Categories.Delete;

public record DeleteCategoryRequest(int Id) : IRequest<IDeleteCategoryResponse>;