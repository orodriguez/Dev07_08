using Okane.Application.Categories;
using Okane.Application.Categories.Create;
using Okane.Application.Responses;

namespace Okane.Tests.Categories.Create;

public class CreateCategoryHandlerTests : AbstractHandlerTests
{
    [Fact]
    public void NameAlreadyExists()
    {
        Assert.IsType<CategoryResponse>(CreateCategory(new("Taxes")));
        var response = Assert.IsType<ConflictResponse>(CreateCategory(new("Taxes")));
        Assert.Equal("Category with Name 'Taxes' already exists.", response.Message);
    }
    [Fact]
    public void NameOver100Characters()
    {
        var hundredCharacterCategory = "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas porttitor congue massa. Fusce posuere, magna sed pulvinar.";
        var response = Assert.IsType<ConflictResponse>(CreateCategory(new(hundredCharacterCategory)));
        Assert.Equal("Category name cannot be longer than 100 characters.", response.Message);
    }
}