using Okane.Application.Common.Responses;

namespace Okane.WebApi;

public static class ResponseExtensions
{
    public static IResult ToResult(this IResponse response) =>
        response switch
        {
            ISuccessResponse => Results.Ok(response),
            ValidationErrorsResponse validationErrors => Results.BadRequest(validationErrors),
            _ => throw new ArgumentOutOfRangeException(nameof(response))
        };
}