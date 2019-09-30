using GroundControl.Controllers;
using GroundControl.Models;
using GroundControl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    public class LaunchPadControllerTests
    {
        private LaunchpadController sut;
        private Mock<ILaunchpadService> _launchpadService;
        private Mock<ILogger<LaunchpadController>> _logger;

        [SetUp]
        public void Setup()
        {
            _launchpadService = new Mock<ILaunchpadService>();
            _logger = new Mock<ILogger<LaunchpadController>>();

            sut = new LaunchpadController(_launchpadService.Object, _logger.Object);
        }

        [Test]
        public async Task Get_WithValidId_WillReturnLaunchpad()
        {
            var mockLaunchpadModel = new Mock<LaunchpadModel>("777", "name", "status");
            _launchpadService.Setup(x => x.getLaunchPadById(It.IsAny<string>()))
                .ReturnsAsync(mockLaunchpadModel.Object);

            var answer = await sut.Get("777");

            Assert.IsInstanceOf(typeof(ActionResult<LaunchpadModel>), answer);
            Assert.IsInstanceOf(typeof(OkObjectResult), answer.Result);
        }

        [Test]
        public async Task Get_WithInvalidId_IsNotFoundResponse()
        {
            _launchpadService.Setup(x => x.getLaunchPadById(It.IsAny<string>()))
                .Throws(new Exception());

            var answer = await sut.Get("???");

            Assert.IsInstanceOf(typeof(ActionResult<LaunchpadModel>), answer);
            Assert.IsInstanceOf(typeof(NotFoundResult), answer.Result);
        }
    }
}