using System.Collections;
using FluentValidation.Results;
using Okane.Application.Category;

namespace Okane.Application
{
    public record ValidationErrorsCategoryResponse(IEnumerable<ValidationErrorsCategoryResponse.PropertyError> Errors) 
        : IEnumerable<ValidationErrorsCategoryResponse.PropertyError>, ICategoryResponse
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
}