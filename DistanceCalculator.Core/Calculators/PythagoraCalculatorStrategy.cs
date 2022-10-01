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
    public class PythagoraCalculatorStrategy : ICalculatorStrategy
    {
        public Formula Formula => Formula.Pythagora;

        public double Calculate(Coordinates start, Coordinates end, double radius)
        {
            throw new NotImplementedException();
        }
    }
}
