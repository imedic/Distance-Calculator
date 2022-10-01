using DistanceCalculator.Core.Extensions;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using Throw;

namespace DistanceCalculator.Core.ValueObjects;

public class Coordinates
{
    public double Longitude { get; internal set; }
    public double Lattitude { get; internal set; }

    public Coordinates(string coordinates)
    {
        var coordinateParts = coordinates.Split(",")
                                         .Select(s =>
                                         {
                                             double.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out double value)
                                                    .Throw(() => new ValidationException("Longitude and Lattitude need to be decimal numbers"))
                                                    .IfFalse();

                                             return value;
                                         })
                                         .ToArray();

        coordinateParts.Throw(() => new ValidationException("Invalid coordinates, format must be 'A, B'")).IfCountNotEquals(2);

        Lattitude = coordinateParts[0];
        Lattitude.Throw(() => new ValidationException("Invalid coordinates, Lattitude must be between -90 and 90"))
         .IfGreaterThan(90)
         .IfLessThan(-90);


        Longitude = coordinateParts[1];
        Longitude.Throw(() => new ValidationException("Invalid coordinates, Longitude must be between -180 and 180"))
                 .IfGreaterThan(180)
                 .IfLessThan(-180);
    }

    public void UseRadValues()
    {
        Longitude = Longitude.ToRad();
        Lattitude = Lattitude.ToRad();
    }
}
