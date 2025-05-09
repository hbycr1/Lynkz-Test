using Application.Enum;
using Application.Models.Common;

namespace Application.Models.Shapes;
internal class ShapeTriangle : Shape
{
    public override void CalculateShapeData(ShapeRequirement requirements)
    {
        Type = requirements.ShapeType;

        var points = new List<object>();

        int width = 0;
        int height = 0;

        // find width
        if (requirements.Measurement1 == "width")
            width = requirements.Measurement1Value;
        else if (requirements.Measurement2 == "width" && requirements.Measurement2Value.HasValue)
            width = requirements.Measurement2Value.Value;

        // find height
        if (requirements.Measurement1 == "height")
            height = requirements.Measurement1Value;
        else if (requirements.Measurement2 == "height" && requirements.Measurement2Value.HasValue)
            height = requirements.Measurement2Value.Value;

        if (width == 0 || height == 0)
            throw new Exception("You must specify a width and height for a Triangle");

        switch (Type)
        {
            case ShapeType.IsoscelesTriangle:
                points.Add(new { X = 0, Y = -height / 2 });
                points.Add(new { X = width / 2, Y = height / 2 });
                points.Add(new { X = -width / 2, Y = height / 2 });
                break;

            case ShapeType.EquilateralTriangle:
                // equilateral triangle = (√3/2) * side length
                double eqHeight = (Math.Sqrt(3) / 2) * width;

                points.Add(new { X = 0, Y = -eqHeight / 2 });
                points.Add(new { X = width / 2, Y = eqHeight / 2 });
                points.Add(new { X = -width / 2, Y = eqHeight / 2 });
                break;

            case ShapeType.ScaleneTriangle:
                points.Add(new { X = 0, Y = -height / 2 });
                points.Add(new { X = width / 2, Y = height / 2 });
                points.Add(new { X = -width / 3, Y = height / 2 });
                break;
        }

        Data = new
        {
            width,
            height,
            points
        };
    }
}
