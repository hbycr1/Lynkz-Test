using Application.Enum;

namespace Application.Models.Common;
public abstract class Shape
{
    public ShapeType Type { get; set; }
    public object Data { get; set; }
    public abstract void CalculateShapeData(ShapeRequirement requirements);
}
