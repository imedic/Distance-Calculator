using DistanceCalculator.Core.Enums;
using DistanceCalculator.Core.ValueObjects;

namespace DistanceCalculator.Core.Contracts;

public interface ICalculatorContext
{
    void SetFormula(Formula formula);
    double Calculate(Coordinates start, Coordinates end, double radius);
}
