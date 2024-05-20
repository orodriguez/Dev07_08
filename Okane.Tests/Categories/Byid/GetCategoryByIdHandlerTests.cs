using Okane.Application.Categories;
using Okane.Application.Responses;

namespace Okane.Tests.Categories.ById;

public class GetCategoryByIdHandlerTests : AbstractHandlerTests
{
    [Fact]
    public void CategoryExists()
    {
        var createResponse = Assert.IsType<CategoryResponse>(CreateCategory(new("Taxes")));

        var categoryResponse = Assert.IsType<CategoryResponse>(GetCategoryById(createResponse.Id));
        
        Assert.Equal(createResponse.Id, categoryResponse.Id);
        Assert.Equal("Taxes", categoryResponse.Name);
    }
    
    [Fact]
    public void NotFound() => 
        Assert.IsType<NotFoundResponse>(GetCategoryById(-1));
}