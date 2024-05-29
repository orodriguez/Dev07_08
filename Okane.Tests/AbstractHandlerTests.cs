using System.Globalization;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Okane.Application;
using Okane.Application.Auth.Signup;
using Okane.Tests.Mocks;

namespace Okane.Tests
{   
    public abstract class AbstractHandlerTests
    {
        private readonly ServiceProvider _provider;
        protected App App { get; set; }
        protected DateTime Now { get; set; }
        protected Mock<IPasswordHasher> PasswordHasherMock => Resolve<PasswordHasherMock>();
        protected AbstractHandlerTests()
        {
            Now = DateTime.Parse("2024-01-01", new CultureInfo("es-US"));
            
            var services = new ServiceCollection();
            
            services.AddOkane()
                .AddOkaneInMemoryStorage()
                .AddOkaneTestDoubles(() => Now);
            
            _provider = services.BuildServiceProvider();

            App = _provider.GetRequiredService<App>();
        }

        protected int CurrentUserId
        {
            get => Resolve<FakeUserSession>().CurrentUserId;
            set => Resolve<FakeUserSession>().CurrentUserId = value;
        }
        
        [Obsolete]
        protected Task<TResponse> Handle<TResponse>(IRequest<TResponse> request) => 
            Resolve<IMediator>().Send(request);

        private T Resolve<T>() where T : notnull =>
            _provider.GetRequiredService<T>();
    }
}