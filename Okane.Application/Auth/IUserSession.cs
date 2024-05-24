namespace Okane.Application.Auth;

public interface IUserSession
{
    int CurrentUserId { get; }
}