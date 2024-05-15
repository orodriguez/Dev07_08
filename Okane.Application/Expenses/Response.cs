using Okane.Application.Common.Responses;

namespace Okane.Application.Expenses;

public record Response(int Id, int Amount, string Category) : IResponse;