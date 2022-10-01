using DistanceCalculator.Core.Commands;

namespace DistanceCalculator.Core.Contracts;

public interface IDistanceService
{
    double CalculateDistance(DistanceCommand command);
}
