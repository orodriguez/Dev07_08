namespace Okane.Application.Category.Create;

public record class CreateCategoryRequest(string Name)
{
    public Domain.Category ToCategory()
    {
        return new Domain.Category
        {
            Name = Name
        };
    }
}