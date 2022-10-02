using DistanceCalculator.Core.ValueObjects;

namespace DistanceCalculator.Core.Contracts;

public interface ICoordinatesParseService
{
    Coordinates Parse(string coordinates);
}
