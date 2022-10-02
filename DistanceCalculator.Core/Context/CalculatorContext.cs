using DistanceCalculator.Core.Calculators;
using DistanceCalculator.Core.Contracts;
using DistanceCalculator.Core.Enums;
using DistanceCalculator.Core.ValueObjects;

namespace DistanceCalculator.Core.Factories;

public class CalculatorContext : ICalculatorContext
{
    private ICalculator? _calculator;
    private readonly IEnumerable<ICalculator> _calculators;

    public CalculatorContext(IEnumerable<ICalculator> calculators)
    {
        _calculators = calculators;
    }

    public void SetFormula(Formula formula)
    {
        _calculator = _calculators.FirstOrDefault(x => x.Formula == formula) ?? throw new ArgumentNullException(nameof(formula));
    }

    public double Calculate(Coordinates start, Coordinates end, double radius)
    {
        if (_calculator == null)
        {
            throw new Exception("Strategy not set. You must call SetStrategy before doing the calculation");
        }

        return _calculator.Calculate(start, end, radius);
    }
}
