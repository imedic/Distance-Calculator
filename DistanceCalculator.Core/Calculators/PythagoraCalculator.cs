using DistanceCalculator.Core.Contracts;
using DistanceCalculator.Core.Enums;
using DistanceCalculator.Core.ValueObjects;

namespace DistanceCalculator.Core.Calculators;

public class PythagoraCalculator : ICalculator
{
    public Formula Formula => Formula.Pythagora;

    public double Calculate(Coordinates start, Coordinates end, double radius)
    {
        start.UseRadValues();
        end.UseRadValues();

        var delta = start.Longitude - end.Longitude;

        var x = delta * Math.Cos((start.Lattitude + end.Lattitude) /2);
        var y = end.Lattitude - start.Lattitude;

        var distance = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * radius;

        return distance;
    }
}
