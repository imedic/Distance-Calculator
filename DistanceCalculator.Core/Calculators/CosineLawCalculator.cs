using DistanceCalculator.Core.Contracts;
using DistanceCalculator.Core.Enums;
using DistanceCalculator.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceCalculator.Core.Calculators;

public class CosineLawCalculator : ICalculator
{
    public Formula Formula => Formula.CosineLaw;

    public double Calculate(Coordinates start, Coordinates end, double radius)
    {
        start.UseRadValues();
        end.UseRadValues();

        var delta = start.Longitude - end.Longitude;

        var distance = Math.Acos(
                        Math.Sin(start.Lattitude) * Math.Sin(end.Lattitude) +
                        Math.Cos(start.Lattitude) * Math.Cos(end.Lattitude) * Math.Cos(delta)
                      ) * radius;

        return distance;
    }
}
