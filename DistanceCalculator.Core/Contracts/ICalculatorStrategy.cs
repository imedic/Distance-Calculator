using DistanceCalculator.Core.Enums;
using DistanceCalculator.Core.ValueObjects;

namespace DistanceCalculator.Core.Contracts;

public interface ICalculator
{
    Formula Formula{ get; }

    double Calculate(Coordinates start, Coordinates end, double radius);
}
