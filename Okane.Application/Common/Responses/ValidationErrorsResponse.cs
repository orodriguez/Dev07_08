using System.Collections;
using FluentValidation.Results;

namespace Okane.Application.Common.Responses;

public record ValidationErrorsResponse(IEnumerable<ValidationErrorsResponse.Error> Errors) 
    : IResponse, IEnumerable<ValidationErrorsResponse.Error>
{
    public static IResponse From(ValidationResult validation)
    {
        var errors = validation
            .Errors
            .Select(failure => new Error(failure.PropertyName, failure.ErrorMessage));
        return new ValidationErrorsResponse(errors);
    }

    public IEnumerator<Error> GetEnumerator() => 
        Errors.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => 
        GetEnumerator();
    
    public record Error(string Property, string Message);
}