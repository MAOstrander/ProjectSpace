using GroundControl.DataLayer;
using GroundControl.Models;
using GroundControl.Services;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Tests
{
    class LaunchpadServiceTests
    {
        private LaunchpadService sut;
        private Mock<ILaunchpadDAO> dao;

        [SetUp]
        public void Setup()
        {
            dao = new Mock<ILaunchpadDAO>();

            sut = new LaunchpadService(dao.Object);
        }

        [Test]
        public async Task GetLaunchPadById_WithValidId_WillReturnLaunchpad()
        {
            var mockLaunchpadModel = new Mock<LaunchpadModel>("777", "name", "status");
            dao.Setup(x => x.getLaunchPadById(It.IsAny<string>()))
                .ReturnsAsync(mockLaunchpadModel.Object);

            var answer = await sut.getLaunchPadById("777");

            Assert.IsInstanceOf(typeof(LaunchpadModel), answer);
        }

    }
}
