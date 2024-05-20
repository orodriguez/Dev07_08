using Okane.Application.Categories;
using Okane.Application.Categories.Create;
using Okane.Application.Responses;

namespace Okane.Tests.Categories.Delete;

public class DeleteCategoryHandlerTests : AbstractHandlerTests
{
    [Fact]
    public void Exists()
    {
        var createResponse = Assert.IsType<CategoryResponse>(CreateCategory(new CreateCategoryRequest("Subscriptions")));

        var deleteResponse = Assert.IsType<CategoryResponse>(DeleteCategory(createResponse.Id));
        
        Assert.Equal(createResponse.Id, deleteResponse.Id);
        Assert.Equal("Subscriptions", deleteResponse.Name);
    }
    
    [Fact]
    public void NotFound() => 
        Assert.IsType<NotFoundResponse>(DeleteCategory(-234));
}