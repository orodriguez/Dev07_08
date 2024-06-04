using Okane.Application.Categories;
using Okane.Application.Categories.Create;
using Okane.Application.Results;

namespace Okane.Tests.Categories.Create;

public class CreateCategoryHandlerTests : AbstractHandlerTests
{
    [Fact]
    public async Task NameAlreadyExists()
    {
        await App.Categories.Create("Taxes");

        var result = await App.Categories.Create("Taxes");

        var error = Assert.Single(result.Errors.OfType<ConflictError>());
        Assert.Equal("Category with Name 'Taxes' already exists.", error.Message);
    }
}