using System.Collections;
using FluentValidation.Results;
using Okane.Application.Category;
using Okane.Application.Expenses;

namespace Okane.Application;

public record ValidationErrorsExpenseResponse(IEnumerable<ValidationErrorsExpenseResponse.PropertyError> Errors) 
    : IEnumerable<ValidationErrorsExpenseResponse.PropertyError>,IExpenseResponse
{
    public IEnumerator<PropertyError> GetEnumerator() => Errors.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
      public static ValidationErrorsExpenseResponse From(ValidationResult validation)
    {
        var errors = validation
            .Errors
            .Select(failure => new PropertyError(failure.PropertyName, failure.ErrorMessage));
        
        return new ValidationErrorsExpenseResponse(errors);
    }
    
    public record PropertyError(string Property, string Message);
}


// Check
public record ValidationErrorsCategoryResponse(IEnumerable<ValidationErrorsCategoryResponse.PropertyError> Errors) 
    : IEnumerable<ValidationErrorsCategoryResponse.PropertyError>,ICategoryResponse
{
    public IEnumerator<PropertyError> GetEnumerator() => Errors.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    public static ValidationErrorsCategoryResponse From(ValidationResult validation)
    {
        var errors = validation
            .Errors
            .Select(failure => new PropertyError(failure.PropertyName, failure.ErrorMessage));
        
        return new ValidationErrorsCategoryResponse(errors);
    }
    
    public record PropertyError(string Property, string Message);
}