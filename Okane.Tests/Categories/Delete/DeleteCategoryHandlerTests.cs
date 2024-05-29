using Okane.Application.Categories.Delete;
using Okane.Application.Responses;
using Okane.Application.Results;

namespace Okane.Tests.Categories.Delete;

public class DeleteCategoryHandlerTests : AbstractHandlerTests
{
    [Fact]
    public async Task Exists()
    {
        var createdCategory = (await App.Categories.Create("Subscriptions")).Value;

        var deletedCategory = (await App.Categories.Delete(createdCategory.Id)).Value;
        
        Assert.Equal(createdCategory.Id, deletedCategory.Id);
        Assert.Equal("Subscriptions", deletedCategory.Name);
    }
    
    [Fact]
    public async Task NotFound()
    {
        var result = await App.Categories.Delete(-1);
        Assert.Single(result.Errors.OfType<RecordNotFoundError>());
    }
}