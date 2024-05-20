namespace Okane.Application.Category.Create
{
    // Check
    public record CreateCategoryRequest(string Category)
    {
        public Domain.Category ToCategory() =>
            new()
            {
                Name = Category
            };
    }
}