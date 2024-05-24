using MediatR;

namespace Okane.Application.Auth.Signup;

public record SignUpRequest(string Email, string Password) : IRequest<ISignUpResponse>;