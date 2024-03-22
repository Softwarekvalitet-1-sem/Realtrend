using Bunit;
using FluentAssertions;
using Realtrend.Components;
using Moq;
using Realtrend.Services;
using Microsoft.Extensions.DependencyInjection;
using Realtrend.Interfaces;

namespace RealTrend.UnitTests
{
    public class AddressFormUnitTest
    {
      [Fact]
      public void WhenInitialized_ShouldHaveEmptyFields()
      {
        // Arrange
        using var ctx = new TestContext();
        var addressStateServiceMock = new Mock<AddressStateService>();
        var addressMock = new Mock<IAddress>();
        ctx.Services.AddSingleton(addressStateServiceMock.Object);
        ctx.Services.AddSingleton(addressMock.Object);

        // Act
        var cut = ctx.RenderComponent<AddressForm>();

        // Assert
        cut.Find("#street").TextContent.Should().BeEmpty();
        cut.Find("#zipCode").TextContent.Should().BeEmpty();
        cut.Find("#city").TextContent.Should().BeEmpty();
      }

      [Fact]
      public void WhenSubmitButtonIsClicked_EventCallbackShouldBeCalled()
      {
        // Arrange
        using var ctx = new TestContext();
        var addressStateServiceMock = new Mock<AddressStateService>();
        var addressMock = new Mock<IAddress>();
        ctx.Services.AddSingleton(addressStateServiceMock.Object);
        ctx.Services.AddSingleton(addressMock.Object);

        var callbackInvoked = false;
        var cut = ctx.RenderComponent<AddressForm>(parameters => parameters
          .Add(p => p.OnSubmitCallback, () => { callbackInvoked = true; }));
        var submitButton = cut.Find("input[type='submit']");

        // Act
        submitButton.Click();

        // Assert
        callbackInvoked.Should().BeTrue();
      }
    }
}