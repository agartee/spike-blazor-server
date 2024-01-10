using Bunit;
using Bunit.TestDoubles;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Spike.WebApp.Pages;

namespace Spike.WebApp.Tests.Pages
{
    public class IndexTests : TestContext
    {
        // reference:
        // https://learn.microsoft.com/en-us/aspnet/core/blazor/test?view=aspnetcore-8.0
        // https://bunit.dev/docs/providing-input/inject-services-into-components.html
        // https://bunit.dev/api/Bunit.TestDoubles.FakeAuthorizationPolicyProvider.html

        private readonly Mock<IMediator> mediator = new Mock<IMediator>();
        private readonly IAuthorizationPolicyProvider authPolicyProvider = new FakeAuthorizationPolicyProvider();

        public IndexTests() 
        {
            Services.AddSingleton(mediator.Object);
            Services.AddSingleton(authPolicyProvider);
        }

        [Fact]
        public void OnInit_RendersHeader()
        {
            var component = RenderComponent<Home>();

            component.Find("h1")
                .MarkupMatches("<h1>Hello, world!</h1>");

            component.FindAll("h3").Should().BeEmpty();
        }
    }
}
