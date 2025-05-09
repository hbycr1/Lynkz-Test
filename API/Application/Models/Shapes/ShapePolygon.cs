using Application.Enum;
using Application.Models.Common;

namespace Application.Models.Shapes;
internal class ShapePolygon : Shape
{
    public override void CalculateShapeData(ShapeRequirement requirements)
    {
        Type = requirements.ShapeType;

        var points = new List<object>();
        int sides = 0;
        int sideLength = 0;

        // get sides
        switch (Type)
        {
            case ShapeType.Pentagon:
                sides = 5;
                break;
            case ShapeType.Hexagon:
                sides = 6;
                break;
            case ShapeType.Heptagon:
                sides = 7;
                break;
            case ShapeType.Octagon:
                sides = 8;
                break;
        }

        // get side length
        if (requirements.Measurement1 == "side length")
            sideLength = requirements.Measurement1Value;
        else
            throw new Exception("You must specify a side length");


        double radius = sideLength / (2 * Math.Sin(Math.PI / sides));
        for (int i = 0; i < sides; i++)
        {
            // Calculate points in a circle
            double angle = 2 * Math.PI * i / sides - Math.PI / 2; // Start from top
            double x = radius * Math.Cos(angle);
            double y = radius * Math.Sin(angle);

            points.Add(new { x, y });
        }

        Data = new
        {
            Width = (sideLength * sides) / 2.5,
            Height = (sideLength * sides) / 2.5,
            sides,
            sideLength,
            points
        };
    }
}
