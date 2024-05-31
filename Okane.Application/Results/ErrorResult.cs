using FluentResults;
using FluentValidation.Results;

namespace Okane.Application.Results;

public static class ErrorResult
{
    public static Result<T> From<T>(ValidationResult validation) => 
        Result.Fail<T>(new ValidationErrors(validation.ToPropertyErrors()));
    
    // TODO: I don't like this
    public static Result<T> RecordNotFound<T>(string? message = null) => 
        Result.Fail<T>(new RecordNotFoundError(message ?? ""));
}