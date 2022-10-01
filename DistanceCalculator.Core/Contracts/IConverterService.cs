using DistanceCalculator.Core.Enums;

namespace DistanceCalculator.Core.Contracts;

public interface IConverterService
{
    double Convert(double value, MeasuringUnit unit);
}
