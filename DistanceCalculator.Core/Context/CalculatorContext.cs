using DistanceCalculator.Core.Calculators;
using DistanceCalculator.Core.Contracts;
using DistanceCalculator.Core.Enums;
using DistanceCalculator.Core.ValueObjects;

namespace DistanceCalculator.Core.Factories;

public class CalculatorContext : ICalculatorContext
{
    private ICalculatorStrategy? _calculatorStrategy;
    private readonly IEnumerable<ICalculatorStrategy> _calculators;

    public CalculatorContext(IEnumerable<ICalculatorStrategy> calculators)
    {
        _calculators = calculators;
    }

    public void SetStrategy(Formula formula)
    {
        _calculatorStrategy = _calculators.FirstOrDefault(x => x.Formula == formula) ?? throw new ArgumentNullException(nameof(formula));
    }

    public double Calculate(Coordinates start, Coordinates end, double radius)
    {
        if (_calculatorStrategy == null)
        {
            throw new Exception("Strategy not set. You must call SetStrategy before doing the calculation");
        }

        return _calculatorStrategy.Calculate(start, end, radius);
    }
}
