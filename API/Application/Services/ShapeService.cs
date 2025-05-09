using Application.Enum;
using Application.Interfaces;
using Application.Models.Common;
using Application.Models.Shapes;
using System.Text.RegularExpressions;

namespace Application.Services;

public class ShapeService : IShapeService
{
    public Result<Shape> GenerateShape(string input)
    {
        try
        {
            var shape = DecipherUserInstruction(input);

            return new()
            {
                Model = CalculateShapeData(shape)
            };
        }
        catch (Exception e)
        {
            return new()
            {
                Errors = new List<string> { e.InnerException?.Message ?? e.Message }
            };
        }
    }

    public ShapeRequirement DecipherUserInstruction(string input)
    {
        // normalize string
        input = input.ToLower().Trim();

        // use regex to decipher string
        Match match = Regex.Match(input, ShapeInstructionRegex.Pattern, RegexOptions.IgnoreCase);
        if (match.Success)
        {
            var requirements = new ShapeRequirement
            {
                ShapeType = GetShapeTypeFromName(match.Groups[1].Value),
                Measurement1 = match.Groups[2].Value,
                Measurement1Value = int.Parse(match.Groups[3].Value)
            };

            // check if there is a second measurement
            if (match.Groups.Count > 3 && match.Groups[4].Success)
            {
                requirements.Measurement2 = match.Groups[4].Value;
                requirements.Measurement2Value = int.Parse(match.Groups[5].Value);
            }

            return requirements;
        }

        // could not find nothin
        throw new Exception("Could not decipher user instructions");
    }

    public Shape CalculateShapeData(ShapeRequirement requirements)
    {
        Shape shapeObject = requirements.ShapeType switch
        {
            ShapeType.Oval => new ShapeOval(),
            ShapeType.Circle => new ShapeCircle(),
            ShapeType.IsoscelesTriangle => new ShapeTriangle(),
            ShapeType.ScaleneTriangle => new ShapeTriangle(),
            ShapeType.EquilateralTriangle => new ShapeTriangle(),
            ShapeType.Square => new ShapeSquare(),
            ShapeType.Parallelogram => new ShapeParallelogram(),
            ShapeType.Rectangle => new ShapeSquare(),
            ShapeType.Pentagon => new ShapePolygon(),
            ShapeType.Hexagon => new ShapePolygon(),
            ShapeType.Heptagon => new ShapePolygon(),
            ShapeType.Octagon => new ShapePolygon(),
            _ => throw new Exception($"Could calculate shape data"),
        };

        // calculate shape data
        shapeObject.CalculateShapeData(requirements);

        // return the shape
        return shapeObject;
    }

    // HELPERS
    private ShapeType GetShapeTypeFromName(string name)
    {
        var shapeType = name switch
        {
            "isosceles triangle" => ShapeType.IsoscelesTriangle,
            "scalene triangle" => ShapeType.ScaleneTriangle,
            "equilateral triangle" => ShapeType.EquilateralTriangle,
            "square" => ShapeType.Square,
            "pentagon" => ShapeType.Pentagon,
            "rectangle" => ShapeType.Rectangle,
            "hexagon" => ShapeType.Hexagon,
            "heptagon" => ShapeType.Heptagon,
            "octagon" => ShapeType.Octagon,
            "circle" => ShapeType.Circle,
            "oval" => ShapeType.Oval,
            _ => throw new Exception($"The shape {name} is not a valid shape"),
        };

        return shapeType;
    }

}
