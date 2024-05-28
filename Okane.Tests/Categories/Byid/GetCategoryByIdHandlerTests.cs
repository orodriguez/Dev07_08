using Okane.Application.Categories;
using Okane.Application.Categories.ById;
using Okane.Application.Categories.Create;
using Okane.Application.Responses;

namespace Okane.Tests.Categories.ById;

public class GetCategoryByIdHandlerTests : AbstractHandlerTests
{
    [Fact]
    public async Task CategoryExists()
    {
        var createResponse = Assert.IsType<CategoryResponse>(await Handle(new CreateCategoryRequest("Taxes")));

        var categoryResponse = Assert.IsType<CategoryResponse>(await Handle(new GetCategoryByIdRequest(createResponse.Id)));
        
        Assert.Equal(createResponse.Id, categoryResponse.Id);
        Assert.Equal("Taxes", categoryResponse.Name);
    }
    
    [Fact]
    public async Task NotFound() => 
        Assert.IsType<NotFoundResponse>(await Handle(new GetCategoryByIdRequest(-1)));
}