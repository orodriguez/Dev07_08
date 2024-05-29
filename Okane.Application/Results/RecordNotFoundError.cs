using FluentResults;

namespace Okane.Application.Results;

public class RecordNotFoundError : Error
{
    public RecordNotFoundError(string message) : base(message)
    {
    }
}