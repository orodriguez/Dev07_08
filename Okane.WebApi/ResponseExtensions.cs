using Okane.Application;
using Okane.Application.Responses;

namespace Okane.WebApi;

public static class ResponseExtensions
{
    public static IResult ToResult(this IResponse response) =>
        response switch {
            NotFoundResponse => Results.NotFound(),
            ValidationErrorsResponse errors => Results.BadRequest(errors),
            ConflictResponse conflict => Results.Conflict(conflict.Message),
            _ => Results.Ok(response)
        };
}