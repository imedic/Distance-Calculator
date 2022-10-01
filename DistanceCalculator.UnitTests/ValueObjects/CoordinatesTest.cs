using DistanceCalculator.Core.Extensions;
using DistanceCalculator.Core.ValueObjects;

namespace DistanceCalculator.UnitTests.ValueObjects;

public class CoordinatesTest
{
    [Fact]
    public void Coordinates_ValidInput_DoesNotThrow()
    {
        var input = "53.297975,-6.372663";

        var exception = Record.Exception(() => new Coordinates(input));

        Assert.Null(exception);
    }

    [Fact]
    public void Coordinates_Lattitude_ParsedCorrectly()
    {
        var input = "53.297975,-6.372663";

        var coordinates = new Coordinates(input);

        Assert.Equal(53.297975, coordinates.Lattitude);
    }

    [Fact]
    public void Coordinates_Lattitude_ThrowsIfOverLimit()
    {
        var input = "100,-6.372663";

        var exception = Record.Exception(() => new Coordinates(input));

        Assert.NotNull(exception);
    }

    [Fact]
    public void Coordinates_Lattitude_ThrowsIfUnderLimit()
    {
        var input = "-100,-6.372663";

        var exception = Record.Exception(() => new Coordinates(input));

        Assert.NotNull(exception);
    }

    [Fact]
    public void Coordinates_Longitude_ParsedCorrectly()
    {
        var input = "53.297975,-6.372663";

        var coordinates = new Coordinates(input);

        Assert.Equal(-6.372663, coordinates.Longitude);
    }

    [Fact]
    public void Coordinates_Longitude_ThrowsIfOverLimit()
    {
        var input = "53.297975,200";

        var exception = Record.Exception(() => new Coordinates(input));

        Assert.NotNull(exception);
    }

    [Fact]
    public void Coordinates_Longitude_ThrowsIfUnderLimit()
    {
        var input = "53.297975,-200";

        var exception = Record.Exception(() => new Coordinates(input));

        Assert.NotNull(exception);
    }

    [Fact]
    public void Coordinates_LattitudeOnly_ThrowsException()
    {
        var input = "53.297975,";

        var exception = Record.Exception(() => new Coordinates(input));

        Assert.NotNull(exception);
    }

    [Fact]
    public void Coordinates_NoNumbers_ThrowsException()
    {
        var input = "abc,def";

        var exception = Record.Exception(() => new Coordinates(input));

        Assert.NotNull(exception);
    }
}
