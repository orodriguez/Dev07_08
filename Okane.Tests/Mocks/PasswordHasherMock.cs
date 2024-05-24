using Moq;
using Okane.Application.Auth.Signup;

namespace Okane.Tests.Mocks;

public class PasswordHasherMock : Mock<IPasswordHasher>
{
    public PasswordHasherMock() : base(MockBehavior.Strict)
    {
        Setup(hasher => hasher.Hash(It.IsAny<string>()))
            .Returns((string plainPassword) => plainPassword);
        Setup(hasher =>
                hasher.Verify(It.IsAny<string>(), It.IsAny<string>()))
            .Returns(true);
    }
}