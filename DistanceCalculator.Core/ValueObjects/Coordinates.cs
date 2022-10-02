using DistanceCalculator.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Throw;

namespace DistanceCalculator.Core.ValueObjects;

public class Coordinates
{
    public double Longitude { get; internal set; }
    public double Lattitude { get; internal set; }

    public Coordinates(double lattitude, double longitude)
    {
        Lattitude = lattitude;
        Longitude = longitude;
    }

    public void UseRadValues()
    {
        Longitude = Longitude.ToRad();
        Lattitude = Lattitude.ToRad();
    }
}
