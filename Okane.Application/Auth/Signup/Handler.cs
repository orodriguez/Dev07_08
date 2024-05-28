using FluentResults;
using MediatR;
using Okane.Domain;

namespace Okane.Application.Auth.Signup;

public class Handler : IRequestHandler<Request, Result<Response>>
{
    private readonly IUsersRepository _users;
    private readonly IPasswordHasher _passwordHasher;

    public Handler(IUsersRepository users, IPasswordHasher passwordHasher)
    {
        _users = users;
        _passwordHasher = passwordHasher;
    }
    
    public Task<Result<Response>> Handle(Request request, CancellationToken cancellationToken)
    {
        var user = CreateUser(request);
        
        _users.Add(user);
        
        return Task.FromResult(Result.Ok(CreateResponse(user)));
    }

    private User CreateUser(Request request) =>
        new()
        {
            Email = request.Email,
            HashedPassword = HashPassword(request.Password)
        };

    private string HashPassword(string password) => _passwordHasher.Hash(password);

    // TODO: Setup Automapper
    private Response CreateResponse(User user) => 
        new(user.Id, user.Email);
}