using Application.Models.Common;

namespace Application.Models.Shapes;
public class ShapeCircle : Shape
{
    public override void CalculateShapeData(ShapeRequirement requirements)
    {
        Type = requirements.ShapeType;

        int radius = 0;
        if (requirements.Measurement1 == "radius")
            radius = requirements.Measurement1Value;
        else
            throw new Exception("You must specify a radius for a Circle");

        Data = new
        {
            Width = requirements.Measurement1Value * 2,
            Height = requirements.Measurement1Value * 2,
            Radius = requirements.Measurement1Value
        };
    }
}
