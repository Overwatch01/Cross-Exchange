using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using XOProject.Api.Controller;
using XOProject.Api.Model;
using XOProject.Services.Exchange;

namespace XOProject.Api.Tests
{
    public class ShareControllerTests
    {
        private readonly Mock<IShareService> _shareServiceMock = new Mock<IShareService>();

        private readonly ShareController _shareController;

        public ShareControllerTests()
        {
            _shareController = new ShareController(_shareServiceMock.Object);
        }

        [TearDown]
        public void Cleanup()
        {
            _shareServiceMock.Reset();
        }

        [Test]
        public async Task Post_ShouldInsertHourlySharePrice()
        {
            // Arrange
            var hourRate = new HourlyShareRateModel
            {
                Symbol = "CBI",
                Rate = 330.0M,
                TimeStamp = new DateTime(2018, 08, 17, 5, 0, 0)
            };

            // Act
            var result = await _shareController.Post(hourRate);

            // Assert
            Assert.NotNull(result);

            // TODO: This unit test is broken, the result received from the Post method is correct.
            var createdResult = result as CreatedResult;
            Assert.NotNull(createdResult);
            Assert.AreEqual(201, createdResult);
        }
    }
}
