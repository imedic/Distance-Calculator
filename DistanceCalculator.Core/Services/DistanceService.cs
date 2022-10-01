using DistanceCalculator.Core.Calculators;
using DistanceCalculator.Core.Commands;
using DistanceCalculator.Core.Contracts;
using DistanceCalculator.Core.Enums;
using DistanceCalculator.Core.Factories;
using DistanceCalculator.Core.ValueObjects;

namespace DistanceCalculator.Core.Services;

public class DistanceService : IDistanceService
{
    private readonly ICalculatorContext _calculatorContext;
    private readonly IConverterService _converterService;

    public DistanceService(ICalculatorContext calculatorContext, IConverterService converterService)
    {
        _calculatorContext = calculatorContext;
        _converterService = converterService;
    }

    public double CalculateDistance(DistanceCommand command)
    {
        var start = new Coordinates(command.CoordinatesStart);
        var end = new Coordinates(command.CoordinatesEnd);

        _calculatorContext.SetStrategy(command.Formula);
        var result = _calculatorContext.Calculate(start, end, command.Radius);

        return _converterService.Convert(result, command.MeasuringUnit);
    }
}
