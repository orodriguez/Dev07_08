using MediatR;
using Okane.Application.Auth.Signup;

namespace Okane.Application.Auth.SignIn;

public class SignInHandler : IRequestHandler<SignInRequest, ISignInResponse>
{
    private readonly IUsersRepository _users;
    private readonly IPasswordHasher _passwordHasher;
    private readonly ITokenGenerator _tokenGenerator;

    public SignInHandler(
        IUsersRepository users, 
        IPasswordHasher passwordHasher, 
        ITokenGenerator tokenGenerator)
    {
        _users = users;
        _passwordHasher = passwordHasher;
        _tokenGenerator = tokenGenerator;
    }

    public Task<ISignInResponse> Handle(SignInRequest request, CancellationToken cancellationToken)
    {
        var user = _users.ByEmail(request.Email);

        if (user == null)
            throw new NotImplementedException();

        if (!_passwordHasher.Verify(request.Password, user.HashedPassword))
            throw new NotImplementedException();

        var token = _tokenGenerator.Generate(user);
        return Task.FromResult<ISignInResponse>(new TokenResponse(token));
    }
}