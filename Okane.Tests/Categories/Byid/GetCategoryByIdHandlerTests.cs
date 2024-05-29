using Okane.Application.Categories;
using Okane.Application.Categories.ById;
using Okane.Application.Categories.Create;
using Okane.Application.Responses;
using Okane.Application.Results;

namespace Okane.Tests.Categories.ById;

public class GetCategoryByIdHandlerTests : AbstractHandlerTests
{
    [Fact]
    public async Task CategoryExists()
    {
        var result = await App.Categories.Create("Taxes");
        var createResponse = result.Value;
        
        var categoryResponse = (await App.Categories.ById(createResponse.Id)).Value;
        
        Assert.Equal(createResponse.Id, categoryResponse.Id);
        Assert.Equal("Taxes", categoryResponse.Name);
    }
    
    [Fact]
    public async Task NotFound()
    {
        var response = await App.Categories.ById(-1);
        Assert.Single(response.Reasons.OfType<RecordNotFoundError>());
    }
}