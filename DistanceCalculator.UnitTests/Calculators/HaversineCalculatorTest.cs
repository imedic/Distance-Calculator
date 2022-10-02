using DistanceCalculator.Core.Calculators;
using DistanceCalculator.Core.ValueObjects;

namespace DistanceCalculator.UnitTests.Calculators;

public class HaversineCalculatorTest
{
    public static IEnumerable<object[]> TestData => new List<Object[]> {
                            new object[] { new Coordinates(10, 10), new Coordinates(20, 20), 6371, 1544.7575610296099 },
                            new object[] { new Coordinates(20, 20), new Coordinates(10, 10), 6371, 1544.7575610296099 },
                            new object[] { new Coordinates(10, 10), new Coordinates(10, 10), 6371, 0 },
                            new object[] { new Coordinates(10, 10), new Coordinates(20, 20), 0, 0 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Calculate_CorrectInput_ReturnsCorrectResults(Coordinates start, Coordinates end, double radius, double expected)
    {
        var calculator = new HaversineCalculator();

        var result = calculator.Calculate(start, end, radius);

        Assert.Equal(expected, result);
    }
}
