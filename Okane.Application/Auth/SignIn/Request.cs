using FluentResults;
using MediatR;

namespace Okane.Application.Auth.SignIn;

public record Request(string Email, string Password) : IRequest<Result<Response>>;