using Okane.Application;
using Okane.Application.Expenses;

namespace Okane.WebApi;

public static class ResponseExtensions
{
    public static IResult ToResult(this IExpenseResponse response) =>
        response switch {
            SuccessResponse success => Results.Ok(success),
            NotFoundResponse => Results.NotFound(),
            ValidationErrorsResponse errors => Results.BadRequest(errors),
            _ => throw new ArgumentOutOfRangeException(nameof(response))
        };
}