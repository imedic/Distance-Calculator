using DistanceCalculator.Core.Commands;
using DistanceCalculator.Core.Contracts;
using DistanceCalculator.Core.ValueObjects;

namespace DistanceCalculator.Core.Services;

public class DistanceService : IDistanceService
{
    public double CalculateDistance(DistanceCommand command)
    {
        var start = new Coordinates(command.CoordinatesStart);
        start.UseRadValues();

        var end = new Coordinates(command.CoordinatesEnd);
        end.UseRadValues();

        var a = 90 - start.Lattitude;
        var b = 90 - end.Lattitude;
        var azimuth = start.Longitude - end.Longitude;

        var partOne = Math.Cos(a) * Math.Cos(b);
        var partTwo = Math.Sin(a) * Math.Sin(b) * Math.Cos(azimuth);

        var p = Math.Acos(partOne + partTwo);

        return command.Radius * p;
    }
}
