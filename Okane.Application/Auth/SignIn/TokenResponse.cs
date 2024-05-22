namespace Okane.Application.Auth.SignIn;

public record TokenResponse(string Value) : ISignInResponse;