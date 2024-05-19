using Okane.Application;
using Okane.Application.Category;
using Okane.Application.Expenses;

namespace Okane.WebApi;

public static class ResponseExtensions
{
    public static IResult ToResult(this IExpenseResponse response) =>
        response switch {
            SuccessResponse success => Results.Ok(success),
            NotFoundResponse => Results.NotFound(),
            ValidationErrorsResponse errors => Results.BadRequest(errors),
            CategorySuccessResponse category => Results.Ok(category),
            _ => throw new ArgumentOutOfRangeException(nameof(response))
        };
}