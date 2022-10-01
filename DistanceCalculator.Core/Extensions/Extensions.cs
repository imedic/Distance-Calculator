namespace DistanceCalculator.Core.Extensions;

public static class Extensions
{
    public static double ToRad(this double dec)
    {
        return (Math.PI * dec) / 180;
    }
}
