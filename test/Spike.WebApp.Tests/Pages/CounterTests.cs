using AngleSharp.Dom;
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
    public class CounterTests : TestContext
    {
        private CounterPage page;
        private readonly Mock<IMediator> mediator = new Mock<IMediator>();
        private readonly IAuthorizationPolicyProvider authPolicyProvider = new FakeAuthorizationPolicyProvider();

        public CounterTests()
        {
            // note: these have to be registered before any components are rendered
            Services.AddSingleton(mediator.Object);
            Services.AddSingleton(authPolicyProvider);

            page = new CounterPage(RenderComponent<Counter>());
        }

        [Fact]
        public void OnInit_ShowsCountOfZero()
        {
            page.CountParagraph.MarkupMatches("<p role=\"status\">Current count: 0</p>");
            page.GreaterThanZeroMessage.Should().BeNull();
        }

        [Fact]
        public void ClickMeClicked_IncrementsCount()
        {
            page.ClickMeButton.Click();

            page.GreaterThanZeroMessage!.TextContent.Should().Be("Count is greater than zero.");

            page.CountParagraph.MarkupMatches("<p role=\"status\">Current count: 1</p>");
            page.CountParagraph.TextContent.Should().Be("Current count: 1");
        }

        private class CounterPage
        {
            private readonly IRenderedComponent<Counter> component;

            public CounterPage(IRenderedComponent<Counter> component) 
            {
                this.component = component;
            }

            public IElement ClickMeButton 
            { 
                get { return component.Find("#increment"); } 
            }
            
            public IElement CountParagraph 
            { 
                get { return component.Find("p[role=status]"); } 
            }
            
            public IElement? GreaterThanZeroMessage
            {
                get 
                { 
                    return component
                        .FindAll("[data-message=greater-than-zero]")
                        .FirstOrDefault(); 
                }
            }

        }
    }
}
