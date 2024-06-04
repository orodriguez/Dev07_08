using FluentResults;
using Okane.Application.Responses;
using Okane.Application.Results;

namespace Okane.WebApi;

public static class ResponseExtensions
{
    public static IResult ToActionResult<T>(this Result<T> result)
    {
        if (result.IsSuccess)
            return Results.Ok(result.Value);

        var reason = result.Errors[0];
        return reason switch
        {
            RecordNotFoundError notFound => Results.NotFound(notFound.Message),
            ConflictError conflict => Results.Conflict(conflict.Message),
            ValidationErrors errors => Results.BadRequest(errors.PropertyErrors),
            _ => Results.Ok(reason.Message)
        };
    }
}