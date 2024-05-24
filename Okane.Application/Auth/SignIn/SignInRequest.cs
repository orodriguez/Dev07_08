using MediatR;

namespace Okane.Application.Auth.SignIn;

public record SignInRequest(string Email, string Password) : IRequest<ISignInResponse>;