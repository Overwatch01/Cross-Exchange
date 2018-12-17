using System;
using System.Threading.Tasks;
using NUnit.Framework;
using XOProject.Repository.Domain;
using XOProject.Repository.Exchange;
using XOProject.Repository.Tests.Helpers;

namespace XOProject.Repository.Tests
{
    public class ShareRepositoryTests
    {
        private ShareRepository _shareRepository;
        private ExchangeContext _context;

        [SetUp]
        public void Initialize()
        {
            _context = ContextFactory.CreateContext(true);
            _shareRepository = new ShareRepository(_context);
        }

        [TearDown]
        public void Cleanup()
        {
            _context.Dispose();
            _context = null;
            _shareRepository = null;
        }

        [Test]
        public async Task GetAsync_WhenExists_ReturnsHourlyShareRate()
        {
            // Arrange
            var expected = new HourlyShareRate
                {Id = 10, Symbol = "CBI", Rate = 96, TimeStamp = new DateTime(2018, 08, 13, 02, 00, 00)};

            // Act
            var result = await _shareRepository.GetAsync(10);

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expected.Id, result.Id);
            Assert.AreEqual(expected.Symbol, result.Symbol);
            Assert.AreEqual(expected.Rate, result.Rate);
            Assert.AreEqual(expected.TimeStamp, result.TimeStamp);
        }

        [Test]
        public async Task GetAsync_WhenDoesNotExist_ReturnsNull()
        {
            // Arrange
            
            // Act
            var result = await _shareRepository.GetAsync(99);

            // Assert
            Assert.IsNull(result);
        }
    }
}
