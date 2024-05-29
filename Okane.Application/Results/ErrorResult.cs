using FluentResults;
using FluentValidation.Results;

namespace Okane.Application.Results;

public static class ErrorResult
{
    public static Result<T> From<T>(ValidationResult validation)
    {
        var errors = validation
            .Errors
            .Select(failure => new PropertyValidationError(failure.PropertyName, failure.ErrorMessage));
        
        return Result.Fail<T>(errors);
    }
    
    // TODO: I don't like this
    public static Result<T> RecordNotFound<T>(string? message = null) => 
        Result.Fail<T>(new RecordNotFoundError(message ?? ""));
}