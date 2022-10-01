using DistanceCalculator.Core.Extensions;

namespace DistanceCalculator.UnitTests.Extensions;

public class ExtensionsTest
{
    [Fact]
    public void ToRad_ReturnsCorrectNumber()
    {
        double degree = 180;
        double expectedRad = Math.PI;

        Assert.Equal(degree.ToRad(), expectedRad);
    }
}
