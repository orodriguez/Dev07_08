using FluentResults;
using Okane.Application.Categories.Create;

namespace Okane.Application.Responses;

public class ConflictError : Error
{
    public ConflictError(string message) : base(message)
    {
    }
}