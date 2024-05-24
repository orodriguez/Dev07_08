using Moq;
using Okane.Application.Auth.SignIn;
using Okane.Domain;

namespace Okane.Tests;

public class TokenGeneratorMock : Mock<ITokenGenerator>
{
    public TokenGeneratorMock() : base(MockBehavior.Strict)
    {
        Setup(generator => generator.Generate(It.IsAny<User>()))
            .Returns("FakeToken");
    }
}