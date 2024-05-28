using FluentResults;
using MediatR;

namespace Okane.Application.Auth.Signup;

public record Request(string Email, string Password) : IRequest<Result<Response>>;