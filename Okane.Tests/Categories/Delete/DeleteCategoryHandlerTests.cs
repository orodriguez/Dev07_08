using Okane.Application.Categories;
using Okane.Application.Categories.Create;
using Okane.Application.Categories.Delete;
using Okane.Application.Responses;

namespace Okane.Tests.Categories.Delete;

public class DeleteCategoryHandlerTests : AbstractHandlerTests
{
    [Fact]
    public async Task Exists()
    {
        var createResponse = Assert.IsType<CategoryResponse>(
            await HandleAsync(new CreateCategoryRequest("Subscriptions")));

        var deleteResponse = Assert.IsType<CategoryResponse>(await HandleAsync(new DeleteCategoryRequest(createResponse.Id)));
        
        Assert.Equal(createResponse.Id, deleteResponse.Id);
        Assert.Equal("Subscriptions", deleteResponse.Name);
    }
    
    [Fact]
    public async Task NotFound() => 
        Assert.IsType<NotFoundResponse>(await HandleAsync(new DeleteCategoryRequest(-234)));
}