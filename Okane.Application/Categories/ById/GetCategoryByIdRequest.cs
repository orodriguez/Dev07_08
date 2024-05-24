using MediatR;

namespace Okane.Application.Categories.ById;

public record GetCategoryByIdRequest(int Id) : IGetCategoryByIdResponse, IRequest<IGetCategoryByIdResponse>;