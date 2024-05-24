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
        var expectedStationsDto = new StationsDto { Payload = [] };

        _stationsRepositoryMock.Setup(r => r.GetStationsAsync(query, limit))
            .ReturnsAsync(expectedStationsDto);
        
        await _stationsService.GetFilteredStationsAsync(query, limit);
        
        _stationsRepositoryMock.Verify(r => r.GetStationsAsync(query, limit), Times.Once);
    }
    
    [Test]
    public async Task GetStationsAsync_WithValidInput_ReturnsStationsDto()
    {
        string query = "Amsterdam";
        int limit = 10;
        var expectedStationsDto = new StationsDto { Payload = [] };
        
        _stationsRepositoryMock.Setup(r => r.GetStationsAsync(query, limit))
            .ReturnsAsync(expectedStationsDto);
        
        var result = await _stationsService.GetFilteredStationsAsync(query, limit);
        
        Assert.That(result, Is.EqualTo(expectedStationsDto));
    }
}