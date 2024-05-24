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
        var expectedStationsDto = new StationsDto { Payload = [] };
        
        _stationsRepositoryMock.Setup(r => r.GetStationsAsync())
            .ReturnsAsync(expectedStationsDto);
        
        var result = await _stationsService.GetFilteredStationsAsync(query);
        
        Assert.That(result, Is.EqualTo(expectedStationsDto));
    }

    [Test]
    public async Task GetFilteredStationsAsync_WithMatchingQuery_ReturnsFilteredStations()
    {
        string query = "Amsterdam";
        var expectedPayload = new List<Station>
        {
            new Station { Namen = new Namen { Lang = "Amsterdam Centraal" } },
            new Station { Namen = new Namen { Lang = "Amsterdam Zuid" } }
        };
        var stationsDto = new StationsDto { Payload = expectedPayload };

        _stationsRepositoryMock.Setup(r => r.GetStationsAsync())
            .ReturnsAsync(stationsDto);

        var result = await _stationsService.GetFilteredStationsAsync(query);

        Assert.That(result.Payload.Count, Is.EqualTo(2));
        Assert.That(result.Payload.All(p => p.Namen.Lang.StartsWith(query, StringComparison.OrdinalIgnoreCase)), Is.True);
    }

    [Test]
    public async Task GetFilteredStationsAsync_WithNoMatchingQuery_ReturnsEmptyList()
    {
        string query = "Rotterdam";
        var initialPayload = new List<Station>
        {
            new Station { Namen = new Namen { Lang = "Amsterdam Centraal" } },
            new Station { Namen = new Namen { Lang = "Amsterdam Zuid" } }
        };
        var stationsDto = new StationsDto { Payload = initialPayload };

        _stationsRepositoryMock.Setup(r => r.GetStationsAsync())
            .ReturnsAsync(stationsDto);

        var result = await _stationsService.GetFilteredStationsAsync(query);

        Assert.That(result.Payload, Is.Empty);
    }
}