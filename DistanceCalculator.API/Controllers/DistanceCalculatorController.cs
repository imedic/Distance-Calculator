using DistanceCalculator.Core.Commands;
using DistanceCalculator.Core.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DistanceCalculator.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DistanceCalculatorController
{
    private readonly IDistanceService _service;

    public DistanceCalculatorController(IDistanceService service)
    {
        _service = service;
    }


    [HttpGet()]
    public double GetDistance([FromQuery] DistanceCommand command)
    {
        return _service.CalculateDistance(command);
    }

}
