using System.Collections;
using FluentValidation.Results;
using Okane.Application.Category;
using Okane.Application.Expenses;

namespace Okane.Application;

public record ValidationErrorsResponse(IEnumerable<ValidationErrorsResponse.PropertyError> Errors) 
    : IEnumerable<ValidationErrorsResponse.PropertyError>, IResponseComunications
{
    public IEnumerator<PropertyError> GetEnumerator() => Errors.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
      public static ValidationErrorsResponse From(ValidationResult validation)
    {
        var errors = validation
            .Errors
            .Select(failure => new PropertyError(failure.PropertyName, failure.ErrorMessage));
        
        return new ValidationErrorsResponse(errors);
    }

    public record PropertyError(string Property, string Message);
}