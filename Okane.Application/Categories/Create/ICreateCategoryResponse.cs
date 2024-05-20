using Okane.Application.Responses;

namespace Okane.Application.Categories.Create;

public interface ICreateCategoryResponse : IResponse
{
    int Id { get; }
}