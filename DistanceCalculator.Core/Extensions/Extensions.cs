namespace DistanceCalculator.Core.Extensions;

public static class Extensions
{
    public static double ToRad(this double dec) => (Math.PI * dec) / 180;
}
