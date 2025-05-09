using Application.Models.Common;

namespace Application.Interfaces;
public interface IShapeService
{
    Result<Shape> GenerateShape(string input);
    ShapeRequirement DecipherUserInstruction(string input);
    Shape CalculateShapeData(ShapeRequirement requirements);
}
