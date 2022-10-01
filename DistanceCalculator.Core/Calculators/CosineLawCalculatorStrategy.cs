using DistanceCalculator.Core.Contracts;
using DistanceCalculator.Core.Enums;
using DistanceCalculator.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistanceCalculator.Core.Calculators
{
    public class CosineLawCalculatorStrategy : ICalculatorStrategy
    {
        public Formula Formula => Formula.CosineLaw;

        public double Calculate(Coordinates start, Coordinates end, double radius)
        {
            start.UseRadValues();
            end.UseRadValues();

            var a = 90 - start.Lattitude;
            var b = 90 - end.Lattitude;
            var azimuth = start.Longitude - end.Longitude;

            var partOne = Math.Cos(a) * Math.Cos(b);
            var partTwo = Math.Sin(a) * Math.Sin(b) * Math.Cos(azimuth);

            var p = Math.Acos(partOne + partTwo);

            return radius * p;
        }
    }
}
