using DistanceCalculator.Core.Enums;
using DistanceCalculator.Core.Services;
using DistanceCalculator.Core.ValueObjects;

namespace DistanceCalculator.UnitTests.Services;

public class ConverterServiceTest
{
    public static IEnumerable<object[]> TestData => new List<Object[]> {
                            new object[] { 1, MeasuringUnit.Meter, 1000 },
                            new object[] { 1, MeasuringUnit.Kilometer, 1 },
                            new object[] { 1, MeasuringUnit.Inch, 39370.0787 },
                            new object[] { 1, MeasuringUnit.Foot, 3280.8399 },
                            new object[] { 1, MeasuringUnit.Yard, 1093.6133 },
                            new object[] { 1, MeasuringUnit.NauticalMile, 0.5399568035 },
                            new object[] { 1, MeasuringUnit.Mile, 0.62137 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    void Convert_ToUnit_ReturnsCorrectResult(double input, MeasuringUnit unit, double expected)
    {
        var converterService = new ConverterService();

        var result = converterService.Convert(input, unit);

        Assert.Equal(expected, result);
    }
}
