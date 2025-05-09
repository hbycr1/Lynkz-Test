using Application.Models.Common;

namespace Application.Models.Shapes;
internal class ShapeParallelogram : Shape
{
    public override void CalculateShapeData(ShapeRequirement requirements)
    {
        Type = requirements.ShapeType;

        
    }
}
