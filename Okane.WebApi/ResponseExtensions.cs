using Okane.Application;
using Okane.Application.Responses;

namespace Okane.WebApi;

public static class ResponseExtensions
{
    public static IResult ToResult(this IResponse response) =>
        response switch {
            ISuccessResponse success => Results.Ok(success),
            NotFoundResponse => Results.NotFound(),
            ValidationErrorsResponse errors => Results.BadRequest(errors),
            _ => throw new ArgumentOutOfRangeException(nameof(response))
        };
}