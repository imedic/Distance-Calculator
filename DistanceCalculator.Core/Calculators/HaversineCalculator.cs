using DistanceCalculator.Core.Contracts;
using DistanceCalculator.Core.Enums;
using DistanceCalculator.Core.ValueObjects;

namespace DistanceCalculator.Core.Calculators;

public class HaversineCalculator : ICalculator
{
    public Formula Formula => Formula.Haversine;

    public double Calculate(Coordinates start, Coordinates end, double radius)
    {
        start.UseRadValues();
        end.UseRadValues();

        var deltaLat = start.Lattitude - end.Lattitude;
        var deltaLong = start.Longitude - end.Longitude;

        var a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) +
                Math.Cos(start.Lattitude) * Math.Cos(end.Lattitude) *
                Math.Sin(deltaLong / 2) * Math.Sin(deltaLong / 2);

        var distance = Math.Atan2(
                        Math.Sqrt(a),
                        Math.Sqrt(1-a)
                      ) * 2 * radius;

        return distance;
    }
}
