using GroundControl.DataLayer;
using GroundControl.Models;
using GroundControl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class LaunchpadDAOTests
    {
        private LaunchpadDAO sut;
        private Mock<ILaunchpadRepo> _launchpadRepo;
        private Mock<ILogger<LaunchpadDAO>> _logger;

        [SetUp]
        public void Setup()
        {
            _launchpadRepo = new Mock<ILaunchpadRepo>();
            _logger = new Mock<ILogger<LaunchpadDAO>>();

            sut = new LaunchpadDAO(_launchpadRepo.Object, _logger.Object);
        }

        [Test]
        public async Task GetLaunchPadById_WithValidId_WillConvertAPItoLaunchpad()
        {
            var mockSpaceXApiReturnModel = new Mock<SpaceXApiReturnModel>();
            _launchpadRepo.Setup(x => x.GetById(It.IsAny<string>()))
                .ReturnsAsync(mockSpaceXApiReturnModel.Object);

            var answer = await sut.getLaunchPadById("777");

            Assert.IsInstanceOf(typeof(LaunchpadModel), answer);
        }

    }
}
