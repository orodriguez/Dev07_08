using FluentResults;
using MediatR;
using Okane.Domain;

namespace Okane.Application.Expenses.Create;

 public record Request(int Amount, string CategoryName, string? Description = null) 
    : IRequest<Result<Response>>
{
    public Expense ToExpense(Category category, DateTime createdAt, int userId) =>
        new()
        {
            Amount = Amount,
            Category = category,
            Description = Description,
            UserId = userId,
            CreatedAt = createdAt
        };
}