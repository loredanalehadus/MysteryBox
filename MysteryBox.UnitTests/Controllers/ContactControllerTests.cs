﻿using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Moq;
using MysteryBox.UnitTests.Mocks;
using MysteryBox.WebService;
using MysteryBox.WebService.Controllers;
using MysteryBox.WebService.Services;
using MysteryBox.WebService.Services.Common;
using Newtonsoft.Json;
using Xunit;

namespace MysteryBox.UnitTests.Controllers
{
    public class ContactControllerTests
    {
        private readonly ContactController _controller;
        private readonly Mock<IContactService> _mockContactService;
        private readonly Mock<ILoggingService<ContactController>> _mockLoggingService;

        public ContactControllerTests()
        {
            _mockContactService = new Mock<IContactService>(MockBehavior.Strict);
            _mockLoggingService = new Mock<ILoggingService<ContactController>>(MockBehavior.Strict);
            _controller = new ContactController(_mockContactService.Object, _mockLoggingService.Object);
        }

        [Fact]
        public async Task Create_WithValidInfo_ShouldReturnNewContact()
        {
            var contactRequest = new ContactRequestBuilder().Build();
            var contactResponse = new ContactResponseBuilder().Build();

            _mockLoggingService.Setup(l => l.LogInformation("Requesting create contact...", contactRequest));
            _mockContactService.Setup(service => service.Create(contactRequest)).ReturnsAsync(contactResponse);
            _mockLoggingService.Setup(l => l.LogInformation("Contact with '{ID}' successfully created.", contactResponse.Id));

            var actionResult = await _controller.Post(contactRequest);
            actionResult.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task Create_WithInvalidInfo_ShouldReturnBadRequest()
        {
            var contactRequest = new ContactRequestBuilder().WithTelephone("invalid phone").WithEmail("invalid email").Build();

            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            var client = server.CreateClient();
            var content = new StringContent(JsonConvert.SerializeObject(contactRequest), Encoding.UTF8, "application/json");
            var result = await client.PostAsync("/api/Contact", content);
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);

            var respone = await result.Content.ReadAsStringAsync();
            respone.Should().Contain("Email is not valid. Please enter a correct email format. E.g. name@company.com");
            respone.Should().Contain("Phone number is not in correct format. The pattern is: +<InternationalDialingCode>.<TelephoneNumber>");
        }

        [Fact]
        public async Task Delete_WithInexistendContactId_ShouldReturnBadRequest()
        {
            var contactResponse = new ContactResponseBuilder().WithResultCode(300).Build();

            _mockLoggingService.Setup(l => l.LogInformation(It.IsAny<string>()));
            _mockContactService.Setup(service => service.Delete(100)).ReturnsAsync(contactResponse);
            _mockLoggingService.Setup(l => l.LogError(It.IsAny<string>()));

            var actionResult = await _controller.Delete(100);
            actionResult.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}