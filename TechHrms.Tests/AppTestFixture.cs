using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace TechHrms.Tests
{
    public class AppTestFixture : TestBase
    {
        public IMediator Mediator { get; private set; }

        public AppTestFixture()
        {
            Mediator = Prepare().GetService<IMediator>();
        }
    }
}
