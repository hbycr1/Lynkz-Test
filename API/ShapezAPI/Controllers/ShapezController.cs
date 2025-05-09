using Application.Interfaces;
using Application.Models.Common;
using Microsoft.AspNetCore.Mvc;

namespace ShapezAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShapezController(IShapeService shapeService) : ControllerBase
{
    private readonly IShapeService _shapeService = shapeService;

    [HttpPost("generate")]
    public Result<Shape> GetShape([FromBody] ShapeRequest request)
    {
        try
        {
            return _shapeService.GenerateShape(request.Prompt);
        }
        catch (Exception e)
        {
            return new()
            {
                Errors = [e.InnerException?.Message ?? e.Message]
            };
        }
    }
}
