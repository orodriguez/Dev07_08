using System.Collections;
using FluentValidation.Results;

namespace Okane.Application.Responses;

public record ValidationErrorsResponse(IEnumerable<ValidationErrorsResponse.PropertyError> Errors) 
    : IEnumerable<ValidationErrorsResponse.PropertyError>, IResponse
{
    public IEnumerator<PropertyError> GetEnumerator() => Errors.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public static IResponse From(ValidationResult validation)
    {
        var errors = validation
            .Errors
            .Select(failure => new PropertyError(failure.PropertyName, failure.ErrorMessage));
        
        return new ValidationErrorsResponse(errors);
    }

    public record PropertyError(string Property, string Message);
}