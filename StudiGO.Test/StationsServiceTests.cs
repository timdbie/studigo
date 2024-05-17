using Moq;
using StudiGO.Core.Interfaces;
using StudiGO.Core.Services;
using StudiGO.Core.DTOs;

namespace StudiGO.Test;

[TestFixture]
public class StationsServiceTests
{
    private StationsService _stationsService;
    private Mock<IStationsRepository> _stationsRepositoryMock;

    [SetUp]
    public void Setup()
    {
        _stationsRepositoryMock = new Mock<IStationsRepository>();
        _stationsService = new StationsService(_stationsRepositoryMock.Object);
    }

    [Test]
    public async Task GetStationsAsync_WithValidInput_CallsStationsRepository()
    {
        string query = "Amsterdam";
        int limit = 10;
        
        var payload = new List<Payload>
        {
            new Payload { Namen = new Namen { Lang = "Amsterdam Centraal" } },
            new Payload { Namen = new Namen { Lang = "Amsterdam Sloterdijk" } },
        };
        
        var stationsDto = new StationsDto { payload = payload };

        _stationsRepositoryMock.Setup(r => r.GetStationsAsync(query, limit))
            .ReturnsAsync(stationsDto);
        
        await _stationsService.GetFilteredStationsAsync(query, limit);
        
        _stationsRepositoryMock.Verify(r => r.GetStationsAsync(query, limit), Times.Once);
    }

}