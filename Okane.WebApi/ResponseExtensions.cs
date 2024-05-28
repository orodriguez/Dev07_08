using FluentResults;
using Okane.Application.Responses;
using Okane.Application.Results;

namespace Okane.WebApi;

public static class ResponseExtensions
{
    public static IResult ResponseToResult(this IResponse response) =>
        response switch {
            NotFoundResponse notFound => Results.NotFound(notFound.Message),
            ValidationErrorsResponse errors => Results.BadRequest(errors),
            ConflictResponse conflict => Results.Conflict(conflict.Message),
            _ => Results.Ok(response)
        };
    
    public static IResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            return Results.Ok(result.Value);

        var reason = result.Errors[0];
        return reason switch
        {
            RecordNotFoundError notFound => Results.NotFound(notFound.Message),
            _ => Results.Ok(reason.Message)
        };
    }
}