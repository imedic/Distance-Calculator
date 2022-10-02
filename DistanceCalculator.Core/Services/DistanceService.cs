using DistanceCalculator.Core.Commands;
using DistanceCalculator.Core.Contracts;

namespace DistanceCalculator.Core.Services;

public class DistanceService : IDistanceService
{
    private readonly ICoordinatesParseService _coordinatesParseService;
    private readonly ICalculatorContext _calculatorContext;
    private readonly IConverterService _converterService;

    public DistanceService(ICoordinatesParseService coordinatesParseService, ICalculatorContext calculatorContext, IConverterService converterService)
    {
        _coordinatesParseService = coordinatesParseService;
        _calculatorContext = calculatorContext;
        _converterService = converterService;
    }

    public double CalculateDistance(DistanceCommand command)
    {
        var start = _coordinatesParseService.Parse(command.CoordinatesStart);
        var end = _coordinatesParseService.Parse(command.CoordinatesEnd);

        _calculatorContext.SetFormula(command.Formula);
        var result = _calculatorContext.Calculate(start, end, command.Radius);

        return _converterService.Convert(result, command.MeasuringUnit);
    }
}
