using FluentValidation.Results;
using Okane.Application.Results;

namespace Okane.Application;

public static class ValidationResultExtensions
{
    public static IEnumerable<PropertyValidationError> ToPropertyErrors(this ValidationResult validation) =>
        validation.Errors.Select(failure =>
            new PropertyValidationError(failure.PropertyName, failure.ErrorMessage));
}