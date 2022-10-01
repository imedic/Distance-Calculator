using System.ComponentModel.DataAnnotations;

namespace DistanceCalculator.Core.Commands;

public class DistanceCommand
{
    [Required]
    public string CoordinatesStart { get; set; } = String.Empty;
    [Required]
    public string CoordinatesEnd { get; set; } = String.Empty;
    public double Radius { get; set; } = 6371;
}
