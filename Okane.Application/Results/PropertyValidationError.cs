using FluentResults;

namespace Okane.Application.Results;

public class PropertyValidationError : Error
{
    public string PropertyName { get; set; }

    public PropertyValidationError(string propertyName, string message)
    {
        PropertyName = propertyName;
        Message = message;
    }
}