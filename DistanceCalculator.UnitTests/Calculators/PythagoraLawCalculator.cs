using DistanceCalculator.Core.Calculators;
using DistanceCalculator.Core.ValueObjects;

namespace DistanceCalculator.UnitTests.Calculators;

public class PythagoraLawCalculator
{
    public static IEnumerable<object[]> TestData => new List<Object[]> {
                            new object[] { new Coordinates(10, 10), new Coordinates(20, 20), 6371, 1545.974501357075 },
                            new object[] { new Coordinates(20, 20), new Coordinates(10, 10), 6371, 1545.974501357075 },
                            new object[] { new Coordinates(10, 10), new Coordinates(10, 10), 6371, 0 },
                            new object[] { new Coordinates(10, 10), new Coordinates(20, 20), 0, 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Calculate_CorrectInput_ReturnsCorrectResults(Coordinates start, Coordinates end, double radius, double expected)
    {
        var calculator = new PythagoraCalculator();

        var result = calculator.Calculate(start, end, radius);

        Assert.Equal(expected, result);
    }
}
