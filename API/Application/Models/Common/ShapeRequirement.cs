using Application.Enum;

namespace Application.Models.Common;
public class ShapeRequirement
{
    public ShapeType ShapeType { get; set; }

    public string Measurement1 { get; set; }
    public int Measurement1Value { get; set; }

    public string? Measurement2 { get; set; }
    public int? Measurement2Value { get; set; }
}
