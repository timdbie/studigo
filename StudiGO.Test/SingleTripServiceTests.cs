using Moq;
using StudiGO.Core.Interfaces;
using StudiGO.Core.Services;
using StudiGO.Core.DTOs;

namespace StudiGO.Test;

[TestFixture]
public class SingleTripServiceTests
{
    private SingleTripService _singleTripService;
    private Mock<ISingleTripRepository> _singleTripRepositoryMock;
    
    [SetUp]
    public void Setup()
    {
        _singleTripRepositoryMock = new Mock<ISingleTripRepository>();
        _singleTripService = new SingleTripService(_singleTripRepositoryMock.Object);
    }
    
    [Test]
    public async Task GetSingleTripAsync_WithValidInput_CallsSingleTripRepository()
    {
        string context = "arnu|fromStation=8400058|toStation=8400530|plannedFromTime=2024-05-17T00:00:00+02:00";
        
        await _singleTripService.GetSingleTripAsync(context);
        
        _singleTripRepositoryMock.Verify(r => r.GetSingleTripAsync(context), Times.Once);
    }
    
    [Test]
    public async Task GetSingleTripAsync_WithValidInput_ReturnsSingleTripDto()
    {
        string context = "arnu|fromStation=8400058|toStation=8400530|plannedFromTime=2024-05-17T00:00:00+02:00";
        var expectedSingleTripDto = new SingleTripDto();

        _singleTripRepositoryMock.Setup(r => r.GetSingleTripAsync(context))
            .ReturnsAsync(expectedSingleTripDto);
        
        var result = await _singleTripService.GetSingleTripAsync(context);
        
        Assert.That(result, Is.EqualTo(expectedSingleTripDto));
    }
}