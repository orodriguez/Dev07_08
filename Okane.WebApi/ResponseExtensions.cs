using Okane.Application;
using Okane.Application.Responses;

namespace Okane.WebApi;

public static class ResponseExtensions
{
    public static IResult ToResult(this IResponse response) =>
        response switch {
            NotFoundResponse notFound => Results.NotFound(notFound.Message),
            ValidationErrorsResponse errors => Results.BadRequest(errors),
            ConflictResponse conflict => Results.Conflict(conflict.Message),
            _ => Results.Ok(response)
        };
}