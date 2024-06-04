using FluentResults;

namespace Okane.Application.Results;

public class ValidationErrors : Error
{
    public IEnumerable<PropertyValidationError> PropertyErrors { get; set; }

    public ValidationErrors(IEnumerable<PropertyValidationError> propertyErrors) =>
        PropertyErrors = propertyErrors;

    public IEnumerator<PropertyValidationError> GetEnumerator() => PropertyErrors.GetEnumerator();
}