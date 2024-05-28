using FluentResults;
using MediatR;

namespace Okane.Application.Auth;

public class AuthService
{
    private readonly IMediator _mediator;

    public AuthService(IMediator mediator) => _mediator = mediator;

    public Task<Result<Signup.Response>> SignUp(string email, string password) => 
        _mediator.Send(new Signup.Request(email, password));

    public Task<Result<SignIn.Response>> SignIn(string email, string password) => 
        _mediator.Send(new SignIn.Request(email, password));
}