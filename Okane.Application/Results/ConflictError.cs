using FluentResults;

namespace Okane.Application.Results;

public class ConflictError : Error
{
    public ConflictError(string message) : base(message)
    {
    }
}