using Microsoft.AspNetCore.Mvc;

namespace DistanceCalculator.API.Controllers;

[ApiController]
[Route("[controller]")]
public class DistanceCalculatorController
{
    [HttpGet()]
    public int GetDistance()
    {
        return 5;
    }

}
