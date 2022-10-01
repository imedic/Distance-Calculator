using DistanceCalculator.Core.Extensions;
using System.Globalization;

namespace DistanceCalculator.Core.ValueObjects;

public class Coordinates
{
    public double Longitude { get; internal set; }
    public double Lattitude { get; internal set; }

    public Coordinates(string coordinates)
    {
        var coordinateParts = coordinates.Split(", ");

        Longitude = double.Parse(coordinateParts[0], CultureInfo.InvariantCulture);
        Lattitude = double.Parse(coordinateParts[1], CultureInfo.InvariantCulture);
    }

    public void UseRadValues()
    {
        Longitude = Longitude.ToRad();
        Lattitude = Lattitude.ToRad();
    }
}
