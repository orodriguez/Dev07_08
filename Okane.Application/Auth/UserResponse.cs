using Okane.Application.Auth.Signup;

namespace Okane.Application.Auth;

public record UserResponse(int Id, string Email) : ISignUpResponse;