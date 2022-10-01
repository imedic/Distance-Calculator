using DistanceCalculator.Core.Contracts;
using DistanceCalculator.Core.Enums;

namespace DistanceCalculator.Core.Services;

public class ConverterService : IConverterService
{
    private readonly Dictionary<MeasuringUnit, Func<double, double>> converters = new Dictionary<MeasuringUnit, Func<double, double>>()
    {
        { MeasuringUnit.Meter, (value) => value * 1000 },
        { MeasuringUnit.Kilometer, (value) => value },
        { MeasuringUnit.Inch, (value) => value * 39370.0787 },
        { MeasuringUnit.Foot, (value) => value * 3280.8399  },
        { MeasuringUnit.Yard, (value) => value * 1093.6133  },
        { MeasuringUnit.NauticalMile, (value) => value * 0.5399568035 },
        { MeasuringUnit.Mile, (value) => value * 0.62137 }
    };

    public double Convert(double value, MeasuringUnit unit)
    {
        return converters[unit](value);
    }
}
