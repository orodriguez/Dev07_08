using Okane.Application;
using Okane.Application.Category;
using Okane.Application.Expenses;
namespace Okane.WebApi;

public static class ResponseExtensions
{
    public static IResult ToResult(this IExpenseResponse response) =>
        response switch {
            SuccessResponse success => Results.Ok(success),
            NotFoundResponseExpenses => Results.NotFound(),
            ValidationErrorsExpenseResponse errors => Results.BadRequest(errors),
            _ => throw new ArgumentOutOfRangeException(nameof(response))
        };
    
    // ICategoryResponse
    public static IResult ToResult(this ICategoryResponse response) =>
        response switch {
            CategorySuccessResponse success => Results.Ok(success),
            NotFoundResponseCategory => Results.NotFound(),
            ValidationErrorsCategoryResponse errors => Results.BadRequest(errors),
            _ => throw new ArgumentOutOfRangeException(nameof(response))
        };
}