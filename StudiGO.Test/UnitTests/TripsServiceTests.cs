using Microsoft.Extensions.Logging;
using Moq;
using StudiGO.Core.Interfaces;
using StudiGO.Core.Services;
using StudiGO.Core.DTOs;

namespace StudiGO.Test.UnitTests;

[TestFixture]
public class TripsServiceTests
{
    private TripsService _tripsService;
    private Mock<ITripsRepository> _tripsRepositoryMock;
    private Mock<ILogger<TripsService>> _logger;

    [SetUp]
    public void Setup()
    {
        _tripsRepositoryMock = new Mock<ITripsRepository>();
        _logger = new Mock<ILogger<TripsService>>();
        _tripsService = new TripsService(_tripsRepositoryMock.Object, _logger.Object);
    }

    [Test]
    public async Task GetTripsAsync_WithValidInput_CallsTripsRepository()
    {
        string fromStation = "Amsterdam";
        string toStation = "Rotterdam";
        string dateTime = "2024-05-17T12:00:00";
        
        await _tripsService.GetTripsAsync(fromStation, toStation, dateTime);
        
        _tripsRepositoryMock.Verify(r => r.GetTripsAsync(fromStation, toStation, dateTime), Times.Once);
    }

    [Test]
    public async Task GetTripsAsync_WithValidInput_ReturnsTripsDto()
    {
        string fromStation = "Amsterdam";
        string toStation = "Rotterdam";
        string dateTime = "2024-05-17T12:00:00";
        var expectedTripsDto = new TripsDto();

        _tripsRepositoryMock.Setup(r => r.GetTripsAsync(fromStation, toStation, dateTime))
            .ReturnsAsync(expectedTripsDto);
        
        var result = await _tripsService.GetTripsAsync(fromStation, toStation, dateTime);
        
        Assert.That(result, Is.EqualTo(expectedTripsDto));
    }
}