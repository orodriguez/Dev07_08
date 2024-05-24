using Okane.Application.Auth;

namespace Okane.Tests;

public class FakeUserSession : IUserSession
{
    public int CurrentUserId { get; set; }
}