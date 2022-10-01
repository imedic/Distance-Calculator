using DistanceCalculator.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DistanceCalculator.Core.Commands;

public class DistanceCommand
{
    [Required]
    public string CoordinatesStart { get; set; } = String.Empty;

    [Required]
    public string CoordinatesEnd { get; set; } = String.Empty;

    public double Radius { get; set; } = 6371;

    public Formula Formula { get; set; } = Formula.CosineLaw;

    public MeasuringUnit MeasuringUnit { get; set; } = MeasuringUnit.Meter;
}
