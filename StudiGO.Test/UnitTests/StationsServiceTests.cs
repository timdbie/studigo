using Microsoft.Extensions.Logging;
using Moq;
using StudiGO.Core.Interfaces;
using StudiGO.Core.Services;
using StudiGO.Core.DTOs;

namespace StudiGO.Test.UnitTests;

[TestFixture]
public class StationsServiceTests
{
    private StationsService _stationsService;
    private Mock<IStationsRepository> _stationsRepositoryMock;
    private Mock<ILogger<StationsService>> _loggerMock;

    [SetUp]
    public void Setup()
    {
        _stationsRepositoryMock = new Mock<IStationsRepository>();
        _loggerMock = new Mock<ILogger<StationsService>>();
        _stationsService = new StationsService(_stationsRepositoryMock.Object, _loggerMock.Object);
    }

    [Test]
    public async Task GetStationsAsync_WithValidInput_CallsStationsRepository()
    {
        string query = "Amsterdam";
        int limit = 10;
        var expectedStationsDto = new StationsDto { Payload = [] };

        _stationsRepositoryMock.Setup(r => r.GetStationsAsync())
            .ReturnsAsync(expectedStationsDto);
        
        await _stationsService.GetFilteredStationsAsync(query);
        
        _stationsRepositoryMock.Verify(r => r.GetStationsAsync(), Times.Once);
    }
    
    [Test]
    public async Task GetStationsAsync_WithValidInput_ReturnsStationsDto()
    {
        string query = "Amsterdam";
        int limit = 10;
        var expectedStationsDto = new StationsDto { Payload = [] };
        
        _stationsRepositoryMock.Setup(r => r.GetStationsAsync())
            .ReturnsAsync(expectedStationsDto);
        
        var result = await _stationsService.GetFilteredStationsAsync(query);
        
        Assert.That(result, Is.EqualTo(expectedStationsDto));
    }
}