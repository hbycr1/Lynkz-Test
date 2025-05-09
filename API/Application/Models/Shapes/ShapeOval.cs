using Application.Models.Common;

namespace Application.Models.Shapes;
internal class ShapeOval : Shape
{
    public override void CalculateShapeData(ShapeRequirement requirements)
    {
        Type = requirements.ShapeType;

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
            throw new Exception("You must specify a width and height for an Oval");

        Data = new
        {
            Width = width,
            Height = height,
            Rx = width / 2,
            Ry = height / 2
        };
    }
}
