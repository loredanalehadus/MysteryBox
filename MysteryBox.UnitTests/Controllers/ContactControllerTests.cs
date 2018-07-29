using System.Threading.Tasks;
using FluentAssertions;
using MysteryBox.WebService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MysteryBox.UnitTests.Mocks;
using MysteryBox.WebService.Services;
using Xunit;

namespace MysteryBox.UnitTests.Controllers
{
    public class ContactControllerTests
    {
        private readonly ContactController _controller;
        private readonly Mock<IContactService> _mockContactService;

        public ContactControllerTests()
        {
            _mockContactService = new Mock<IContactService>(MockBehavior.Strict);
            _controller = new ContactController(_mockContactService.Object);
        }

        [Fact]
        public async Task Create_WithValidInfo_ShouldReturnNewContact()
        {
            var contactRequest = new ContactRequestBuilder().Build();
            var contactResponse = new ContactResponseBuilder().Build();

            _mockContactService.Setup(service => service.Create(contactRequest)).ReturnsAsync(contactResponse);

            var actionResult = await _controller.Post(contactRequest);
            actionResult.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task Delete_WithInexistendContactId_ShouldReturnBadRequest()
        {
            var contactResponse = new ContactResponseBuilder().WithResultCode(300).Build();
            _mockContactService.Setup(service => service.Delete(100)).ReturnsAsync(contactResponse);

            var actionResult = await _controller.Delete(100);
            actionResult.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}