using MediatR;
using Okane.Domain;

namespace Okane.Application.Auth.Signup;

public class SignUpHandler : IRequestHandler<Request, ISignUpResponse>
{
    private readonly IUsersRepository _users;
    private readonly IPasswordHasher _passwordHasher;

    public SignUpHandler(IUsersRepository users, IPasswordHasher passwordHasher)
    {
        _users = users;
        _passwordHasher = passwordHasher;
    }
    
    public Task<ISignUpResponse> Handle(Request request, CancellationToken cancellationToken)
    {
        var user = CreateUser(request);
        
        _users.Add(user);
        
        return Task.FromResult(CreateResponse(user));
    }

    private User CreateUser(Request request) =>
        new()
        {
            Email = request.Email,
            HashedPassword = HashPassword(request.Password)
        };

    private string HashPassword(string password) => _passwordHasher.Hash(password);

    private ISignUpResponse CreateResponse(User user) => 
        new UserResponse(user.Id, user.Email);
}