using Okane.Application.Categories;
using Okane.Application.Categories.Create;
using Okane.Application.Responses;

namespace Okane.Tests.Categories.Create;

public class CreateCategoryHandlerTests : AbstractHandlerTests
{
    [Fact]
    public async Task NameAlreadyExists()
    {
        Assert.IsType<CategoryResponse>(await HandleAsync(new CreateCategoryRequest("Taxes")));
        var response = Assert.IsType<ConflictResponse>(await HandleAsync(new CreateCategoryRequest("Taxes")));
        Assert.Equal("Category with Name 'Taxes' already exists.", response.Message);
    }
}